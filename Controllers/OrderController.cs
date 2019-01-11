using Elmah.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elmah.Controllers
{
    public class OrderController : ControllerBase
    {
        public OrderController(IService service, ILogger<OrderController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        private readonly IService service;
        private readonly ILogger logger;

        [HttpPost]
        public IActionResult Order1([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                errors.Add("Bad Request for order ({Product}, {Qty})");
                errors.AddRange(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                var errorsMsg = string.Join(" | ", errors);
                logger.LogWarning(errorsMsg, product.Name, product.Quantity);
                return BadRequest(ModelState);
            }

            service.ProcessWithNoError(product);
            logger.LogInformation("Successful Order for ({Product}, {Qty}!", product.Name, product.Quantity);
            return Ok();
        }

        [HttpPost]
        public IActionResult Order2([FromBody]Product product)
        {
            try
            {
                service.ProcessWithError(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex,ex.Message);
                return StatusCode(500, new { Error = ex.Message });
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Order3([FromBody] Product product)
        {
            service.ProcessWithError(product);
            return Ok();
        }
    }
}
