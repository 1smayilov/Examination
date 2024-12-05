namespace Exam.Entities;

public class Student : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Grade { get; set; }

    public ICollection<Examination> Examinations { get; set; } 
}

