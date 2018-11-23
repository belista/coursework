using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Organizations
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ChiefFirstName { get; set; }

        public string ChiefFamilyName { get; set; }

        public string ChiefPatronymic { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public int BIC { get; set; }

        public int BankAccount { get; set; }
    }
}