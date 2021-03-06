using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using TimHanewich.Csv;
using TimHanewich.DataSetManagement;

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

        //Industry/company
        public async Task LoadIndustriesAsync(Stream file)
        {
            Industry = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        public async Task LoadCompaniesAsync(Stream file)
        {
            Company = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        //Urls
        public async Task LoadUrlsAsync(Stream file)
        {
            Url = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        //Cities
        public void LoadCities(string csv_content)
        {
            DataSet ds = DataSet.CreateFromCsvFileContent(csv_content);
            List<UsCity> ToReturn = new List<UsCity>();
            foreach (DataRecord dr in ds.Records)
            {
                UsCity city = new UsCity();
                city.Name = dr.GetDataAttribute("city").Value;
                city.State = PowerSourceToolkit.UsStateNameToEnum(dr.GetDataAttribute("state_name").Value);
                city.StateId = dr.GetDataAttribute("state_id").Value;
                city.CountyName = dr.GetDataAttribute("county_name").Value;
                city.Latitude = Convert.ToSingle(dr.GetDataAttribute("lat").Value);
                city.Longitude = Convert.ToSingle(dr.GetDataAttribute("lng").Value);
                city.Population = Convert.ToInt32(dr.GetDataAttribute("population").Value);
                city.Density = Convert.ToInt32(dr.GetDataAttribute("density").Value);

                //Get zips
                string zips = dr.GetDataAttribute("zips").Value;
                List<string> Splitter = new List<string>();
                Splitter.Add(" ");
                string[] zips_arr = zips.Split(Splitter.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                List<int> ZipsToAtt = new List<int>();
                foreach (string s in zips_arr)
                {
                    ZipsToAtt.Add(Convert.ToInt32(s));
                }
                city.ZipCodes = ZipsToAtt.ToArray();

                ToReturn.Add(city);
            }
            City = ToReturn.ToArray();
        }
        
        //Country
        public async Task LoadCountries(Stream file)
        {
            Country = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
        }

        //Job Title
        public async Task LoadJobTitles(Stream file)
        {
            JobTitle = await PowerSourceToolkit.DelimitedFileToLineArrayAsync(file);
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
    
        #region "Phone"

        public string RandomPhone()
        {
            Random r = new Random();
            string ToReturn = "";
            for (int t = 0; t < 10; t++)
            {
                ToReturn = ToReturn + r.Next(0, 10).ToString();
            }
            return ToReturn;
        }

        public string RandomPhone(int area_code)
        {
            Random r = new Random();
            string ToReturn = area_code.ToString();
            for (int t = 0; t < 7; t++)
            {
                ToReturn = ToReturn + r.Next(0, 10).ToString();
            }
            return ToReturn;
        }

        #endregion

        #region "Primitives"

        public bool RandomBoolean()
        {
            Random r = new Random();
            int val = r.Next(0, 2);
            if (val == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public float RandomFloat(float min, float max)
        {

            //Error check
            if (max <= min)
            {
                throw new Exception("Max value was incorrect");
            }
            double randpercent = new Random().NextDouble();

            float thick = max - min;
            float myval = Convert.ToSingle(min + (randpercent * thick));
            return myval;
        }

        public DateTime RandomDateTime(DateTime min, DateTime max)
        {
            //Error check
            if (max <= min)
            {
                throw new Exception("Max DateTime was before Min Datetime");
            }

            long thick = max.Ticks - min.Ticks;
            double rp = new Random().NextDouble();
            long ToReturnTick = min.Ticks + Convert.ToInt64(thick * rp);
            DateTime ToReturn = new DateTime(ToReturnTick);
            return ToReturn;
        }

        #endregion
    
        #region "Industy/Companies"

        private string[] Industry;
        private string[] Company;

        public string RandomIndustry()
        {
            return PowerSourceToolkit.RandomFromArray(Industry);
        }

        public string RandomCompany()
        {
            return PowerSourceToolkit.RandomFromArray(Company);
        }

        #endregion
    
        #region "Url"

        private string[] Url;

        public string RandomUrl()
        {
            return PowerSourceToolkit.RandomFromArray(Url);
        }

        #endregion
    
        #region "State/Cities/Countries"

        private UsCity[] City;
        private string[] Country;

        public UsCity RandomUsCity()
        {
            if (City == null)
            {
                throw new Exception("City data has not been loaded.");
            }

            int r = new Random().Next(0, City.Length);
            return City[r];
        }

        public UsCity RandomUsCity(UsState in_state)
        {
            List<UsCity> CitiesInThisState = new List<UsCity>();
            foreach (UsCity city in City)
            {
                if (city.State == in_state)
                {
                    CitiesInThisState.Add(city);
                }
            }

            int r = new Random().Next(0, CitiesInThisState.Count);
            return CitiesInThisState[r];
        }

        public string RandomUsState()
        {
            List<string> AllStates = new List<string>();
            foreach (UsState state in Enum.GetValues(typeof(UsState)))
            {
                AllStates.Add(PowerSourceToolkit.UsStateEnumToName(state));
            }
            int r = new Random().Next(0, AllStates.Count);
            return AllStates[r];
        }

        public string RandomCountry()
        {
            return PowerSourceToolkit.RandomFromArray(Country);
        }

        #endregion
    
        #region "Job Titles"

        private string[] JobTitle;

        public string RandomJobTitle()
        {
            return PowerSourceToolkit.RandomFromArray(JobTitle);
        }

        #endregion
    }
}