using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifier
{
    class Document
    {
        public string Class { get; set; }

        public Dictionary<string, double> Terms;

        public Document(string @class, string docName)
        {
            Class = @class;
            Terms = new Dictionary<string, double>();

            using (StreamReader reader = new StreamReader(docName))
            {
                while(!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split('=');

                    Terms.Add(line[0], Convert.ToDouble(line[1]));
                }
            }
        }
    }
}
