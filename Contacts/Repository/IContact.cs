using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public interface IContact
    {
        void AddContact(Users users);
        List<Users> GetAllConatct();
        Users GetContactByMobileNo(int mobileNo);
    }
}
