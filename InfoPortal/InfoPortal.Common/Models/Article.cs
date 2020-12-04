using System;
using System.Collections.Generic;

namespace InfoPortal.Common.Models
{
    public class Article : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Theme { get; set; }

        public DateTime AddedOn { get; set; }

        public string Language { get; set; }

        public int Link { get; set; }

        public List<File> Files {get; set;}
    }
}
