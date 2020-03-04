using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchemaResearch
{
    static class FileReader
    {
        static public List<List<double>> readFile(string Filename)
        {
            List<List<double>> resultTable = new List<List<double>>();

            FileStream stream = new FileStream(Filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            string streamline;
            int i = 0;
            while ((streamline = reader.ReadLine()) != null)
            {
                string[] tokens = streamline.Split(new[] { "\t" }, StringSplitOptions.None);
                List<double> stringValues = new List<double>();
                foreach (var splitted in tokens)
                {
                    stringValues.Add(double.Parse(splitted));
                }
                resultTable.Add(stringValues);
                i++;
            }
            return resultTable;
        }
    }
}
