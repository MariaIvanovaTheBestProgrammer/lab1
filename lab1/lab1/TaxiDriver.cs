using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class TaxiDriver : Person
    {
        public string Drive()
        {
            return "i'm driving";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TaxiDriver ");
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
