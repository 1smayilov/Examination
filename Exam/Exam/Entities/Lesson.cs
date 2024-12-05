namespace Exam.Entities;

public class Lesson : IEntity
{
    public int LessonId { get; set; } 
    public string Name { get; set; }
    public int Grade { get; set; }
    public string TeacherFirstName { get; set; }
    public string TeacherLastName { get; set; }

    public ICollection<Examination> Examinations { get; set; } 
}


