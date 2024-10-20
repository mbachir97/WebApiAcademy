using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPaternWithUOW.Core.Model
{
    public class Individual : Participant
    {
        public string University { get; set; }
        public int YearOfGraduation { get; set; }
        public bool IsIntern { get; set; }
        public override string ToString()
        {
            return $"{Id}  | {LName}, {FName} | Graduted on ({YearOfGraduation}) From {University}" +
                $"({(IsIntern ? "Internship" : "")})";
        }
    }
}
