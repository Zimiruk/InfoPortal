﻿using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        int Create(Article article);

        List<Article> GetAll();

        Article Get(int id);

        void Update(Article article);
    }
}
