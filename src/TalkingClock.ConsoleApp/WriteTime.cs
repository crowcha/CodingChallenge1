using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkingClock.ConsoleApp
{
    public static class WriteTime
    {
        public static string Run(string timeOutput)
        {
            var builder = new StringBuilder("-----------------------\r\n");
            builder.Append(timeOutput);
            builder.Append("\r\n-----------------------\r\n");
            return builder.ToString();
        }
    }
}
