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
        
        [Display(Name = "Название организации")]
        public string Name { get; set; }
        
        [Display(Name = "Имя руководителя")]
        public string ChiefFirstName { get; set; }
        
        [Display(Name = "Фамилия руководителя")]
        public string ChiefFamilyName { get; set; }
        
        [Display(Name = "Отчество руководителя")]
        public string ChiefPatronymic { get; set; }
        
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public int Phone { get; set; }

        [Display(Name = "БИК")]
        public int BIC { get; set; }

        [Display(Name = "Расчетный счет")]
        public int BankAccount { get; set; }
        #endregion

        #region Relationship
        public List<Employee> Employees { get; set; }
        #endregion
    }
}