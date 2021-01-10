using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InfoPortal.WebMVC.ValidationAttributes
{
    public class ProperFiletAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;

            if (file.ContentType != "video/mp4")
            {
                return false;
            }
            return true;
        }
    }
}