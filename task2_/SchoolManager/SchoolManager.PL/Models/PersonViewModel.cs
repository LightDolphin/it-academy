using System.ComponentModel.DataAnnotations;

namespace SchoolManager.PL.Models
{
    public class PersonViewModel
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        //[Required(ErrorMessage = "Введите имя")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Минимальная длинна имени - 2 символа, максимальная - 15")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        [UIHint("String")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Введите фамилию")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Минимальная длинна фамилии - 3 символа, максимальная - 30")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        [UIHint("String")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Введите отчество")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Минимальная длинна отчества - 3 символа, максимальная - 30")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        [UIHint("String")]
        public string MiddleName { get; set; }

        //[Required]
        [Display(Name = "Дата рождения")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Некорректная дата рождения. По формату 00.00.0000")]
        [DataType(DataType.Date)]
        [UIHint("String")]
        public string BirthDay { get; set; }

        //[Required]
        [Display(Name = "Email-адрес")]
        [DataType(DataType.EmailAddress)]
        [UIHint("String")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес эл. почты")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Телефон")]
        [RegularExpression(@"[0-9]{9}", ErrorMessage = "Некорректный номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [UIHint("String")]
        public string Telephone { get; set; }
    }
}