using JobFinder.DataAccess.Contexts;
using JobFinder.DataAccess.Repositories.Abstracts;
using JobFinder.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.DataAccess.Repositories.Concretes
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
        {
        }
    }
}
