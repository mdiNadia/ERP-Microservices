using Authentication.Domain.Entities;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Authentication.Application.Features.IdentityService.Commands
{
    public class RegisterCommand : IRequest<string>
    {
        public required string Username { get; set; }

        public required string LeadId { get; set; }

        public required string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IIdentityProviderStore _identityProviderStore;

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IIdentityServerInteractionService interaction, IEventService events, IAuthenticationSchemeProvider schemeProvider, IIdentityProviderStore identityProviderStore, IHttpClientFactory httpClientFactory, IConfiguration configuration)
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

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            try
            {
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
