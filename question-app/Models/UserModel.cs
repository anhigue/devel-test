using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class UserModel {

    [Key]
    public int id { get; set; }

    [Required]
    public string username { get; set; }

    [Required]
    [JsonIgnore]
    public string pass { get; set; }
    
    [Required]
    public string email { get; set; }

    public DateTime created_at { get; set; }
}