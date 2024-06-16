using Microsoft.AspNetCore.Mvc;
using question_app.Constants;
using question_app.Repository;

namespace question_app.Controllers;

public class QuestionController : Controller {

    // include the survay repository 
    // override the constructor to include the survay repository
    private readonly ISurvayRepository _survayRepository;

    public QuestionController(ISurvayRepository survayRepository) {
        _survayRepository = survayRepository;
    }

    public IActionResult Index() {
        
        ViewData["Title"] = ViewConstants.QUESTION_HOME;
        // get all the survays
        var survays = _survayRepository.GetSurvays().Result;

        if (survays.Count != 0) {
            // push the survays to the view
            ViewData["SurveyList"] = survays;
        }

        return View();
    }

    [HttpGet("Question/Preview/{idQuestion}")]
    public IActionResult Preview(string idQuestion) {
        ViewData["Title"] = ViewConstants.QUESTION_HOME + " - " + idQuestion;
        return View();
    }

    public IActionResult Create() {
        ViewData["Title"] = ViewConstants.QUESTION_CREATE;
        return View();
    }
}