using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RepositoryPaternWithUOW.Core.Model.Enum
{
    public enum ScheduleType
    {

        Daily,
        DayAfterDay,
        TwiceAWeek,
        Weekend,
        Compact,
    }
}
