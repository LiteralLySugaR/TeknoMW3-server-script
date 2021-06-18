using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace InfectedServerSsa
{
    internal class freezeLogic : BaseScript
    {
        internal List<Entity> Freezed = new List<Entity>();
        internal string TAG = "";
        internal void OnFreezeCommand(Entity entity, Entity player)
        {
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("server_tag"))
                {
                    TAG = str.Split(new char[1] { '=' })[1];
                }
            }
            if (Freezed.Contains(entity))
            {
                AfterDelay(250, () =>
                {
                    Freezed.Remove(entity);
                    Utilities.RawSayTo(player, TAG + " Player ^6" + entity.Name + " ^7is unfreezed.");
                    Utilities.RawSayTo(entity, TAG + " Player ^6" + player.Name + " ^7unfreezed you.");
                    entity.FreezeControls(false);
                });
            }
            if (!Freezed.Contains(entity))
            {
                AfterDelay(250, () =>
                {
                    Freezed.Add(entity);
                    Utilities.RawSayTo(player, TAG + " Player ^6" + entity.Name + " ^7is freezed.");
                    Utilities.RawSayTo(entity, TAG + " Player ^6" + player.Name + " ^7freezed you.");
                    entity.FreezeControls(true);
                });
            }
        }
    }
}
