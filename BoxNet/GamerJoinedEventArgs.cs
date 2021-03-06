﻿using System;

namespace BoxNet
{
    public class GamerJoinedEventArgs : EventArgs
    {
        public GamerJoinedEventArgs(NetworkGamer gamer)
        {
            this.Gamer = gamer;
        }

        public NetworkGamer Gamer { get; private set; }
    }
}
