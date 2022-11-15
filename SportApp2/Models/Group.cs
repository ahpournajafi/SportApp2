using System;
using System.Collections.Generic;

#nullable disable

namespace SportApp2.Models
{
    public partial class Group
    {
        public Group()
        {
            Batches = new HashSet<Batch>();
            People = new HashSet<Person>();
            Periods = new HashSet<Period>();
            Subgroups = new HashSet<Subgroup>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Period> Periods { get; set; }
        public virtual ICollection<Subgroup> Subgroups { get; set; }
    }
}
