﻿using MilitaryElite.Enums;
using MilitaryElite.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    internal class Mission : IMissions
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            State = State.Finished;
        }

        public override string ToString()
            => $"Code Name: {CodeName} State: {State}";
    }
}
