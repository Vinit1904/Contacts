using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Contacts.Model
{
    [DataContract]
    public class Address
    {
       
        public int AddressId { get; set; }
        [DataMember]
        public int HouseNo { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}
