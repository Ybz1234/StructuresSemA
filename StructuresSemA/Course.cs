using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresSemA
{
    internal class Course : IComparable<Course>
    {
        private int code { set; get; }
        public int mark { set; get; }
        public Course(int code, int mark)
        {
            this.code = code;
            this.mark = mark;
        }
        public int CompareTo(Course other)
        {
            if (other == null)
                return 1;

            return mark.CompareTo(other.mark);
        }
        public override string ToString()
        {
            return $"Course code: {code}, mark: {mark}";
        }
    }
}
