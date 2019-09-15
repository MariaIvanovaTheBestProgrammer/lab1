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
            Console.WriteLine("2 - Видалити особу ");
            Console.WriteLine("3 - Знайти всіх студентів, які навчаються на 2му курсі ");
            Console.WriteLine("4 - Вивести список ");
            Console.WriteLine("99 - exit: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void add(List list)
        {
            Console.Clear();
            Console.WriteLine("1 - Додати студента ");
            Console.WriteLine("2 - Додати вчителя");
            Console.WriteLine("3 - Додати водія ");
            Console.WriteLine("99 - exit: ");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1) this.addStudent(list);
            if (op == 2) this.addTeacher(list);
            if (op == 3) this.addDriver(list);
            return;
        }
        private void addStudent(List list)
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
                list.pushBack(new Node(student));
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }

        }
        private void addTeacher(List list)
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
                list.pushBack(new Node(teacher));
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        private void addDriver(List list)
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
                list.pushBack(new Node(taxiDriver));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void delPerson(List list)
        {
            Console.Clear();
            Console.Write("Введіть #): ");
            uint index = Convert.ToUInt32(Console.ReadLine());
            list.deleteSymbol(index);
        }
        
        public void printList(List list)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("| # |   first name   |  last name |  |");
            Console.WriteLine("------------------------------");
            if (!list.isEmpty())
            {
                int count = 0;
                foreach (Node node in list)
                {
                    Console.Write("| ");
                    Console.Write(count++);
                    Console.Write(" | ");
                    Console.Write(node.MyPerson.firstName);
                    Console.Write(" | ");
                    Console.Write(node.MyPerson.lastName);
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
