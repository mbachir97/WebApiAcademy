using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Model
{
    public  class Instructor : Entity
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? FullName => FName + " " + LName;
        public int? OfficeId { get; set; }
        public Office? Office {  get; set; }

        public ICollection<Section>? Sections { get; set; } = new List<Section>();
    }
}
