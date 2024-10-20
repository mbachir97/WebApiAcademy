using RepositoryPaternWithUOW.Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RepositoryPaternWithUOW.Core.Model
{
    public class Schedule : Entity
    {

        public ScheduleType ScheduleType { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool TUE { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();


    }
}
