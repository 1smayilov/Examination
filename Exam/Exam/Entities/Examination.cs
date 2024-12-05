namespace Exam.Entities;
public class Examination : IEntity
{
    public int Id { get; set; }
    public int LessonId { get; set; } 
    public int StudentId { get; set; }
    public DateTime ExamDate { get; set; }
    public int Score { get; set; }

    public Lesson Lesson { get; set; }   
    public Student Student { get; set; } 
}


