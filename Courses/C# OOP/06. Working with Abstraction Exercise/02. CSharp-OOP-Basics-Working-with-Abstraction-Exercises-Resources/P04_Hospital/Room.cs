using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        private List<string> patients;

        public Room()
        {
            Patients = new List<string>();
        }

        public List<string> Patients { get => patients; set => patients = value; }
    }
}
