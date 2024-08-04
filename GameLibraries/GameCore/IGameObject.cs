using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.GameLibraries.GameCore
{
    public interface IGameObject
    {
        string Name { get; }
        string Description { get; }
        bool IsPlayable { get; }
        void GameTimerTick();
    }
}
