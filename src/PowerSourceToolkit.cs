using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PowerSource
{
    public class PowerSourceToolkit
    {
        public static async Task<string[]> DelimitedFileToLineArrayAsync(Stream file_stream)
        {
            List<string> ToReturn = new List<string>();
            StreamReader sr = new StreamReader(file_stream);
            while (sr.EndOfStream == false)
            {
                string this_line = await sr.ReadLineAsync();
                if (this_line != null)
                {
                    ToReturn.Add(this_line);
                }
            }
            return ToReturn.ToArray();
        }
    }
}