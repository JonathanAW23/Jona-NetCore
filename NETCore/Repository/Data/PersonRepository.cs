using NETCore.Context;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, string>
    {
        private readonly MyContext myContext;
        public PersonRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public IEnumerable<GetPersonVM> GetPersonVMs() 
        {
            var getPersonVMs = (from p in myContext.Persons
                                 join a in myContext.Accounts on p.NIK equals a.NIK
                                 join pr in myContext.Profilings on a.NIK equals pr.NIK
                                 join e in myContext.Educations on pr.Education_Id equals e.Id
                                 select new GetPersonVM
                                {
                                    NIK = p.NIK,
                                    FullName = p.FirstName +" "+ p.LastName,
                                    Phone = p.Phone,
                                    BirthDate = p.BirthDate,
                                    Salary = p.Salary,
                                    Email = p.Email,
                                    gender = (GetPersonVM.Gender)p.gender,
                                    Password = "***********************",
                                    Degree = e.Degree,
                                    GPA = e.GPA
                                }).ToList();
            if (getPersonVMs.Count == 0)
            {
                return null;
            }
            return getPersonVMs;
        }
        public IEnumerable<GetPersonVM> GetPersonVMsNIK(string NIK)
        {
            var getPersonVMsNIK = (from p in myContext.Persons
                                join a in myContext.Accounts on p.NIK equals a.NIK
                                join pr in myContext.Profilings on a.NIK equals pr.NIK
                                join e in myContext.Educations on pr.Education_Id equals e.Id
                                where p.NIK == NIK
                                select new GetPersonVM
                                {
                                    NIK = p.NIK,
                                    FullName = p.FirstName + " " + p.LastName,
                                    Phone = p.Phone,
                                    BirthDate = p.BirthDate,
                                    Salary = p.Salary,
                                    Email = p.Email,
                                    gender = (GetPersonVM.Gender)p.gender,
                                    Password = "***********************",
                                    Degree = e.Degree,
                                    GPA = e.GPA
                                }).ToList();
            if (getPersonVMsNIK.Count == 0)
            {
                return null;
            }
            return getPersonVMsNIK;
        }
        public int InsertPerson(GetPersonVM getPersonVM)
        {
            Person person = new Person();
            person.NIK = getPersonVM.NIK;
            string[] name = getPersonVM.FullName.Split(' ');
            person.FirstName = name[0];
            string lastName = "";
            for (int i = 1; i < name.Length; i++) 
            {
                lastName += name[i];
                if (i < name.Length - 1) 
                {
                    lastName += " ";
                }
            }
            person.LastName = lastName;
            person.Phone = getPersonVM.Phone;
            person.BirthDate = getPersonVM.BirthDate;
            person.Salary = getPersonVM.Salary;
            person.Email = getPersonVM.Email;
            person.gender = (Person.Gender)getPersonVM.gender;
            myContext.Persons.Add(person);

            Account account = new Account();
            account.NIK = getPersonVM.NIK;
            account.Password = BCrypt.Net.BCrypt.HashPassword(getPersonVM.Password);
            myContext.Accounts.Add(account);

            Education education = new Education();
            education.Degree = getPersonVM.Degree;
            education.GPA = getPersonVM.GPA;
            education.University_Id = 1;
            myContext.Educations.Add(education);
            myContext.SaveChanges();

            Profiling profiling = new Profiling();
            profiling.NIK = getPersonVM.NIK;
            profiling.Education_Id = education.Id;
            myContext.Profilings.Add(profiling);
            var insert = myContext.SaveChanges();
            return insert;
        }
        public bool CheckPersonVMEmail(string Email)
        {
            var checkPersonVMEmail = (from p in myContext.Persons where p.Email == Email select new GetPersonVM { }).ToList();
            if (checkPersonVMEmail.Count == 0)
                return true;
            return false;
        }
        public bool CheckPersonVMPhone(string Phone)
        {
            var checkPersonVMPhone = (from p in myContext.Persons where p.Phone == Phone select new GetPersonVM { }).ToList();
            if (checkPersonVMPhone.Count == 0)
                return true;
            return false;
        }
    }
}
