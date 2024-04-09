

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Authentication.Domain.Entities;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Authentication.Application.Features.IdentityService.Commands
{
    public class LoginCommand : IRequest<LoginResultDto>
    {
        public required string Username { get; set; }


        public required string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IIdentityProviderStore _identityProviderStore;

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IIdentityServerInteractionService interaction, IEventService events, IAuthenticationSchemeProvider schemeProvider, IIdentityProviderStore identityProviderStore, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _events = events;
            _schemeProvider = schemeProvider;
            _identityProviderStore = identityProviderStore;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var address = $"{_configuration["Identity:BaseUrl"]}/connect/token";

                var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = address,
                    ClientId = "CRMClient",
                    ClientSecret = "7e2aadac-5d17-4da4-b662-0d13387fcb2b",
                    UserName = request.Username,
                    Password = request.Password,
                    Scope = "CRMApi offline_access" // Add the "offline_access" scope here
                });

                if (tokenResponse.IsError)
                {
                    // Handle error
                    throw new Exception("نام کاربری یا گذرواژه اشتباه می باشد");
                }

                var accessToken = tokenResponse.AccessToken;
                var refreshToken = tokenResponse.RefreshToken; // Get the refresh token from the token response

                // Process the access token and refresh token as needed
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var model = JsonSerializer.Deserialize<LoginResultDto>(tokenResponse.Raw, options);
                
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}