using System.ComponentModel.DataAnnotations;


namespace SchoolManager.BLL.CrossLevelEntities
{
    public class PersonCLE
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
