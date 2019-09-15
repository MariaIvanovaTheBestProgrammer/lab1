using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Teacher : Person
    {
        public string Teach()
        {
            return "i'm teaching";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Teacher ");
            sb.Append(firstName);
            sb.Append(lastName);
            sb.Append(Environment.NewLine);
            sb.Append("{\"firstName\":\"");
            sb.Append(firstName);
            sb.Append("\",");
            sb.Append(Environment.NewLine);
            sb.Append("\"lastName\":\"");
            sb.Append(lastName);
            sb.Append("\"};");
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
