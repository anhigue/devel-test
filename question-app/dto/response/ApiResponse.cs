using System.Text.Json.Serialization;

namespace question_app.Dto.Response;

public class ApiResponse
{
    public string Message { get; set; }
    public bool IsOk { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Data { get; set; }
}
