using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CalculationService.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculationController : ControllerBase
{
    private static readonly RestClient AddRestClient = new RestClient("http://localhost:5001/");
    private static readonly RestClient SubtractRestClient = new RestClient("http://localhost:5002/");
        
        
    [HttpPost("Calculate")]
    public async Task<IActionResult> Calculate(string operation, double operand1, double operand2)
    {
        var addTask = AddRestClient.PostAsync(new RestRequest("Add" + operand1 + operand2));
        var subtractTask = SubtractRestClient.PostAsync(new RestRequest("Subtract" + operand1 + operand2));        
        RestResponse result;
        switch (operation)
        {
            case "add":
                result = await addTask;
                break;
            case "subtract":
                result = await subtractTask;
                break;
            default:
                return BadRequest(new { message = "Invalid operation" });
        }
        return Ok(new {result});
    }

}