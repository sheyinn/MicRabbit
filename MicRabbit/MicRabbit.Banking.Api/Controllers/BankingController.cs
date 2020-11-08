using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicRabbit.Banking.Application.Interfaces;
using MicRabbit.Banking.Application.Models;
using MicRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IBankingService _bankingService;

        public BankingController(IBankingService bankingService)
        {
            _bankingService = bankingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_bankingService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _bankingService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
