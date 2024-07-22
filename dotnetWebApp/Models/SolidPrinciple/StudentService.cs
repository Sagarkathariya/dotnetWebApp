namespace dotnetWebApp.Models.SolidPrinciple
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository; 
        public StudentService (IStudentRepository repo){
        _studentRepository = repo;
        }
        public IEnumerable<UserList> GetStudents() => _studentRepository.GetList();

        public UserList GetStdById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

         public  void AddStd(UserList std)
        {
            
        }
        public void UpdateStd(UserList std)
        {

        }
        public void DeleteStd(int id)
        {

        }
    }
}
