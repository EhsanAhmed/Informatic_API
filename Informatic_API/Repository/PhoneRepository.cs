using Informatic_API.Interfaces;
using Informatic_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Informatic_API.Repository
{
    public class PhoneRepository : IRepository
    {
        private readonly Context context;
        public PhoneRepository(Context _Context)
        {
            context = _Context;
        }

        public void Delete(string PhoneNum)
        {
            PhoneNumber phone = context.phoneNumbers.FirstOrDefault(p => p.Phone_Number == PhoneNum);
            context.phoneNumbers.Remove(phone);
            context.SaveChanges();
        }

        public List<PhoneNumber> GetAll()
        {
            List<PhoneNumber> phones = context.phoneNumbers.ToList();
            return phones;
        }

        public PhoneNumber GetOneByPhoneNumber(string PhoneNum)
        {
            PhoneNumber phone = context.phoneNumbers.FirstOrDefault(p=> p.Phone_Number == PhoneNum);
            return phone;
        }
        public List<PhoneNumber> GetByName(string Name)
        {
            List<PhoneNumber> phones = context.phoneNumbers.Where(p => p.Name == Name).ToList();
            return phones;
        }
        
        public void Insert(PhoneNumber entity)
        {
            PhoneNumber phone = new PhoneNumber();
            phone.Name = entity.Name;
            phone.Phone_Number = entity.Phone_Number;

            context.phoneNumbers.Add(phone);
            context.SaveChanges();
        }

        public void Update(string PhoneNum, PhoneNumber entity)
        {
            PhoneNumber phone = context.phoneNumbers.FirstOrDefault(p => p.Phone_Number ==PhoneNum);
            phone.Name = entity.Name;
            phone.Phone_Number =entity.Phone_Number;
            context.SaveChanges();
        }
    }
}
