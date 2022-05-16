using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public abstract class Teachers
    {
        public string Teachername { get; set; }

        public int Sex { get; set; }

        public int Age { get; set; }

        public string Subject { get; set; }

        public Teachers() { }

        public string ShowInfo()
            => $"Teaches {Subject}.";

        public abstract string Move();
    }
}
