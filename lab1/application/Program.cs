using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            Data myData = storage.read();
            Application app = new Application();
            int op;
            do
            {
                op = app.menu();
               if (op == 1)
               {
                    app.add(myData);
               }
               if (op == 2)
               {
                 app.getSportStudents(myData);
               }
               if (op == 3)
               {
                    app.printData(myData);
               }

            } while (op != 99);
            storage.save(myData);
            Console.ReadLine();
        }
    }
}
