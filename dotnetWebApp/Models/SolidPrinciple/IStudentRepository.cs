namespace dotnetWebApp.Models.SolidPrinciple
{
    public interface IStudentRepository
    {
        IEnumerable<UserList> GetList();
        UserList GetStudentById(int id);
        void AddStudent(UserList std);
        void UpdateStudent(UserList std);
        void DeleteStudent(int id);
    }
}
