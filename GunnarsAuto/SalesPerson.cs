using System;
using System.Collections.Generic;
using System.Text;

namespace GunnarsAuto
{
    public class SalesPerson
    {
        public int salesPersonId;
        public string firstname;
        public string lastname;
        public string initials;
        public SalesPerson(int salesPersonId, string firstname, string lastname, string initials)
        {
            SalesPersonId = salesPersonId;
            Firstname = firstname;
            Lastname = lastname;
            Initials = initials;
        }
        public int SalesPersonId { get { return salesPersonId; } set { salesPersonId = value; } }
        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Initials { get { return initials; } set { initials = value; } }
    }  
}