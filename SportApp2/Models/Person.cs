using System;
using System.Collections.Generic;

#nullable disable

namespace SportApp2.Models
{
    public partial class Person
    {
        public Person()
        {
            Exams = new HashSet<Exam>();
        }

        public long Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Uniquecode { get; set; }
        public double? Weight { get; set; }
        public long? Height { get; set; }
        public long? BatcheId { get; set; }
        public long? PeriodId { get; set; }
        public long? Age { get; set; }
        public long? GroupId { get; set; }
        public long? SubgroupId { get; set; }

        public virtual Batch Batche { get; set; }
        public virtual Group Group { get; set; }
        public virtual Period Period { get; set; }
        public virtual Subgroup Subgroup { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
