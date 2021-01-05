using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using InfoPortal.Common.Models;

namespace InfoPortal.WebMVC.Models
{
    public class ArticleViewModel
    {
        //public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AddedOn { get; set; }

        public int LanguageId { get; set; }

        public List<IFormFile> Files { get; set; }

        public List<int> Themes { get; set; }

        public string Text { get; set; }
    }
}
