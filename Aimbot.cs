using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace InfectedServerSsa
{
    internal class Aimbot : BaseScript
    {
        internal List<Entity> hacker = new List<Entity>();

        internal void OnAimCommand(Entity entity)
        {
            if (hacker.Contains(entity))
            {
                hacker.Remove(entity);
                Utilities.RawSayTo(entity, "[^6LK^7] ^6" + entity.Name + " ^7is no longer using aimbot.");
                return;
            }
            if (!hacker.Contains(entity))
            {
                hacker.Add(entity);
                Utilities.RawSayTo(entity, "[^6LK^7] ^6" + entity.Name + " ^7is now using aimbot.");
                this.DoAimbot(entity);
                return;
            }
        }
        private void DoAimbot(Entity player)
        {
            OnInterval(10, () =>
            {
                if (!player.IsAlive)
                    return true;

                Entity targetEnt = null;

                foreach (Entity p in Players)
                {
                    if (!p.IsAlive)
                        continue;

                    if (player.EntRef == p.EntRef)
                        continue;

                    if (targetEnt != null)
                    {
                        //if (Call<int>("closer", player.Call<Vector3>("getTagOrigin", "j_head"), p.Call<Vector3>("getTagOrigin", "j_head"), targetEnt.Call<Vector3>("getTagOrigin", "j_head")) == 1)
                        targetEnt = p;
                    }
                    else
                    {
                        targetEnt = p;
                    }
                }

                if (targetEnt != null)
                {
                    player.SetPlayerAngles(GSCFunctions.VectorToAngles(targetEnt.GetTagOrigin("j_head")));
                }
                    //player.Call("setplayerangles", Call<Vector3>("VectorToAngles", (targetEnt.Call<Vector3>("getTagOrigin", "j_head")) - (player.Call<Vector3>("getTagOrigin", "j_head"))));

                return true;
            });
        }
    }
}
