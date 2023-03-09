using ExamSystem_MVC_.Models;

namespace ExamSystem_MVC_.ViewModel
{
    public class HomeVM
    {
        public List<Subject> Subjects { get; set; }
        public List<Question> Questions { get; set; }
    }
}
