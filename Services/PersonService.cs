using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRestService.Abstract;
using CustomerRestService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerRestService.Services
{
    public class PersonService : IPersonService
    {
        private readonly TestDmpDbContext _db;

        public PersonService(TestDmpDbContext db)
        {
            _db = db;
        }

        public async Task<Person> Get(int id)
        {
            return await _db.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Person> Get()
        {
            return _db.Person.AsEnumerable()?.ToList();
        }

        public async Task<Person> Add(Person person)
        {
            var res = await _db.Person.AddAsync(person);

            await _db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Person> Update(Person person)
        {
            var res = _db.Person.Update(person);

            await _db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _db.Person.FirstOrDefaultAsync(x => x.Id == id);

            _db.Remove(model);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
