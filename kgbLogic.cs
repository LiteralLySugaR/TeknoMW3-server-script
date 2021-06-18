using System.Collections.Generic;
using InfinityScript;

namespace InfectedServerSsa
{
    internal class kgbLogic : BaseScript
    {
        internal List<Entity> KGB = new List<Entity>();
        internal void OnKgbCommand(Entity player)
        {
            if (!KGB.Contains(player))
            {
                AfterDelay(100, () =>
                {
                    this.KgbOn(player);
                });
            }
            if (KGB.Contains(player))
            {
                AfterDelay(100, () =>
                {
                    this.KgbOff(player);
                });
            }
        }
        internal void KgbOn(Entity player)
        {
            this.KGB.Add(player);
            Utilities.RawSayTo(player, "[^2SPY^7] you entered spy mode.");
        }
        internal void KgbOff(Entity player)
        {
            this.KGB.Remove(player);
            Utilities.RawSayTo(player, "[^2SPY^7] You are no longer in spy mode.");
        }
        internal void KgbLogic(Entity player, Entity inflictor, string message)
        {
            Utilities.RawSayTo(player, "[^2SPY^7] ^2" + inflictor.Name + "^7: " + message);
        }
    }
}
