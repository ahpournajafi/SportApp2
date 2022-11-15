using System;
using System.Collections.Generic;

#nullable disable

namespace SportApp2.Models
{
    public partial class Batch
    {
        public Batch()
        {
            People = new HashSet<Person>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? SubgroupId { get; set; }
        public long? GroupId { get; set; }
        public long? PeriodId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Period Period { get; set; }
        public virtual Subgroup Subgroup { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
