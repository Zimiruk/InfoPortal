using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Implementations
{
    public class FileRepository : IFileRepository
    {
        public SQLDataAccess Access { get; }

        public FileRepository(SQLDataAccess access)
        {
            Access = access;
        }

        public void Create(File file)
        {
           DatabaseCommand.ExecuteNonQueryWithId(file, FileConstants.AddFile, Access.Connection);
        }

        public List<File> GetAllByArticleId(int id)
        {
            return DatabaseCommand.ExecuteListReader<File>(id, FileConstants.GetFilesByArticleId, Access.Connection);
        }
    }
}
