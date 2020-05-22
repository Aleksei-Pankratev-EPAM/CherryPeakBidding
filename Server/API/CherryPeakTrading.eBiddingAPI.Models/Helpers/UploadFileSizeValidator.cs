using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CherryPeakTrading.API.Models.Helpers
{
    [AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UploadFileSizeValidator
        : ValidationAttribute
    {
        public UploadFileSizeValidator(long sizeInBytes)
        {
            this.SizeInBytes = sizeInBytes;
        }

        public long SizeInBytes { get; private set; }

        /// <summary>
        ///     Validates the specified value with respect to the current validation attribute
        /// </summary>
        /// <param name="value">the value to validate</param>
        /// <returns>Returns - true to specify size is okay.</returns>
        public override bool IsValid(object value)
        {
            bool isValid = false;

            if (value is IFormFile file)
            {
                isValid = file.Length <= this.SizeInBytes;
            }

            return isValid;
        }
    }
}
