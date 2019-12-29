using _08.MilitaryElite.Contacts;
using _08.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string codeName;
        private State state;

        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName
        {
            get => codeName; 
            private set
            {
                codeName = value;
            }
        }
        public State State
        {
            get => state;  
            private set
            {
                state = value;
            }
        }

        public void CompleteMission()
        {
            State = State.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
