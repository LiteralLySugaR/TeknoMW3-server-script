using InfinityScript;
using System;
using System.Collections.Generic;
using System.IO;

namespace InfectedServerSsa
{
    internal class AntiCheat : BaseScript
    {
        float KC = 0f;
        float HC = 0f;
        float Ratio = 0.0f;
        internal List<Entity> abs = new List<Entity>();
        internal List<Entity> abc = new List<Entity>();

        //So, "A" is getting bigger every 100 of a second (1s = 1000 so 1s to A = 10)
        //now we need to init the max time on head. (2 mins, 120 seconds so to A it will be 1200)
        int A = 0;
        int A_prev = 0;
        int B = 0;

        internal void AntiCheatS(Entity entity)
        {
            abs.Add(entity);
            string reason = "";
            //Headshot/Kill ratio checker
            OnInterval(100, () =>
            {
                KC = entity.Kills;
                Ratio = HC / KC;
                if (Ratio >= 0.63f && KC > 6f)
                {
                    reason = "^7[^6Anti-Cheat^7] Aimbot suspected. Kill/Headshot ratio: ^1" + Ratio + "^7.";
                    abs.Clear();
                    abc.Clear();
                    Utilities.ExecuteCommand("tempbanclient " + entity.EntRef + " \"" + reason + "\"");
                    return false;
                }
                return true;
            });
            //Time on head checker
            OnInterval(100, () =>
            {
                foreach (Entity player in Players)
                {
                    if (player != entity && player.SessionTeam != entity.SessionTeam)
                    {
                        if ((entity.GetPlayerAngles().X == GSCFunctions.VectorToAngles(GSCFunctions.GetTagOrigin(player, "j_head")).X && 
                        entity.GetPlayerAngles().Y == GSCFunctions.VectorToAngles(GSCFunctions.GetTagOrigin(player, "j_head")).Y && 
                        entity.GetPlayerAngles().Z == GSCFunctions.VectorToAngles(GSCFunctions.GetTagOrigin(player, "j_head")).Z))
                        {
                            A++;
                            if (abc.Contains(player))
                            {
                                continue;
                            }
                            if (!abc.Contains(player))
                            {
                                abc.Add(player);
                            }
                        }
                    }
                }
                if (A >= 1200)
                {
                    Random rng = new Random();
                    int r = rng.Next(1, 2);
                    if (r == 1)
                    {
                        reason = "^7[^6Anti-Cheat^7] Aimbot suspected.";
                    }
                    if (r == 2)
                    {
                        reason = "^7[^6Anti-Cheat^7] ^3DAME DA NE. DAME YO DAME NA NO YO^7.";
                    }
                    abs.Clear();
                    abc.Clear();
                    Utilities.ExecuteCommand("tempbanclient " + entity.EntRef + " \"" + reason + "\"");
                    return false;
                }
                AfterDelay(90, () =>
                {
                    A_prev = A;
                });
                return true;
            });
            OnInterval(100, () =>
            {
                if (A_prev == A)
                {
                    B++;
                }
                if (B >= 10)
                {
                    A -= 10;
                    A_prev -= 10;
                    B = 0;
                }
                return true;
            });
        }
        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            if ((hitLoc == "head" || hitLoc == "j_head" || mod == "MOD_HEADSHOT" || mod == "MOD_HEAD_SHOT") && abs.Contains(attacker))
            {
                if (abc.Contains(player))
                {
                    HC++;
                    A += 10;
                    abc.Remove(player);
                }
                if (!abc.Contains(player))
                {
                    HC++;
                    A += 10;
                }
            }
        }
        //NOTE: idfk how it supposed to work XD
    }
}
