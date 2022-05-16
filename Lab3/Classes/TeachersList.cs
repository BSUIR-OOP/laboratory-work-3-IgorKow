using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3.Classes
{
    public class TeachersList: IEnumerable
    {
        private List<Teachers> teachers = new List<Teachers>();

        public int Count
            => teachers.Count;

        public void Add(Teachers t)
            => teachers.Add(t);

        public void Remove(Teachers t)
            => teachers.Remove(t);

        public List<Teachers> GetTransports()
            => teachers;

        public Teachers Get(int index)
            => teachers[index];

        public IEnumerator GetEnumerator()
            => teachers.GetEnumerator();
    }
}
