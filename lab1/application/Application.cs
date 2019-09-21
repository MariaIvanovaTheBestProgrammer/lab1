using database;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class Application
    {
        public int menu()
        {
            //Console.Clear();
            Console.WriteLine("1 - Додати особу ");
            Console.WriteLine("2 - Знайти всіх студентів, які навчаються на 2му курсі ");
            Console.WriteLine("3 - Вивести список ");
            Console.WriteLine("99 - exit: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void add(Data data)
        {
            Console.Clear();
            Console.WriteLine("1 - Додати студента ");
            Console.WriteLine("2 - Додати вчителя");
            Console.WriteLine("3 - Додати водія ");
            Console.WriteLine("99 - exit: ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1) this.addStudent(data);
            if (op == 2) this.addTeacher(data);
            if (op == 3) this.addDriver(data);
            return;
        }
        public void getSportStudents(Data data)
        {

            for (int i = 0; i < data.getStudentsCount(); i++)
            {
                if (data.getStudent(i).hobby == "sport" && data.getStudent(i).course == 2)
                {
                    Console.Write("| ");
                    Console.Write(i);
                    Console.Write(" | ");
                    Console.Write(data.getStudent(i).firstName);
                    Console.Write(" | ");
                    Console.Write(data.getStudent(i).lastName);
                    Console.Write(" | ");
                    Console.WriteLine(" | ");
                }
            }
        }
        private void addStudent(Data data)
        {
            Console.Clear();
            try
            {
                Student student = new Student();
                Console.Write("Введіть ім'я студента: ");
                student.firstName = Console.ReadLine();
                Console.Write("Введіть прізвище студента: ");
                student.lastName = Console.ReadLine();
                Console.Write("Введіть хобі студента: ");
                student.hobby = Console.ReadLine();
                Console.Write("Введіть курс студента: ");
                student.course = readValidatedInt(1, 6);
                Console.Write("Введіть студентський квиток студента: ");
                student.studentTicket = Console.ReadLine();
                Console.Write("Введіть ID студента: ");
                student.idNumber = Console.ReadLine();
                student.validate();
                data.addStudent(student);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }

        }
        private void addTeacher(Data data)
        {
            Console.Clear();
            Teacher teacher = new Teacher();
            Console.Write("Введіть ім'я вчителя: ");
            teacher.firstName = Console.ReadLine();
            Console.Write("Введіть прізвище вчителя: ");
            teacher.lastName = Console.ReadLine();
            try 
            {
                teacher.validate();
                data.addTeacher(teacher);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        private void addDriver(Data data)
        {
            Console.Clear();
            TaxiDriver taxiDriver = new TaxiDriver();
            Console.Write("Введіть ім'я водія: ");
            taxiDriver.firstName = Console.ReadLine();
            Console.Write("Введіть прізвище водія: ");
            taxiDriver.lastName = Console.ReadLine();
            try
            {
                taxiDriver.validate();
                data.addTaxiDriver(taxiDriver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        
        public void printData(Data data)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("| # |   first name   |  last name |  |");
            Console.WriteLine("------------------------------");
            if (!data.isEmpty())
            {
                int count = 0;
                for (int i = 0; i < data.getStudentsCount(); i++)
                {
                    Console.Write("| ");
                    Console.Write(count++);
                    Console.Write(" | ");
                    Console.Write(data.getStudent(i).firstName);
                    Console.Write(" | ");
                    Console.Write(data.getStudent(i).lastName);
                    Console.Write(" | ");
                    Console.WriteLine(" | ");
                }
                for (int i = 0; i < data.getTeachersCount(); i++)
                {

                    Console.Write("| ");
                    Console.Write(count++);
                    Console.Write(" | ");
                    Console.Write(data.getTeacher(i).firstName);
                    Console.Write(" | ");
                    Console.Write(data.getTeacher(i).lastName);
                    Console.Write(" | ");
                    Console.WriteLine(" | ");
                }
                for (int i = 0; i < data.getTaxiDriverCount(); i++)
                {

                    Console.Write("| ");
                    Console.Write(count++);
                    Console.Write(" | ");
                    Console.Write(data.getTaxiDriver(i).firstName);
                    Console.Write(" | ");
                    Console.Write(data.getTaxiDriver(i).lastName);
                    Console.Write(" | ");
                    Console.WriteLine(" | ");
                }

            }
            Console.Write("Press Eneter key to continue.. ");
            Console.ReadLine();
        }

        private int readValidatedInt(int from, int to)
        {
            int res;
            do
            {
                res = Convert.ToInt32(Console.ReadLine());
            } while (!(res >= from && res <= to));
            return res;
        }
    }
}
