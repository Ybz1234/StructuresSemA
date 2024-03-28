using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StructuresSemA
{
    internal class Student : IComparable<Student>
    {
        public string name { set; get; }
        private Node<Course> courses { set; get; }
        public Student(string name, Node<Course> courses)
        {
            this.name = name;
            this.courses = courses;
        }
        public int CompareTo(Student other)
        {
            return this.name.CompareTo(other.name);
        }
        public int GetAVG()
        {
            int sum = 0, nodesCounter = 0;
            Node<Course> currentCourse = courses;

            while (currentCourse != null)
            {
                sum += currentCourse.GetValue().mark;
                nodesCounter++;
                currentCourse = currentCourse.GetNext();
            }

            if (nodesCounter != 0) return sum / nodesCounter;
            else return 0;
        }
        public int FailuresCounter()
        {
            int counter = 0;
            Node<Course> courses = this.courses;

            while (courses != null)
            {
                if (courses.GetValue().mark < 56)
                    counter++;

                courses = courses.GetNext();
            }

            return counter;
        }
        public override string ToString()
        {
            return $"Student name: {name}\nCourses:\n{courses}";
        }
    }
}
