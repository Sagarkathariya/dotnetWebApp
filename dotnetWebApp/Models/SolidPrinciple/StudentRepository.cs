namespace dotnetWebApp.Models.SolidPrinciple

{
    public class StudentRepository : IStudentRepository
    {

        private readonly RegistrationappContext _registrationappContext; 
        /* public List<Student> StudentList()
        {
            List<Student> s = new()
            {
                new Student { Id=1, Name="Sagar Kathariya", Address="Dhangadhi"},
                new Student { Id=2, Name="Kapil Poudel", Address="KTM"},
                new Student { Id=3, Name="Arjun Rana", Address="Belauri"},
                new Student { Id=4, Name="Nishan Chaudhary", Address="KTM"},
            };
            return s;
        }*/
        public StudentRepository(RegistrationappContext registrationappContext)
        {
            _registrationappContext=registrationappContext;
        }

        public IEnumerable<UserList> GetList()
        {
            var u = _registrationappContext.UserLists.ToList();
     
            return u;
        }


        public UserList GetStudentById(int id)
        {
            var a = _registrationappContext.UserLists.Where(predicate: x => x.UserId == id).First();
            return a;
        }

        public void AddStudent(UserList user)
        {

        }

        public void UpdateStudent(UserList std)
        {
        }
        public void DeleteStudent(int id)
        {
        }
    }
}
