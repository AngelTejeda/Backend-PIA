﻿using Core.BackEnd;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_Rest.Extensions
{
    public static class ServicesExtensions
    {
        // ExtensionMethod que agrega autenticación mediante Token JWT.
        // La autenticación valida el issuer, la audiencia, el tiempo de expiración y la Singing Key del Token.
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JWTParamethers.issuer,
                        ValidAudience = JWTParamethers.issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTParamethers.key))
                    };
                });
        }
    }
}