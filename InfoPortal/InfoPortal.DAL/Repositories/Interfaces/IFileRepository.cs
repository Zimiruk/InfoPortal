using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Interfaces
{
    public interface IFileRepository
    {
        void Add(File file);

        public List<File> GetAllByArticleId(int id);
    }
}
