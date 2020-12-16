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
    }
}
