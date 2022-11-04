using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]

    public class ClienteController : ControllerBase
    {
        private IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] ClienteRegisterViewModel cliente)
        {
            var response = await _clienteAppService.AddAsync(cliente);
            return Ok(response);
        }

        [HttpPut("update")]

        public async Task<IActionResult> Update([FromBody] UpdateClienteViewModel cliente)
        {
            await _clienteAppService.UpdateAsync(cliente);

            return Ok();
        }


        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            return Ok(_clienteAppService.GetAll());
        }


        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _clienteAppService.GetById(id));
        }


        [HttpDelete("remove/{id:guid}")]

        public async Task<IActionResult> DeleteId(Guid id)
        {
            await _clienteAppService.Remove(id);
            return Ok();
        }
    }
}
