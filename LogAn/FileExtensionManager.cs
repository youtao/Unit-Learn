using System;

namespace LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("文件名为空");
            }
            if (fileName.EndsWith(".SLF", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}