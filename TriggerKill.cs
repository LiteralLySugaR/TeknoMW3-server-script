using InfinityScript;

namespace InfectedServerSsa
{
    public class TriggerKill : BaseScript
    {
        //I did it by myself c:
        internal ConLog ConLog = new ConLog();  //This line needed to log any TriggerKill damage
        public TriggerKill()
        {
            PlayerConnected += delegate (Entity player)
            {
                AfterDelay(1000, () =>
                {
                    string map = GSCFunctions.GetDvar("mapname");
                    if (map == "mp_courtyard_ss")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if ((460 < X && X < 610) && ((-2145) > Y && Y > (-2310)) && (100 < Z && Z < 350))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_aground_ss")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if ((410 < X && X < 595) && (220 < Y && Y < 440) && (20 < Z && Z < 130))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_six_ss")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if ((540 < X && X < 1186) && (1273 < Y && Y < 1524) && (150 < Z && Z < 330))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_overwatch")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((-344) > X && X > (-443)) && (2304 < Y && Y < 2422) && (12855 < Z && Z < 13012))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_paris")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((-1808) > X && X > (-2351)) && (555 < Y && Y < 707) && (533 < Z && Z < 750))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_exchange")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if ((391 > X && X > 96) && (351 > Y && Y > 12) && (211 < Z && Z < 320))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_bravo")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if ((2171 > X && X > 1195) && (424 > Y && Y > (-236)) && (1346 < Z && Z < 1465))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_alpha")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((110) > X && X > (-394)) && ((-335) > Y && Y > (-517)) && ((207) < Z && Z < (459)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_shipbreaker")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((-203) > X && X > (-659)) && ((295) > Y && Y > (153)) && ((397) < Z && Z < (609)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_lambeth")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((2122) > X && X > (1941)) && ((519) > Y && Y > (400)) && ((-82) < Z && Z < (26)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }
                            if (((1680) > X && X > (1466)) && ((442) > Y && Y > (-635)) && ((-77) < Z && Z < (262)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }
                            if (((1121) > X && X > (939)) && ((-691) > Y && Y > (-1425)) && ((-27) < Z && Z < (272)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_village")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((697) > X && X > (431)) && ((-1479) > Y && Y > (-1501)) && ((509) < Z && Z < (587)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }
                            if (((1479) > X && X > (1228)) && ((315) > Y && Y > (72)) && ((437) < Z && Z < (659)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_park")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((1488) > X && X > (912)) && ((877) > Y && Y > (105)) && ((452) < Z && Z < (679)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_plaza2")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((465) > X && X > (267)) && ((-249) > Y && Y > (-459)) && ((881) < Z && Z < (1097)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_morningwood")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((258) > X && X > (-31)) && ((1781) > Y && Y > (1572)) && ((1406) < Z && Z < (1765)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                    if (map == "mp_underground")
                    {
                        OnInterval(100, () =>
                        {
                            var X = player.Origin.X;
                            var Y = player.Origin.Y;
                            var Z = player.Origin.Z;
                            if (((-843) > X && X > (-1034)) && ((233) > Y && Y > (-321)) && ((158) < Z && Z < (345)))
                            {
                                AfterDelay(10, () =>
                                {
                                    if (GSCFunctions.IsAlive(player))
                                    {
                                        ConLog.PlayerTriggerKillEv(player, map);
                                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "MOD_FALLING", "none", player.Origin, player.Origin, "none", 0);
                                    }
                                });
                            }

                            return true;
                        });
                    }
                });
            };
        }
    }
}
