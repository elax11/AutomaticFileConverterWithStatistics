namespace FirstRadencyTask
{
    public class CheckFileType : ICheckFileType
    {
        public void CheckType(string filePath)
        {
            var type = "";
            if (filePath.Substring(filePath.Length - 3) == "txt") type = "txt";
            if (filePath.Substring(filePath.Length - 3) == "scv") type = "scv";
            Console.WriteLine(type);
        }
    }
}
