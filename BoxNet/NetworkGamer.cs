﻿using System;
using System.Collections.Generic;
using BoxNet.GamerServices;

namespace BoxNet
{
    internal class NetworkGamerIdComparer : IComparer<NetworkGamer>
    {
        public int Compare(NetworkGamer x, NetworkGamer y)
        {
            return x.id.CompareTo(y.id);
        }

        internal static IComparer<NetworkGamer> Instance = new NetworkGamerIdComparer();
    }

    internal enum NetworkGamerState
    {
        Pending,
        Added,
        Removed,
    }

    public class NetworkGamer : Gamer
    {
        protected readonly NetworkSession session;
        internal readonly NetworkMachine machine;
        internal readonly byte id;
        internal bool isPrivateSlot;
        internal bool isReady;

        internal NetworkGamerState state = NetworkGamerState.Pending;

        internal NetworkGamer(NetworkMachine machine, byte id, bool isPrivateSlot, bool isReady, string displayName, string gamertag)
            : base()
        {
            this.session = machine.session;
            this.machine = machine;
            this.id = id;
            this.isPrivateSlot = isPrivateSlot;
            this.isReady = isReady;

            this.DisplayName = displayName;
            this.Gamertag = gamertag;
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public NetworkMachine Machine { get { return machine; } }
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public byte Id { get { return id; } }
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public bool IsPrivateSlot { get { return isPrivateSlot; } }
#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public bool HasLeftSession { get { return state == NetworkGamerState.Removed; } }

        public bool IsGuest { get { return machine.gamers[0] != this; } }
        public bool IsHost { get { return machine.isHost && id == 0; } }
        public bool IsLocal { get { return machine.isLocal; } }
        public TimeSpan RoundtripTime { get { return machine.roundtripTime; } }
        public NetworkSession Session { get { return session; } }

        public bool HasVoice { get { return false; } }
        public bool IsTalking { get { return false; } }
        public bool IsMutedByLocalUser { get { return false; } }

        public virtual bool IsReady
        {
            get
            {
                if (IsDisposed) throw new ObjectDisposedException("NetworkGamer");
                return isReady;
            }
            set
            {
                throw new InvalidOperationException("Gamer is not local");
            }
        }
    }
}
