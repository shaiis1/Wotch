using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wotch___Server.DataProcessBL;

namespace Wotch___Server.Controllers
{
    [Route("Tasks")]
    [ApiController]
    public class ProcessDataController : ControllerBase
    {

        private readonly ILogger<ProcessDataController> _logger;

        public ProcessDataController(ILogger<ProcessDataController> logger)
        {
            _logger = logger;
        }

        [Route("SendProcessData")]
        [HttpPost]
        public IActionResult ProcessData(object obj)
        {
            try
            {
                _logger.LogDebug($"***************** Start SendProcessData ****************");
                RequestQueue.AddToQueue(obj);
                _logger.LogDebug($"***************** Done SendProcessData ****************");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"SendProcessData ERROR: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

    }
}
