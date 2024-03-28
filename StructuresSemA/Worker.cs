using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StructuresSemA
{
    internal class Worker : IEquatable<Worker>, IComparable<Worker>
    {
        private string name { set; get; }
        private double salary { set; get; }
        public Worker(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public int CompareTo(Worker other)
        {
            if (other == null) return 1;
            return salary.CompareTo(other.salary);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return Equals(obj as Worker);
        }
        public bool Equals(Worker other)
        {
            if (other == null) return false;
            return name == other.name && salary == other.salary;
        }
        public override string ToString()
        {
            return $"Name: {name}, salary: {salary}";
        }
    }
}
