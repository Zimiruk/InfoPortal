﻿using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Interfaces
{
    public interface IArticleService
    {
        List<Article> GetArticles();
    }
}
