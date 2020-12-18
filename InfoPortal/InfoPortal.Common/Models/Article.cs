using System;
using System.Collections.Generic;

namespace InfoPortal.Common.Models
{
    public class Article : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }   

        public DateTime AddedOn { get; set; }

        public string Language { get; set; }

        public int Link { get; set; }

        public List<File> Files {get; set;}

        public int? ThemeId { get; set; }

        public Theme Theme { get; set; }
    }
}
