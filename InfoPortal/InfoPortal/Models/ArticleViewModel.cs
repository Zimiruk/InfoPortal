﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoPortal.WebMVC.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Theme { get; set; }

        public DateTime AddedOn { get; set; }

        public string Language { get; set; }

        public string Picture { get; set; }

        public string Video { get; set; }

        public int Link { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}