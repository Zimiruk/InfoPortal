﻿using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetArticles();
    }
}
