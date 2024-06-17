
using Microsoft.AspNetCore.Mvc;
using question_app.Dto.Request;
using question_app.Models;
using question_app.Repository;

namespace question_app.Api;

[Route("api/survey")]
[ApiController]
public class SurvayApiController : Controller
{

    private readonly ISurvayRepository _survayRepository;

    public SurvayApiController(ISurvayRepository survayRepository)
    {
        _survayRepository = survayRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] SurveyCreateRequest data)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (data == null)
        {
            return BadRequest("Request data is null");
        }

        Console.WriteLine(data.survayTitle);
        Console.WriteLine(data.survayDescription);

        if (string.IsNullOrEmpty(data.survayTitle))
        {
            return BadRequest("Survey title and description are required");
        }

        if (data.questions == null || !data.questions.Any())
        {
            return BadRequest("At least one question is required");
        }

        Console.WriteLine("Create survey");
        Console.WriteLine(data.ToString());

        SurveyHeadModel survey = new SurveyHeadModel
        {
            title = data.survayTitle,
            description = data.survayDescription ?? "",
            created_at = DateTime.Now // assuming this field exists
        };

        List<QuestionModel> questions = new List<QuestionModel>();

        foreach (var question in data.questions)
        {
            if (string.IsNullOrEmpty(question.title) || string.IsNullOrEmpty(question.type))
            {
                return BadRequest("Each question must have a question text, type, and isRequired value");
            }

            QuestionModel q = new QuestionModel
            {
                question_title = question.title,
                question_type = question.type,
                is_required = question.isRequired,
                created_at = DateTime.Now
            };

            questions.Add(q);
        }

        bool Result = await _survayRepository.CreateSurveyWithQuestions(survey, questions);

        return Result ? Ok("Survey created successfully") : BadRequest("Failed to create survey");
    }

    [HttpPatch("publish/{id}")]
    public async Task<IActionResult> publishSurvay(string id)
    {

        bool Result;

        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Survey id is required");
        }

        try
        {
            int survayId = int.Parse(id);
            Result = await _survayRepository.publishSurvey(survayId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest("Failed to publish survey");
        }

        return Result ? Ok("Survey published successfully") : BadRequest("Failed to publish survey");
    }

}