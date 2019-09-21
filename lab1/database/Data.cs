using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class Data
    {
        private int studentCount = 0;
        private int teacherCount = 0;
        private int taxiDriverCount = 0;
        private Student[] students;
        private Teacher[] teachers;
        private TaxiDriver[] taxiDrivers;
        public bool isEmpty()
        {
            return studentCount==0 || teacherCount ==0|| taxiDriverCount==0;
        }
        public Data()
        {
            students = new Student[10];
            teachers = new Teacher[10];
            taxiDrivers = new TaxiDriver[10];
        }

        public void addStudent(Student student)
        {
            students[studentCount] = student;
            studentCount++;
        }
        public Student getStudent(int index)
        {
            return students[index];
        }
        public void clearStudents()
        {
            students = new Student[10];
            studentCount = 0;
        }
        public int getStudentsCount()
        {
            return studentCount;
        }
        public void addTeacher(Teacher teacher)
        {
            teachers[teacherCount] = teacher;
            teacherCount++;
        }
        public Teacher getTeacher(int index)
        {
            return teachers[index];
        }
        public void clearTeachers()
        {
            students = new Student[10];
            studentCount = 0;
        }
        public int getTeachersCount()
        {
            return teacherCount;
        }
        public void addTaxiDriver(TaxiDriver taxiDriver)
        {
            taxiDrivers[taxiDriverCount] = taxiDriver;
            taxiDriverCount++;
        }
        public TaxiDriver getTaxiDriver(int index)
        {
            return taxiDrivers[index];
        }
        public void clearTaxiDrivers()
        {
            taxiDrivers = new TaxiDriver[10];
            taxiDriverCount = 0;
        }
        public int getTaxiDriverCount()
        {
            return taxiDriverCount;
        }
    }
}
