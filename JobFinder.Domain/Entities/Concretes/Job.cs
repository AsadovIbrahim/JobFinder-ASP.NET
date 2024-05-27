using JobFinder.Domain.Entities.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Domain.Entities.Concretes
{
    public class Job:Entity
    {
        public string Title { get; set; }
        public string StateType { get; set; }
        public string WorkingSchedule { get; set; }
        public string StandartEntranceProccess { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string VacancyCode { get; set; }
        public string ?VacancyUrl { get; set; }
        public string ProfileRequierments { get; set; }
        public DateTime ExpireDateTime { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }



        //Foreign Key

        public int UserId;
    }
}
