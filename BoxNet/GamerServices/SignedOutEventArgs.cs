﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxNet.GamerServices
{
    public class SignedOutEventArgs
    {
        public SignedInGamer Gamer { get; internal set; }
    }
}
