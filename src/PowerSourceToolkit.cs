using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PowerSource.DataGeneration;

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

        public static string RandomFromArray(string[] array)
        {
            Random r = new Random();
            int rv = r.Next(0, array.Length);
            return array[rv];
        }    
    
        public static UsState UsStateNameToEnum(string state_name)
        {
            KeyValuePair<string, UsState>[] keys = GetUsStateNameEnumConversion();
            foreach (KeyValuePair<string, UsState> kvp in keys)
            {
                if (kvp.Key == state_name)
                {
                    return kvp.Value;
                }
            }
            throw new Exception("State name '" + state_name + "' not recognized.");
        }

        public static String UsStateEnumToName(UsState state)
        {
            KeyValuePair<string, UsState>[] keys = GetUsStateNameEnumConversion();
            foreach (KeyValuePair<string, UsState> kvp in keys)
            {
                if (kvp.Value == state)
                {
                    return kvp.Key;
                }
            }
            throw new Exception("No valid name for state enum value '" + state.ToString() + "'");
        }

        private static KeyValuePair<string, UsState>[] GetUsStateNameEnumConversion()
        {
            List<KeyValuePair<string, UsState>> KVPs = new List<KeyValuePair<string, UsState>>();
            KVPs.Add(new KeyValuePair<string, UsState>("New York", UsState.NewYork));
            KVPs.Add(new KeyValuePair<string, UsState>("California", UsState.California));
            KVPs.Add(new KeyValuePair<string, UsState>("Illinois", UsState.Illinois));
            KVPs.Add(new KeyValuePair<string, UsState>("Florida", UsState.Florida));
            KVPs.Add(new KeyValuePair<string, UsState>("Texas", UsState.Texas));
            KVPs.Add(new KeyValuePair<string, UsState>("Pennsylvania", UsState.Pennsylvania));
            KVPs.Add(new KeyValuePair<string, UsState>("Georgia", UsState.Georgia));
            KVPs.Add(new KeyValuePair<string, UsState>("District of Columbia", UsState.DistrictOfColumbia));
            KVPs.Add(new KeyValuePair<string, UsState>("Massachusetts", UsState.Massachusetts));
            KVPs.Add(new KeyValuePair<string, UsState>("Arizona", UsState.Arizona));
            KVPs.Add(new KeyValuePair<string, UsState>("Washington", UsState.Washington));
            KVPs.Add(new KeyValuePair<string, UsState>("Michigan", UsState.Michigan));
            KVPs.Add(new KeyValuePair<string, UsState>("Minnesota", UsState.Michigan));
            KVPs.Add(new KeyValuePair<string, UsState>("Colorado", UsState.Colorado));
            KVPs.Add(new KeyValuePair<string, UsState>("Maryland", UsState.Maryland));
            KVPs.Add(new KeyValuePair<string, UsState>("Nevada", UsState.Nevada));
            KVPs.Add(new KeyValuePair<string, UsState>("Oregon", UsState.Oregon));
            KVPs.Add(new KeyValuePair<string, UsState>("Missouri", UsState.Missouri));
            KVPs.Add(new KeyValuePair<string, UsState>("Ohio", UsState.Ohio));
            KVPs.Add(new KeyValuePair<string, UsState>("Indiana", UsState.Indiana));
            KVPs.Add(new KeyValuePair<string, UsState>("North Carolina", UsState.NorthCarolina));
            KVPs.Add(new KeyValuePair<string, UsState>("Virginia", UsState.Virginia));
            KVPs.Add(new KeyValuePair<string, UsState>("Wisconsin", UsState.Wisconsin));
            KVPs.Add(new KeyValuePair<string, UsState>("Rhode Island", UsState.RhodeIsland));
            KVPs.Add(new KeyValuePair<string, UsState>("Utah", UsState.Utah));
            KVPs.Add(new KeyValuePair<string, UsState>("Tennessee", UsState.Tennessee));
            KVPs.Add(new KeyValuePair<string, UsState>("Louisiana", UsState.Louisiana));
            KVPs.Add(new KeyValuePair<string, UsState>("Kentucky", UsState.Kentucky));
            KVPs.Add(new KeyValuePair<string, UsState>("Oklahoma", UsState.Oklahoma));
            KVPs.Add(new KeyValuePair<string, UsState>("Connecticut", UsState.Connecticut));
            KVPs.Add(new KeyValuePair<string, UsState>("Nebraska", UsState.Nebraska));
            KVPs.Add(new KeyValuePair<string, UsState>("Hawaii", UsState.Hawaii));
            KVPs.Add(new KeyValuePair<string, UsState>("New Mexico", UsState.NewMexico));
            KVPs.Add(new KeyValuePair<string, UsState>("Alabama", UsState.Alabama));
            KVPs.Add(new KeyValuePair<string, UsState>("South Carolina", UsState.SouthCarolina));
            KVPs.Add(new KeyValuePair<string, UsState>("Kansas", UsState.Kansas));
            KVPs.Add(new KeyValuePair<string, UsState>("Iowa", UsState.Iowa));
            KVPs.Add(new KeyValuePair<string, UsState>("Arkansas", UsState.Arkansas));
            KVPs.Add(new KeyValuePair<string, UsState>("Idaho", UsState.Idaho));
            KVPs.Add(new KeyValuePair<string, UsState>("Mississippi", UsState.Mississippi));
            KVPs.Add(new KeyValuePair<string, UsState>("Puerto Rico", UsState.PuertoRico));
            KVPs.Add(new KeyValuePair<string, UsState>("New Jersey", UsState.NewJersey));
            KVPs.Add(new KeyValuePair<string, UsState>("Alaska", UsState.Alaska));
            KVPs.Add(new KeyValuePair<string, UsState>("New Hampshire", UsState.NewHampshire));
            KVPs.Add(new KeyValuePair<string, UsState>("North Dakota", UsState.NorthDakota));
            KVPs.Add(new KeyValuePair<string, UsState>("Maine", UsState.Maine));
            KVPs.Add(new KeyValuePair<string, UsState>("South Dakota", UsState.SouthDakota));
            KVPs.Add(new KeyValuePair<string, UsState>("West Virginia", UsState.WestVirginia));
            KVPs.Add(new KeyValuePair<string, UsState>("Montana", UsState.Montana));
            KVPs.Add(new KeyValuePair<string, UsState>("Delaware", UsState.Delaware));
            KVPs.Add(new KeyValuePair<string, UsState>("Vermont", UsState.Vermont));
            KVPs.Add(new KeyValuePair<string, UsState>("Wyoming", UsState.Wyoming));

            return KVPs.ToArray();
        }
    }
}