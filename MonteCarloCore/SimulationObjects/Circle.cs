﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public class Circle : SimulationObject

    {
        public Circle()
        {
            Moves.Add(new TranslationMove());
        }

    }
}
