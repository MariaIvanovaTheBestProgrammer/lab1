using models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace database
{
    public class Storage
    {
        private string filePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\db.txt");
        public Data read()
        {
            Data data = new Data();
            try
            {
                if (!File.Exists(filePath))
                {
                    StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.CreateNew));
                    sw.Close();
                }
                string text = File.ReadAllText(filePath);
                string dataPattern = "\\s*(?<type>\\w+)\\s+\\w+\\s*{(?<data>.*)}\\s*";
                text = Regex.Replace(text, @"\t|\n|\r", "");
                Regex dataRegexp = new Regex(dataPattern);
                foreach (string line in text.Split(';'))
                {
                    Match m = dataRegexp.Match(line);
                    if (m.Success)
                    {
                        string type = m.Groups["type"].Captures[0].Value;
                        string fields = m.Groups["data"].Captures[0].Value;
                        if (type == "Student")
                        {
                            data.addStudent(this.readStudent(fields));
                        }
                        if (type == "Teacher")
                        {
                            data.addTeacher(this.readTeacher(fields));
                        }
                        if (type == "TaxiDriver")
                        {
                            data.addTaxiDriver(this.readTaxiDriver(fields));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            return data;
        }

        private TaxiDriver readTaxiDriver(string data)
        {
            TaxiDriver taxiDriver = new TaxiDriver();
            foreach (string field in data.Split(','))
            {
                string[] keyValue = field.Split(':');
                string fieldName = Regex.Replace(keyValue[0], "\"|\\s", "");
                string fieldValue = Regex.Replace(keyValue[1], "\"", "");
                if (fieldName == "firstName")
                {
                    taxiDriver.firstName = fieldValue;
                }
                if (fieldName == "lastName")
                {
                    taxiDriver.lastName = fieldValue;
                }
            }
            return taxiDriver;
        }

        private Teacher readTeacher(string data)
        {
            Teacher teacher = new Teacher();
            foreach (string field in data.Split(','))
            {
                string[] keyValue = field.Split(':');
                string fieldName = Regex.Replace(keyValue[0], "\"|\\s", "");
                string fieldValue = Regex.Replace(keyValue[1], "\"", "");
                if (fieldName == "firstName")
                {
                    teacher.firstName = fieldValue;
                }
                if (fieldName == "lastName")
                {
                    teacher.lastName = fieldValue;
                }
            }
            return teacher;
        }

        private Student readStudent(string data)
        {
            Student student = new Student();
            foreach (string field in data.Split(','))
            {
                string[] keyValue = field.Split(':');
                string fieldName = Regex.Replace(keyValue[0], "\"|\\s", "");
                string fieldValue = Regex.Replace(keyValue[1], "\"", "");
                if (fieldName == "firstName")
                {
                    student.firstName = fieldValue;
                }
                if (fieldName == "lastName")
                {
                    student.lastName = fieldValue;
                }
                if (fieldName == "hobby")
                {
                    student.hobby = fieldValue;
                }
                if (fieldName == "course")
                {
                    student.course = Convert.ToInt32(fieldValue);
                }
                if (fieldName == "idNumber")
                {
                    student.idNumber = fieldValue;
                }
            }
            return student;
        }

        public void save(Data data)
        { 
            StreamWriter sw;
            try
            {
                if (!File.Exists(filePath))
                {
                    sw = new StreamWriter(new FileStream(filePath, FileMode.CreateNew));
                    sw.Close();
                }
                sw = new StreamWriter(new FileStream(filePath, FileMode.Create));
                for(int i=0; i< data.getStudentsCount(); i++)
                {
                   
                        sw.Write(data.getStudent(i).ToString());
                }
                for (int i = 0; i < data.getTeachersCount(); i++)
                {

                    sw.Write(data.getTeacher(i).ToString());
                }
                for (int i = 0; i < data.getTaxiDriverCount(); i++)
                {

                    sw.Write(data.getTaxiDriver(i).ToString());
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
