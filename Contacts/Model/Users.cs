using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Contacts.Model
{
    [DataContract]
    public class Users
    {
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int MobileNo { get; set; }
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public Address address{ get; set; }

    }
}
