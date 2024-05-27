using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Domain.Entities.Concretes
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set;}=DateTime.Now;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
