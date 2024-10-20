using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Model
{
    public class Enrollment
    {
        public int SectionId { get; set; }
        public int ParticipantId { get; set; }

        public Section Section { get; set; } = null!;
        public Participant Participant { get; set; } = null!;
    }
}
