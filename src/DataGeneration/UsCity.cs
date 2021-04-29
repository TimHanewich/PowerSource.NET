using System;

namespace PowerSource.DataGeneration
{
    public class UsCity
    {
        public string Name {get; set;}
        public UsState State {get; set;}
        public string StateId {get; set;}
        public string CountyName {get; set;}
        public float Latitude {get; set;}
        public float Longitude {get; set;}
        public int Population {get; set;}
        public int Density {get; set;}
        public int[] ZipCodes {get; set;}
    }
}