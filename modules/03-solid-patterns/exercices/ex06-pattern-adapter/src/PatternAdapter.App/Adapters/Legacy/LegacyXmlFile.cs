using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternAdapter.App.Adapters.Legacy
{
    internal class LegacyXmlFile
    {
        public string Path { get; private set; }
        public LegacyXmlFile(string path) 
        {
            Path = path;
        }

        public string ReadAll()
        {
            if (Path == null || string.IsNullOrWhiteSpace(Path))
            {
                return "";
            }
            else
            {
                return File.ReadAllText(Path, Encoding.UTF8);
            }

        }
    }
}
