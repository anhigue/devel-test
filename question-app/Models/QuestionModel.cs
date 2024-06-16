using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace question_app.Models;  

[Table("survey_questions")]
public class QuestionModel {

    [Key]
    [Column("id")]
    public int id { get; set; }
    [Column("survey_id")]
    public int survey_id { get; set; }
    [Column("question_title")]
    public string question_title { get; set; }
    [Column("question_type")]
    public string question_type { get; set; }
    [Column("is_required")]
    public bool is_required { get; set; }
    [Column("show_question")]
    public bool show_question { get; set; }
    [Column("created_at")]
    public DateTime created_at { get; set; }
}