using Microsoft.EntityFrameworkCore;
using question_app.Models;

namespace question_app.Repository;

public interface ISurvayRepository
{
    Task<List<SurveyHeadModel>> GetSurvays();
    Task<SurveyHeadModel> GetSurvayById(int id);
    Task<bool> CreateSurveyWithQuestions(SurveyHeadModel survay, List<QuestionModel> questions);
    Task<bool> publishSurvey(int survayId);
    Task<List<QuestionModel>> GetQuestionsBySurveyId(int survayId);
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

    public async Task<bool> CreateSurveyWithQuestions(SurveyHeadModel survay, List<QuestionModel> questions)
    {

        Guid guid = Guid.NewGuid();

        try
        {
            survay.id = guid.GetHashCode();
            survay.created_at = DateTime.Now;
            survay.user_id = 1234;
            survay.is_in_review = true;

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

    public async Task<bool> publishSurvey(int survayId)
    {
        try
        {
            var survay = await _context.Survays.FirstOrDefaultAsync(s => s.id == survayId);

            if (survay == null)
            {
                return false;
            }

            survay.is_in_review = false;

            _context.Survays.Update(survay);
            _context.SaveChanges();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }

    public async Task<List<QuestionModel>> GetQuestionsBySurveyId(int survayId)
    {
        List<QuestionModel> questions = new List<QuestionModel>();
        
        try
        {
            questions = await _context.Questions.AsNoTracking().Where(
                // use the survay id to get the questions
                // use the absolute value of the hash code to get the id
                q => Math.Abs(q.survey_id) == survayId
            ).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return questions;
    }

}