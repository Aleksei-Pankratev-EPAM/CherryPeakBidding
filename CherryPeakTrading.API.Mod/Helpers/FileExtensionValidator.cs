using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace CherryPeakTrading.API.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionsValidator : ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public FileExtensionsValidator(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public override bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {
                var fileName = file.FileName;

                return AllowedExtensions.Any(y => fileName.EndsWith(y));
            }

            return true;
        }
    }
}
