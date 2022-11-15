using System;
using System.Collections.Generic;

#nullable disable

namespace SportApp2.Models
{
    public partial class Exam
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public long? RunMinute { get; set; }
        public long? RunSecond { get; set; }
        public long? Swim { get; set; }
        public long? Situp { get; set; }
        public long? Barfix { get; set; }
        public double? Score { get; set; }
        public long? PersonId { get; set; }
        public long? ExamtypeId { get; set; }

        public virtual ExamType Examtype { get; set; }
        public virtual Person Person { get; set; }
    }
}
