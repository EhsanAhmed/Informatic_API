using Informatic_API.Models;
using System.Collections.Generic;

namespace Informatic_API.Interfaces
{
    public interface IRepository
    {
        List<PhoneNumber> GetAll();
        PhoneNumber GetOneByPhoneNumber(string PhoneNum);
        List<PhoneNumber> GetByName(string Name);
        void Insert(PhoneNumber entity);
        void Update(string PhoneNum, PhoneNumber entity);
        void Delete(string PhoneNum);
       
    }
}
