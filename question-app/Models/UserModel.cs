using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using question_app.Models;

public class UserModel {

    [Key]
    [Column("id")]
    public int id { get; set; }

    [Required]
    [Column("username")]
    public string username { get; set; }

    [Required]
    [JsonIgnore]
    [Column("pass")]
    public string pass { get; set; }
    
    [Required]
    [Column("email")]
    public string email { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; }

}