using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;

        public LogAnalyzer()
        {
            manager = new FileExtensionManager();
        }

        public LogAnalyzer(IExtensionManager manager)
        {
            this.manager = manager;
        }

        public bool WasLastFileNameValid { get; private set; }

        public bool IsValidLogFileName(string fileName)
        {
            this.WasLastFileNameValid = manager.IsValid(fileName);
            return this.WasLastFileNameValid;
        }
    }
}
