using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AgencyContext>
    {
        protected override void Seed(AgencyContext context)
        {
            context.Organizations.Add(new Organization { Name = "jjj" });
            context.Countries.Add(new Country { Name = "USA" });
            context.SaveChanges();
        }
    }
}