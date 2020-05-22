using CherryPeakTrading.API.Models.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CherryPeakTrading.API.Models.ViewModels
{
    public class PhotosViewModel
    {
        /// <summary>
        /// Gets or sets Image file.
        /// </summary>
        [Required]
        [FileExtensionsValidator("jpg,png,gif,jpeg,bmp,svg", ErrorMessage = "File extension not allowed")]
        [UploadFileSizeValidator(sizeInBytes: 5 * 1024 * 1024, ErrorMessage = "Image filesize should be smaller than 5 MB")]
        public IFormFile File { get; set; }

        [Required]
        public Guid LotId { get; set; }
    }
}
