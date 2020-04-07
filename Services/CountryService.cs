using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRestService.Abstract;
using CustomerRestService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerRestService.Services
{
    public class CountryService : ICountryService
    {
        private readonly TestDmpDbContext _db;

        public CountryService(TestDmpDbContext db)
        {
            _db = db;
        }

        public async Task<Country> Add(Country country)
        {
            var res = await _db.Country.AddAsync(country);

            await _db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Country> Update(Country country)
        {
            var res = _db.Country.Update(country);

            await _db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(string code)
        {
            var model = await _db.Country.FirstOrDefaultAsync(x => x.Code == code);

            _db.Remove(model);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Country> Get(string code)
        {
            return await _db.Country.FirstOrDefaultAsync(x => x.Code == code);
        }

        public IEnumerable<Country> Get()
        {
            return _db.Country.AsEnumerable()?.ToList();
        }
    }
}
