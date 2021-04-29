using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PowerSource.DataGeneration
{
    public class NameGenerator
    {
        private string[] MaleFirstNames;
        private string[] FemaleFirstName;
        private string[] LastNames;

        public async Task LoadMaleFirstNamesAsync(Stream file)
        {
            MaleFirstNames = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        public async Task LoadFemaleFirstNamesAsync(Stream file)
        {
            FemaleFirstName = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        public async Task LoadLastNamesAsync(Stream file)
        {
            LastNames = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }
        
    }
}