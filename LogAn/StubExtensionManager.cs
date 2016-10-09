namespace LogAn
{
    public class StubExtensionManager : IExtensionManager
    {
        public bool ShouldExtensionBeValid;
        public bool IsValid(string fileName)
        {
            return ShouldExtensionBeValid;
        }
    }
}