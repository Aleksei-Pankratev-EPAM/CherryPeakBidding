using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CherryPeakTrading.API.Models.ViewModels;
using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace CherryPeakTrading.API.Controllers
{
    [Route("api/[controller]")]
    public class PhotosController : Controller
    {
        private readonly IFileStorage _fileStorage;
        private readonly IPhotosLogic _photosLogic;
        private readonly ILogger _logger;

        public PhotosController(IFileStorage fileStorage,
            IPhotosLogic photosLogic,
            ILogger<PhotosController> logger)
        {
            _fileStorage = fileStorage;
            _logger = logger;
            _photosLogic = photosLogic;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddPhoto(PhotosViewModel photo)
        {
            if (photo == null)
            {
                _logger.LogError("Photo sent from client is null.");
                return BadRequest();
            }

            if (ModelState.ErrorCount > 0)
            {
                var errorStr = GetModelErrors(ModelState);
                _logger.LogError(errorStr);
                return BadRequest(errorStr);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid photo object sent from client.");
                return BadRequest("Invalid model object");
            }

            var uri = string.Empty;
            using (Stream readStream = photo.File.OpenReadStream())
            {
                uri = _fileStorage.UploadFile(readStream, photo.File.ContentType, photo.LotId.ToString());
            }

            if (string.IsNullOrEmpty(uri))
            {
                return BadRequest("An error occurred when sending to the storage");
            }

            await _photosLogic.AddPhoto(new PhotoModel { LotId = photo.LotId, Url = uri, CreatedAt = DateTime.Now });

            return Ok(uri);
        }

        private string GetModelErrors(ModelStateDictionary modelState)
        {
            var errorSb = new StringBuilder();
            foreach (var modelStateKey in modelState.Keys)
            {
                var value = modelState[modelStateKey];
                foreach (var error in value.Errors)
                {
                    errorSb.AppendLine(error.ErrorMessage);
                }
            }

            return errorSb.ToString();
        }
    }
}
