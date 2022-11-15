using System;
using System.Collections.Generic;

#nullable disable

namespace SportApp2.Models
{
    public partial class Subgroup
    {
        public Subgroup()
        {
            Batches = new HashSet<Batch>();
            People = new HashSet<Person>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? GroupId { get; set; }
        public long? PeriodId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
