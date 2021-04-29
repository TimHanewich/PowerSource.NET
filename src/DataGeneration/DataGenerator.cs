using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace PowerSource.DataGeneration
{
    public class DataGenerator
    {
        private string[] MaleFirstName;
        private string[] FemaleFirstName;
        private string[] LastName;

        #region "Setup"

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
        
        #endregion

        #region "Names"

        #region  "Core"

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
    
        #endregion
    
        public string RandomFirstName()
        {
            List<string> ToPullFrom = new List<string>();
            if (MaleFirstName != null)
            {
                ToPullFrom.AddRange(MaleFirstName);
            }
            if (FemaleFirstName != null)
            {
                ToPullFrom.AddRange(FemaleFirstName);
            }
            return PowerSourceToolkit.RandomFromArray(ToPullFrom.ToArray());
        }
    
        public string RandomFullName()
        {
            return RandomFirstName() + " " + RandomLastName();
        }

        public string RandomMaleFullName()
        {
            return RandomMaleFirstName() + " " + RandomLastName();
        }

        public string RandomFemaleFullName()
        {
            return RandomFemaleFirstName() + " " + RandomLastName();
        }
    
        #endregion
    }
}