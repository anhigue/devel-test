using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace question_app.Models;

[Table("survey_head")]
public class SurveyHeadModel
{
    [Key]
    [Column("id")]
    public int id { get; set; }
    [Required]
    [Column("user_id")]
    public int user_id { get; set; }

    [Required]
    [Column("title")]
    public string title { get; set; }
    [Column("description")]
    public string description { get; set; }
    [Column("is_in_review")]
    public bool is_in_review { get; set; }
    [Column("created_at")]
    public DateTime created_at { get; set; }

    [ForeignKey("user_id")]
    [NotMapped]
    public UserModel User { get; set; }
}
