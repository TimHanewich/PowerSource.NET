using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PowerSource.DataGeneration
{
    public class NameGenerator
    {
        private string[] MaleFirstName;
        private string[] FemaleFirstName;
        private string[] LastName;

        public async Task LoadMaleFirstNamesAsync(Stream file)
        {
            MaleFirstName = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        public async Task LoadFemaleFirstNamesAsync(Stream file)
        {
            FemaleFirstName = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        public async Task LoadLastNamesAsync(Stream file)
        {
            LastName = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }
        
        public string RandomMaleFirstName()
        {
            return PowerSourceToolkit.RandomFromArray(MaleFirstName);
        }

        public string RandomFemaleFirstName()
        {
            return PowerSourceToolkit.RandomFromArray(FemaleFirstName);
        }

        public string RandomLastName()
        {
            return PowerSourceToolkit.RandomFromArray(LastName);
        }
    }
}