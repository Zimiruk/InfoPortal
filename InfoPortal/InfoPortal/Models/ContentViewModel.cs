using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.WebMVC.Models
{
    public class ContentViewModel
    {
        public List<Theme> Themes { get; set; }

        public List<Language> Languages { get; set; }
    }
}
