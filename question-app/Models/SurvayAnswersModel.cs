using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace question_app.Models;

[Table("survey_answers")]
public class SurvayAnswersModel
{
    [Key]
    [Column("id")]
    public int id { get; set; }
    [Column("survey_id")]
    public int survey_id { get; set; }
    [Column("question_id")]
    public int question_id { get; set; }
    [Column("answer")]
    public string answer { get; set; }
    [Column("created_at")]
    public DateTime created_at { get; set; }

}