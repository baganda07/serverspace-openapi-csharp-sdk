using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Serverspace.OpenApiTests
{
    public class ResponceFile
    {
        public static string GetFile(string name)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(dir, "JsonResponce", name);
            if (!File.Exists(path))
                throw new Exception($"File {path} doesn't exist");
            return File.ReadAllText(path);
        }
    }
}
