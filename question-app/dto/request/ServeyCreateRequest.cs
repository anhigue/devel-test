namespace question_app.Dto.Request;

[Serializable]
public class SurvayQuestionsRequest {
    public string title { get; set; }
    public string type { get; set; }
    public bool isRequired { get; set; }
}

[Serializable]
public class SurveyCreateRequest 
{
    public string survayTitle { get; set; }
    public string survayDescription { get; set; }
    public List<SurvayQuestionsRequest> questions { get; set; }
}