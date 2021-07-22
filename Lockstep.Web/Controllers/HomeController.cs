using Lockstep.Domain.DAO.Common;
using Lockstep.Web.CQRS.Commands;
using Lockstep.Web.CQRS.Queries;
using Lockstep.Web.Hubs;
using Lockstep.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SiteConfig _siteConfig;
        private readonly IMediator _mediator;
        private readonly IHubContext<ChatHub> _hub;

        public HomeController(ILogger<HomeController> logger, 
            IHttpClientFactory httpClientFactory, 
            IOptions<SiteConfig> options, 
            IConfiguration config,
            IMediator mediator,
            IHubContext<ChatHub> hub)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _siteConfig = options.Value;
            _mediator = mediator;
            _hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }
        //=========================================================================
        // Перенести на контроллер AUTHOR
        [HttpPost]
        public async Task<ActionResult> CreateAsync (CreateAuthorCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorByIdAsync(int id)
        {
            var customer = await _mediator.Send(new GetAuthorByIdQuery { Id = id });
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllAuthorQuery()));
        }

        //=========================================================================

        public async Task<IActionResult> PrivacyAsync()
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", "site", "hello");
            return View();
        }
        private async Task<string> GetAsync(string url, Dictionary<string, string> @params, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(1);
            client.BaseAddress = new Uri(url);
            var httpResponse = await client.GetAsync(url, cancellationToken);
            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new NullReferenceException("invalid response");
                //return string.Empty;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
