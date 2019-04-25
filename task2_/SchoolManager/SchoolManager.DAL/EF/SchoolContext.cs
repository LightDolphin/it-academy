using System.Data.Entity;
using SchoolManager.DAL.Entities;

namespace SchoolManager.DAL.EF
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        static SchoolContext()
        {
            Database.SetInitializer<SchoolContext>(new SchoolDbInitializer());
        }
        public SchoolContext(string connectionString)
            : base(connectionString)
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
    public class SchoolDbInitializer :  DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext db)
        {
            db.Persons.Add(new Person { Id = 1, FirstName = "Алекесей", LastName = "Бондарчук", MiddleName = "Витальевич", Telephone = "295720402", BirthDay = "01.01.1996", Email = "fantom4igg@gmail.com" });
            db.Persons.Add(new Person { Id = 2, FirstName = "Илья", LastName = "Воронин", MiddleName = "Алексеевич", Telephone = "291111122", BirthDay = "17.06.2005", Email = "Voron@mail.com" });
            db.Persons.Add(new Person { Id = 3, FirstName = "Дмитрий", LastName = "Ляшкин", MiddleName = "Иоанович", Telephone = "291231223", BirthDay = "17.06.2001", Email = "DimaLyaha@mail.com" });
            db.Persons.Add(new Person { Id = 4, FirstName = "Виктор", LastName = "Мышкин", MiddleName = "Дмитриевич", Telephone = "292133635", BirthDay = "12.05.1956", Email = "Mouse@mail.com" });
            db.Persons.Add(new Person { Id = 5, FirstName = "Ян", LastName = "Грибов", MiddleName = "Викторович", Telephone = "253983635", BirthDay = "07.03.1998", Email = "Gribyan@mail.com" });
            db.Persons.Add(new Person { Id = 6, FirstName = "Иоан", LastName = "Федотов", MiddleName = "Басурманович", Telephone = "333538976", BirthDay = "21.08.1990", Email = "Ba_surman@mail.com" });
            base.Seed(db);
        }
    }
    
}
