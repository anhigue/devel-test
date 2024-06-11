using Microsoft.AspNetCore.Mvc;
using question_app.Constants;

namespace question_app.Controllers;

public class QuestionController : Controller {

    public IActionResult Index() {
        ViewData["Title"] = ViewConstants.QUESTION_HOME;
        return View();
    }

    [HttpGet("Question/Details/{idQuestion}")]
    public IActionResult Details(string idQuestion) {
        ViewData["Title"] = ViewConstants.QUESTION_HOME + " - " + idQuestion;
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

    [HttpPut]
    [Route("rest/edit")]
    public IActionResult Edit() {
        return View();
    }
}