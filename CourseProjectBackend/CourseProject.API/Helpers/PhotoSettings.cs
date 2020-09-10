using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace CourseProject.API.Helpers
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }
        public bool IsSupported(string fileName)
        {
            return AcceptedFileTypes.Any(file => file == Path.GetExtension(fileName).ToLower());
        }
    }
}
