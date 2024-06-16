using Microsoft.EntityFrameworkCore;
using question_app.Models;

namespace question_app.Repository;

public interface ISurvayRepository
{
    Task<List<SurveyHeadModel>> GetSurvays();
    Task<SurveyHeadModel> GetSurvayById(int id);
    Task<SurveyHeadModel> CreateSurvay(SurveyHeadModel survay);
    Task<bool> CreateSurveyWithQuestions(SurveyHeadModel survay, List<QuestionModel> questions);
}

public class SurvayRepository : ISurvayRepository
{
    private readonly AppDbContext _context;

    public SurvayRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SurveyHeadModel>> GetSurvays()
    {
        return await _context.Survays.ToListAsync();
    }

    public async Task<SurveyHeadModel> GetSurvayById(int id)
    {
        return await _context.Survays.FirstOrDefaultAsync(s => s.id == id) ?? new SurveyHeadModel();
    }

    public async Task<SurveyHeadModel> CreateSurvay(SurveyHeadModel survay)
    {
        _context.Survays.Add(survay);
        await _context.SaveChangesAsync();
        return survay;
    }

    public async Task<bool> CreateSurveyWithQuestions(SurveyHeadModel survay, List<QuestionModel> questions)
    {

        Guid guid = Guid.NewGuid();

        try
        {
            survay.id = guid.GetHashCode();
            survay.created_at = DateTime.Now;
            survay.user_id = 1234;

            _context.Survays.Add(survay);
            _context.SaveChanges();

            foreach (var question in questions)
            {
                question.id = guid.GetHashCode();
                question.survey_id = survay.id;
                question.created_at = DateTime.Now;
                _context.Questions.Add(question);
            }

            _context.SaveChanges();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }

}