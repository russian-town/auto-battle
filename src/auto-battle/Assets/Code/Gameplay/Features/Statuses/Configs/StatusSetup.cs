﻿using System;

namespace Code.Gameplay.Features.Statuses.Configs
{
    [Serializable]
    public class StatusSetup
    {
        public StatusTypeId TypeId;
        public int Value;
        public int Lifetime;
    }
}
