using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using InfoPortal.Common.Models;
using System.ComponentModel.DataAnnotations;
using InfoPortal.WebMVC.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Models
{
    public class UpdateArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The string length must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public List<IFormFile> Files { get; set; }
  
        public IFormFile Image { get; set; }

        public IFormFile Video { get; set; }

        [BindProperty]
        public byte[] ImageContent { get; set; }

        [BindProperty]
        public byte[] VideoContent { get; set; }

        [Required]
        [EnsureOneElement(ErrorMessage = "At least one theme is required")]
        public List<int> ThemesId { get; set; }

        public int SelectedId { get; set; }

        [Required]
        public string Text { get; set; }

        public UpdateArticleViewModel()
        {
            ThemesId = new List<int>();
        }
    }
}
