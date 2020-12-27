using System;
using System.Collections.Generic;

namespace InfoPortal.Common.Models
{
    public class Article : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }   

        public DateTime AddedOn { get; set; }

        public Language Language { get; set; }

        public int LanguageId { get; set; }

        public int Link { get; set; }

        public List<File> Files {get; set; }

        public List<Theme> Themes { get; set; }

        public List<int> ThemesId { get; set; }

    }
}
