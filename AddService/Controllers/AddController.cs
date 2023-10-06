using Microsoft.AspNetCore.Mvc;
using Monitoring;

namespace AddService.Controllers;

[ApiController]
[Route("[controller]")]
public class AddController : ControllerBase
{
    public class AddRequest
    {
        public float Operand1 { get; set; }
        public float Operand2 { get; set; }
    }

    [HttpPost]
    public IActionResult Add(AddRequest request)
    {
        using var activity = MonitorService.ActivitySource.StartActivity();
        MonitorService.Log.Debug("Calling Add Service");
        
        float result = request.Operand1 + request.Operand2;
        return Ok(new { result = result });
    }
}