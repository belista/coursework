using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Organization
    {
        #region Fields
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string ChiefFirstName { get; set; }
        
        public string ChiefFamilyName { get; set; }
        
        public string ChiefPatronymic { get; set; }
        
        public string Address { get; set; }

        public int Phone { get; set; }

        public int BIC { get; set; }

        public int BankAccount { get; set; }
        #endregion

        #region Relationship
        public List<Employee> Employees { get; set; }
        #endregion
    }
}