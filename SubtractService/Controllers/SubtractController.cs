using Microsoft.AspNetCore.Mvc;
using Monitoring;

namespace SubtractService.Controllers;

[ApiController]
[Route("[controller]")]
public class SubtractController : ControllerBase
{
    public class SubtractRequest
    {
        public float Operand1 { get; set; }
        public float Operand2 { get; set; }
    }

    [HttpPost]
    public IActionResult Subtract(SubtractRequest request)
    {
        using var activity = MonitorService.ActivitySource.StartActivity();
        MonitorService.Log.Debug("Calling Subtract Service");
        
        float result = request.Operand1 - request.Operand2;
        return Ok(new { result = result });
    }
}