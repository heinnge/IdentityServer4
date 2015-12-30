﻿using Microsoft.AspNet.Http.Features.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UnitTests.Common
{
    public class StubAuthenticationHandler : IAuthenticationHandler
    {
        public ClaimsPrincipal User { get; set; }
        public string Scheme { get; set; }

        public StubAuthenticationHandler(ClaimsPrincipal user, string scheme)
        {
            User = user;
            Scheme = scheme;
        }

        public Task AuthenticateAsync(AuthenticateContext context)
        {
            if (User == null)
            {
                context.NotAuthenticated();
            }
            else if (Scheme == null || Scheme == context.AuthenticationScheme)
            {
                context.Authenticated(User, new Dictionary<string, string>(), new Dictionary<string, object>());
            }

            return Task.FromResult(0);
        }

        public Task ChallengeAsync(ChallengeContext context)
        {
            return Task.FromResult(0);
        }

        public void GetDescriptions(DescribeSchemesContext context)
        {
        }

        public Task SignInAsync(SignInContext context)
        {
            return Task.FromResult(0);
        }

        public Task SignOutAsync(SignOutContext context)
        {
            return Task.FromResult(0);
        }
    }
}