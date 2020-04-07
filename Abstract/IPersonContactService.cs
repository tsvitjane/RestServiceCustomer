using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRestService.Entities;

namespace CustomerRestService.Abstract
{
    public interface IPersonContactService
    {
        Task<PersonContact> Get(int id);
        IEnumerable<PersonContact> Get();
        Task<PersonContact> Add(PersonContact personContact);
        Task<PersonContact> Update(PersonContact personContact);
        Task<bool> Delete(int id);
    }
}
