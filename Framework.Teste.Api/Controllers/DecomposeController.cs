using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Teste.Entities.Dtos;
using Framework.Teste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Framework.Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecomposeController : ControllerBase
    {
        private readonly IDecomposeService _decomposeService;

        public DecomposeController(IDecomposeService decomposeService) =>
            _decomposeService = decomposeService;

        [HttpGet("{number}")]
        public async Task<DecomposeNumbers> GetAsync(int number) => await _decomposeService.DecomposeAsync(number);
    }
}