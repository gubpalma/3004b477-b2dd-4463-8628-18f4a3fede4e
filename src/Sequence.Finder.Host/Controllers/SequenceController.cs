using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sequence.Finder.Contracts;
using Sequence.Finder.Interfaces;

namespace Sequence.Finder.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SequenceController : ControllerBase
    {
        private readonly ISequenceManager _sequenceManager;
        private readonly ILogger<SequenceController> _logger;

        public SequenceController(
            ISequenceManager sequenceManager, 
            ILogger<SequenceController> logger)
        {
            _sequenceManager = sequenceManager;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SequenceRequest request)
        {
            try
            {
                var result =
                    _sequenceManager
                        .Handle(request);

                return 
                    new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                var result =
                    new SequenceResponse
                    {
                        Error = ex.Message
                    };

                return 
                    new BadRequestObjectResult(result);
            }
        }
    }
}