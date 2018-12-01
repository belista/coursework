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
        
        [Display(Name = "Фамилия работника")]
        public string Surname { get; set; }
        
        [Display(Name = "Имя работника")]
        public string Name { get; set; }
        
        [Display(Name = "Отчество работника")]
        public string Patronymic { get; set; }

        [Display(Name = "Паспорт")]
        public Passport Passport { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }
        #endregion


        #region Relationship
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; } 

        public List<Voucher> Vouchers { get; set; }
        #endregion
    }
}