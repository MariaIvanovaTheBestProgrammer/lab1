using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class Storage
    {
        private string filePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\db.txt");
        public List read()
        {
            // (\s * (\w +)\s +\w +\s *{ (\s * "(\w+)"\s *\s *:"(\w+)"\s *,\s *)*(\s * "(\w+)"\s *:\s * "(\w+)"\s *)}\s *;)*
            // [А-ЯA-Za-z]{2}[0-9]{4}
            // \s*(\w+)\s+(\w+)\s*
            string line;
            try
            {
                if (!File.Exists(filePath))
                {
                    StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.CreateNew));
                    sw.Close();
                }
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                return new List();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void save(List list)
        {
            string line;
            StreamWriter sw;
            try
            {
                if (!File.Exists(filePath))
                {
                    sw = new StreamWriter(new FileStream(filePath, FileMode.CreateNew));
                    sw.Close();
                }
                sw = new StreamWriter(new FileStream(filePath, FileMode.Create));
                sw.Write("hello world");
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
