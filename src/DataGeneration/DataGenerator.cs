using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace PowerSource.DataGeneration
{
    public class DataGenerator
    {
        
        #region "Setup"

        //Names
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
        

        //Domains
        public async Task LoadDomainsAsync(Stream file)
        {
            Domain = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        #endregion

        #region "Names"

        private string[] MaleFirstName;
        private string[] FemaleFirstName;
        private string[] LastName;

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
    
        #region "Email"

        private string[] Domain {get; set;}

        //Core
        public string RandomDomain()
        {
            return PowerSourceToolkit.RandomFromArray(Domain);
        }

        public string RandomEmail()
        {
            //Get random first + last name
            string firstname = "";
            string lastname = "";
            try
            {
                firstname = RandomFirstName();
            }
            catch
            {
                throw new Exception("Unable to get random first name to use in random email.");
            }
            try
            {
                lastname = RandomLastName();
            }
            catch
            {
                throw new Exception("Unable to get random last name to use in random email.");
            }

            //Get random domain
            string randomdomain = "";
            try
            {
                randomdomain = RandomDomain();
            }
            catch
            {
                throw new Exception("Unable to get random domain for use in random email.");
            }

            //Email formats
            //0 = first.last@
            //1 = last.first@
            //2 = flast@
            //3 = last.f@
            //4 = lastf@
            //5 = firstl@
            //6 = firstlast@
            
            int rfn = new Random().Next(0, 7);

            //Prepare email part
            string email = "";
            if (rfn == 0)
            {
                email = firstname + "." + lastname;
            }
            else if (rfn == 1)
            {
                email = lastname + "." + firstname;
            }
            else if (rfn == 2)
            {
                email = firstname.Substring(0, 1) + lastname;
            }
            else if (rfn == 3)
            {
                email = lastname + "." + firstname.Substring(0, 1);
            }
            else if (rfn == 4)
            {
                email = lastname + firstname.Substring(0, 1);
            }
            else if (rfn == 5)
            {
                email = firstname + lastname.Substring(0, 1);
            }
            else if (rfn == 6)
            {
                email = firstname + lastname;
            }
            else //random?
            {
                email = firstname.Substring(0, 1) + lastname.Substring(0, 1);
            }

            //Append the domain
            email = email + "@" + randomdomain;

            //Lower
            email = email.ToLower();

            return email;
        }

        #endregion
    
    }
}