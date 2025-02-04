using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class TxtLog:ILog
    {
        private string filePath;

        public TxtLog(string filePath)
        {
            filePath = filePath;
        }
        public void Log(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
