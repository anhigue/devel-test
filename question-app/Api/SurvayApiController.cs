
using Microsoft.AspNetCore.Mvc;

namespace question_app.Api;
public class SurvayApiController : Controller
{

    [HttpGet("api/survey/list")]
    public IActionResult getObject()
    {
        return Ok(new
        {
            Name = "John Doe",
            Age = 30
        });
    }

    [HttpPost("api/survey/create")]
    public IActionResult createSurvay([FromBody] Object data)
    {
        return Ok(data);
    }

    [HttpPatch("api/survey/publish/{id}")]
    public IActionResult publishSurvay(string id)
    {
        return Ok(id);
    }

    [HttpPost("api/survey/submit/{idSurvay}")]
    public IActionResult submitSurvay(string idSurvay, [FromBody] Object data)
    {
        return Ok(data);
    }

}