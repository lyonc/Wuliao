// IdentityModels.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Web;

namespace Wuliao.Disrespect.Web.Models
{
    public class ApplicationUser
    {
        
    }

    public class ApplicationDbContext
    {
        
    }
}

namespace Wuliao.Disrespect.Web
{
    public static class IdentityHelper
    {
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";

        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }
    }
}

