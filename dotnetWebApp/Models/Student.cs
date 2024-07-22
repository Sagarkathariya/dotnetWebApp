namespace dotnetWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; //null! is equal to string.empty
        public string Address { get; set; } = string.Empty;
        public string encId { get; set; }=null!;    
    }
}
