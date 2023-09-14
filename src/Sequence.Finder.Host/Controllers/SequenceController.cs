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

        [HttpGet]
        public SequenceResponse Get([FromBody] SequenceRequest request)
        {
            var result =
                _sequenceManager
                    .Handle(request);

            return result;
        }
    }
}