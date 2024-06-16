using Microsoft.EntityFrameworkCore;
using question_app.Models;
public class AppDbContext : DbContext
{

    public DbSet<UserModel> Users { get; set; }
    public DbSet<SurveyHeadModel> Survays { get; set; }
    public DbSet<QuestionModel> Questions { get; set; }
    public DbSet<SurvayAnswersModel> SurvayAnswers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}