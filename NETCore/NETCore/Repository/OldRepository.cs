using Microsoft.EntityFrameworkCore;
using NETCore.Context;
using NETCore.Models;
using NETCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository
{
    public class OldRepository : IOldRepository
    {
        private readonly MyContext myContext;
        public OldRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(string NIK)
        {
            var wantDelete = myContext.Persons.Find(NIK);
            if(wantDelete == null) 
            {
                throw new ArgumentException();
            }
            myContext.Persons.Remove(wantDelete);
            var deleted = myContext.SaveChanges();
            return deleted;
        }

        public IEnumerable<Person> Get()
        {
            if (myContext.Persons.ToList().Count == 0) 
            {
                return null;
            }
            return myContext.Persons.ToList();
        }

        public Person Get(string NIK)
        {
            if (myContext.Persons.Find(NIK) == null)
            {
                return null;
            }
            return myContext.Persons.Find(NIK);
        }

        public int Insert(Person person)
        {
            myContext.Persons.Add(person);
            var insert = myContext.SaveChanges();
            return insert;
        }

        public int Update(Person person)
        {

            myContext.Entry(person).State = EntityState.Modified;
            var update = myContext.SaveChanges();
            return update;
        }
    }
}
