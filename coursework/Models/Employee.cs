using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Employee
    {
        #region Fields
        public int Id { get; set; }
        
        public string Surname { get; set; }
        
        public string Name { get; set; }
        
        public string Patronymic { get; set; }

        public Passport Passport { get; set; }

        public string Position { get; set; }

        public string Category { get; set; }
        #endregion


        #region Relationship
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; } 

        public List<Voucher> Vouchers { get; set; }
        #endregion
    }
}