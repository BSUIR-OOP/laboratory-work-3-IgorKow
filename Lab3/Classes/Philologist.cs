using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public class Philologist: Teachers
    {
        public override string Move()
            => $"He can teach not only {Subject}, but also other natural sciences.";
    }
}
