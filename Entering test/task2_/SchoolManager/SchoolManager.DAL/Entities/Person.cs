using System.ComponentModel.DataAnnotations;

namespace SchoolManager.DAL.Entities
{
    public class Person
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required, StringLength(50, MinimumLength = 5)]
        public string MiddleName { get; set; }
        [StringLength(10)]
        public string BirthDay { get; set; }
        [Required, StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Telephone { get; set; }
    }
}
