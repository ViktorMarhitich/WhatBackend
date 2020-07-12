﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CharlieBackend.Api.Settings
{
    public class AuthOptions
    {
        public const string ISSUER = "CharlieBackend";
        public const string AUDIENCE = "CharlieFrontend";
        const string KEY = "secretsecretsecretsecretsecretsecret";
        public const int LIFETIME = 30;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
