﻿
using CRM.API.Filter;

namespace CRM.API.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
