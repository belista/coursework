using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class Tourist
    {
        #region Fields
        public int Id { get; set; }
        
        [Display(Name = "Фамилия туриста")]
        public string Surname { get; set; }

        [Display(Name = "Имя туриста")]
        public string Name { get; set; }

        [Display(Name = "Отчество туриста")]
        public string Patronymic { get; set; }

        [Display(Name = "Паспорт")]
        public Passport Passport { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
        #endregion

        #region Relationship
        public List<Voucher> Vouchers { get; set; }
        #endregion
    }
}