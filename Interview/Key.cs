using System.IO;

namespace Interview
{
    public class Key
    {
        public string Name { get; set; }

        public Key()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            Name = path.Substring(0, 2);
        }
    }
}