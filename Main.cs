using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using InfinityScript;

namespace InfectedServerSsa
{
    public class Main : BaseScript
    {
        freezeLogic freezeLogic = new freezeLogic();

        internal List<string> AvCommands = new List<string>();
        internal List<Entity> AFKs = new List<Entity>();

        internal Random preseed1 = new Random();
        internal Random preseed2 = new Random();
        internal Random preseed3 = new Random();
        internal Random preseed4 = new Random();
        internal List<string> LinesDSPL = new List<string>();
        internal List<string> SeedFull = new List<string>();

        internal List<string> IsKicked = new List<string>();

        private List<string> maplist = new List<string>();
        private List<string> consmaplist = new List<string>();
        Dictionary<string, string> Groups = new Dictionary<string, string>();
        Dictionary<string, string> UserGroup = new Dictionary<string, string>();
        Dictionary<string, string> gCommands = new Dictionary<string, string>();
        private string listG;
        private HudElem voteHud = HudElem.CreateServerFontString(HudElem.Fonts.Objective, 1.8f);
        private Main.Vote vote;
        internal ConLog ConLog = new ConLog();
        private Dictionary<int, string> Maps = new Dictionary<int, string>();
        kgbLogic kgbLogic = new kgbLogic();
        MBS MBS = new MBS();

        internal List<string> AdminsNames = new List<string>();
        internal List<string> ModsNames = new List<string>();

        internal List<Entity> Donaters = new List<Entity>();
        internal List<Entity> Moderators = new List<Entity>();
        internal List<Entity> StaffMods = new List<Entity>();
        internal List<Entity> SuperMods = new List<Entity>();
        internal List<Entity> Curators = new List<Entity>();
        internal List<Entity> Admins = new List<Entity>();

        internal string TAG = "";
        public Main()
        {
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("server_tag"))
                {
                    TAG = str.Split(new char[1] { '=' })[1];
                }
            }

            this.ConfigSet();
            this.GetPermission();
            this.AutoMessage();
            //this.DSPLback();
            //this.PlayerFly();
            this.consmaplist.Add("mp_dome");
            this.consmaplist.Add("mp_plaza2");
            this.consmaplist.Add("mp_alpha");
            this.consmaplist.Add("mp_hardhat");
            this.consmaplist.Add("mp_bootleg");
            this.consmaplist.Add("mp_interchange");
            this.consmaplist.Add("mp_carbon");
            this.consmaplist.Add("mp_exchange");
            this.consmaplist.Add("mp_radar");
            this.consmaplist.Add("mp_hillside_ss");
            this.consmaplist.Add("mp_restrepo_ss");
            this.consmaplist.Add("mp_overwatch");
            this.consmaplist.Add("mp_lambeth");
            this.consmaplist.Add("mp_terminal_cls");
            this.consmaplist.Add("mp_underground");
            this.consmaplist.Add("mp_village");
            this.consmaplist.Add("mp_bravo");
            this.consmaplist.Add("mp_paris");
            this.consmaplist.Add("mp_mogadishu");
            this.consmaplist.Add("mp_seatown");
            this.consmaplist.Add("mp_park");
            this.consmaplist.Add("mp_italy");
            this.consmaplist.Add("mp_morningwood");
            this.consmaplist.Add("mp_meteora");
            this.consmaplist.Add("mp_cement");
            this.consmaplist.Add("mp_qadeem");
            this.consmaplist.Add("mp_aground_ss");
            this.consmaplist.Add("mp_courtyard");
            this.consmaplist.Add("mp_burn_ss");
            this.consmaplist.Add("mp_crosswalk_ss");
            this.consmaplist.Add("mp_six_ss");
            this.consmaplist.Add("mp_shipbreaker");
            this.consmaplist.Add("mp_roughneck");
            this.consmaplist.Add("mp_moab");
            this.consmaplist.Add("mp_boardwalk");
            this.consmaplist.Add("mp_nola");

            this.maplist.Add("dome");
            this.maplist.Add("arkaden");
            this.maplist.Add("lockdown");
            this.maplist.Add("hardhat");
            this.maplist.Add("bootleg");
            this.maplist.Add("interchange");
            this.maplist.Add("carbon");
            this.maplist.Add("downturn");
            this.maplist.Add("outpost");
            this.maplist.Add("gateway");
            this.maplist.Add("lookout");
            this.maplist.Add("overwatch");
            this.maplist.Add("fallen");
            this.maplist.Add("terminal");
            this.maplist.Add("underground");
            this.maplist.Add("village");
            this.maplist.Add("mission");
            this.maplist.Add("resistance");
            this.maplist.Add("bakaraa");
            this.maplist.Add("seatown");
            this.maplist.Add("liberation");
            this.maplist.Add("pizza");
            this.maplist.Add("blackbox");
            this.maplist.Add("sanctuary");
            this.maplist.Add("foundation");
            this.maplist.Add("oasis");
            this.maplist.Add("aground");
            this.maplist.Add("erosion");
            this.maplist.Add("uturn");
            this.maplist.Add("intersection");
            this.maplist.Add("vortex");
            this.maplist.Add("decommission");
            this.maplist.Add("offshore");
            this.maplist.Add("gulch");
            this.maplist.Add("boardwalk");
            this.maplist.Add("parish");

            this.maplist.Add("bravo");
            this.maplist.Add("exchange");
            this.maplist.Add("alpha");
            this.maplist.Add("lambeth");
            this.maplist.Add("mogadishu");
            this.maplist.Add("paris");
            this.maplist.Add("plaza2");
            this.maplist.Add("radar");
            this.maplist.Add("park");
            this.maplist.Add("italy");
            this.maplist.Add("morningwood");
            this.maplist.Add("meteora");
            this.maplist.Add("cement");
            this.maplist.Add("qadeem");
            this.maplist.Add("courtyard");
            this.maplist.Add("hillside");
            this.maplist.Add("restrepo");
            this.maplist.Add("burn");
            this.maplist.Add("crosswalk");
            this.maplist.Add("six");
            this.maplist.Add("shipbreaker");
            this.maplist.Add("roughneck");
            this.maplist.Add("moab");
            this.maplist.Add("nola");

            this.Maps.Add(0, "mp_dome= dome=0");
            this.Maps.Add(1, "mp_bootleg= bootleg=0");
            this.Maps.Add(2, "mp_hardhat= hardhat=0");
            this.Maps.Add(3, "mp_carbon= carbon=0");
            this.Maps.Add(4, "mp_exchange= downturn=0");
            this.Maps.Add(5, "mp_radar= outpost=0");
            this.Maps.Add(6, "mp_hardhat= hardhat=0");
            this.Maps.Add(7, "mp_hillside_ss= getaway=1");
            this.Maps.Add(8, "mp_restrepo_ss= lookout=1");
            this.Maps.Add(9, "mp_overwatch= overwatch=1");
            this.Maps.Add(10, "mp_lambeth= fallen=0");
            this.Maps.Add(11, "mp_terminal_cls= terminal=0");
            this.Maps.Add(12, "mp_underground= underground=0");
            this.Maps.Add(13, "mp_plaza2= arkaden=0");
            this.Maps.Add(14, "mp_shipbreaker= decommision=1");
            this.Maps.Add(15, "mp_nola= paris=1");
            this.Maps.Add(16, "mp_plaza2= arkaden=0");
            this.Maps.Add(17, "mp_roughneck= Off Shore=1");
            this.Maps.Add(18, "mp_boardwalk= boardwalk=1");
            this.Maps.Add(19, "mp_italy= piazza=1");
            this.Maps.Add(20, "mp_moab= gulch=1");
            this.Maps.Add(21, "mp_cement= foundation=1");
            this.Maps.Add(22, "mp_morningwood= black box=1");
            this.Maps.Add(23, "mp_meteora= sanctuary=1");
            this.Maps.Add(24, "mp_aground_ss= aground=1");
            this.Maps.Add(25, "mp_burn_ss= u-turn=1");
            this.Maps.Add(26, "mp_courtyard_ss= erosion=1");
            this.Maps.Add(27, "mp_park= liberation=1");
            this.Maps.Add(28, "mp_qadeem= oasis=1");
            this.Maps.Add(29, "mp_six_ss= vortex=1");
            this.Maps.Add(30, "mp_alpha= lockdown=0");
            this.Maps.Add(31, "mp_qadeem= oasis=1");
            this.Maps.Add(32, "mp_bravo= mission=0");
            this.Maps.Add(33, "mp_interchange= interchange=0");
            this.Maps.Add(34, "mp_mogadishu= bakaara=0");
            this.Maps.Add(35, "mp_paris= resistence=0");
            this.Maps.Add(36, "mp_seatown= seatown=0");
            this.Maps.Add(37, "mp_village= village=0");

            this.PlayerConnected += new Action<Entity>(this.playerConnected);
            this.PlayerDisconnected += new Action<Entity>(this.playerDisconnected);
            Random rngs = new Random();
            int num = rngs.Next(25, 100);
            bool allow_random_seed = false;

            if (File.Exists("scripts\\GPIv3\\Seed\\Saves.txt"))
            {
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                {
                    if (str.StartsWith("allow_random_seed"))
                    {
                        allow_random_seed = Convert.ToBoolean(str.Split(new char[1] { '=' })[1]);
                        break;
                    }
                }
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\Seed\\Saves.txt"))
                {
                    if (str.StartsWith("chance"))
                    {
                        chance = Convert.ToInt32(str.Split(new char[1] { '=' })[1]);
                        break;
                    }
                }
                if (num < chance && allow_random_seed == true)
                {
                    AfterDelay(1000, () =>
                    {
                        SeedGenerator();
                    });
                }
            }
            if (!File.Exists("scripts\\GPIv3\\Seed\\Saves.txt"))
            {
                if (num < 95 && chance < 1 && allow_random_seed == true)
                {
                    AfterDelay(1000, () =>
                    {
                        SeedGenerator();
                    });
                }
            }
            if (allow_random_seed == false)
            {
                foreach (string str in File.ReadAllLines(@"B:\Games\G\MW3 SERVES\INFECTED_02\admin\infected.dspl"))
                {
                    if (str.Contains("*"))
                    {
                        break;
                    }
                    if (!str.Contains("*"))
                    {
                        string[] lines = new string[15];
                        lines[0] = "*,Cinf1,1000";
                        lines[1] = "*,Cinf2,1000";
                        lines[2] = "*,Cinf3,1000";
                        lines[3] = "*,Cinf4,1000";
                        lines[4] = "*,Cinf5,1000";
                        lines[5] = "*,Cinf6,1000";
                        lines[6] = "*,Cinf7,1000";
                        lines[7] = "*,Cinf8,1000";
                        lines[8] = "*,Cinf9,1000";
                        lines[9] = "*,Cinf10,1000";
                        lines[10] = "*,Cinf11,1000";
                        lines[11] = "*,Cinf13,1000";
                        lines[12] = "*,Cinf14,1000";
                        lines[13] = "*,Cinf15,1000";
                        lines[14] = "*,Cinf16,1000";
                        File.WriteAllLines(@"B:\Games\G\MW3 SERVES\INFECTED_02\admin\infected.dspl", lines);
                        break;
                    }
                }
            }
            /*DEBUG*/
            //Print("num=" + num);
            //Print("chance=" + chance);
            /*DEBUG*/
            //OnInterval(10, () =>
            //{
            //    if (File.ReadAllLines("scripts\\GPIv3\\Logss.txt").Length >= 1000)
            //    {
            //        ConLog.LogCleaner();
            //    }
            //    return true;
            //});
            OnInterval(1000, (Func<bool>)(() =>
            {
                if (!this.vote.inProgress)
                    return true;
                if (this.vote.type == "kick")
                {
                    this.voteHud.Destroy();
                    this.voteHud = HudElem.CreateServerFontString(this.Objective, 1.3f);
                    this.voteHud.SetPoint("TOP", "TOP", 0, 10);
                    this.voteHud.SetText("^6" + this.vote.time.ToString() + "s     ^7Kick ^6" + this.vote.plKick.Name + "^7? ^6[!y]Yes: " + this.vote.agree.Count.ToString() + " [!n]No: " + this.vote.contro.Count.ToString());
                    this.voteHud.GlowColor = new Vector3(0.5f, 0.2f, 0.7f);
                    this.voteHud.GlowAlpha = 0.55f;
                    if (this.vote.time == 0)
                    {
                        this.voteHud.Destroy();
                        if (this.vote.agree.Count > BaseScript.Players.Count / 2)
                        {
                            this.IsKicked.Add(this.vote.plKick.Name);
                            Utilities.ExecuteCommand("kick " + this.vote.plKick.Name + " vote-kicked.");
                            foreach (Entity player in BaseScript.Players)
                            {
                                HudElem fontString = HudElem.CreateFontString(player, this.HudSmall, 0.8f);
                                fontString.SetPoint("TOP", "TOP", 0, 450);
                                fontString.SetText("Vote passed, ^6" + this.vote.plKick.Name + " ^7kicked");
                                fontString.GlowColor = new Vector3(1f, 0.0f, 1f);
                                fontString.GlowAlpha = 0.5f;
                                fontString.SetPulseFX(100, 4000, 100);
                            }
                        }
                        if (this.vote.agree.Count <= BaseScript.Players.Count / 2)
                        {
                            foreach (Entity player in BaseScript.Players)
                            {
                                HudElem fontString = HudElem.CreateFontString(player, this.HudSmall, 0.8f);
                                fontString.SetPoint("TOP", "TOP", 0, 450);
                                fontString.SetText("Vote failed to kick ^6" + this.vote.plKick.Name);
                                fontString.GlowColor = new Vector3(1f, 0.0f, 1f);
                                fontString.GlowAlpha = 0.75f;
                                fontString.SetPulseFX(100, 4000, 100);
                            }
                        }
                        this.vote.inProgress = false;
                    }
                }
                if (this.vote.type == "map")
                {
                    string str = "";
                    string map = "";
                    foreach (KeyValuePair<int, string> map1 in this.Maps)
                    {
                        if (map1.Value.Split('=')[0] == this.vote.obj)
                        {
                            str = map1.Value.Split('=')[1];
                            map = map1.Value.Split('=')[0];
                        }
                    }
                    this.voteHud.Destroy();
                    this.voteHud = HudElem.CreateServerFontString(this.Objective, 1.3f);
                    this.voteHud.SetPoint("TOP", "TOP", 0, 10);
                    this.voteHud.SetText("^6" + this.vote.time.ToString() + "s  ^7Change map to ^6" + str + "^7? ^6[!y]Yes: " + this.vote.agree.Count.ToString() + " [!n]No: " + this.vote.contro.Count.ToString());
                    this.voteHud.GlowColor = new Vector3(0.5f, 0.2f, 0.7f);
                    this.voteHud.GlowAlpha = 0.55f;
                    if (this.vote.time == 0)
                    {
                        this.voteHud.Destroy();
                        if (this.vote.agree.Count > BaseScript.Players.Count / 2)
                        {
                            foreach (Entity player in BaseScript.Players)
                            {
                                HudElem fontString = HudElem.CreateFontString(player, this.HudSmall, 0.8f);
                                fontString.SetPoint("TOP", "TOP", 0, 450);
                                fontString.SetText("Vote passed, ^2Map change to: " + str);
                                fontString.GlowColor = new Vector3(0.0f, 1f, 0.0f);
                                fontString.GlowAlpha = 0.5f;
                                fontString.SetPulseFX(100, 4000, 100);
                            }
                            BaseScript.AfterDelay(4000, (Action)(() =>
                            {
                                Utilities.ExecuteCommand("map " + map);
                                Utilities.RawSayAll("^3Map changed");
                            }));
                        }
                        if (this.vote.agree.Count <= BaseScript.Players.Count / 2)
                        {
                            foreach (Entity player in BaseScript.Players)
                            {
                                HudElem fontString = HudElem.CreateFontString(player, this.HudSmall, 0.8f);
                                fontString.SetPoint("TOP", "TOP", 0, 450);
                                fontString.SetText("Vote failed to Change map");
                                fontString.GlowColor = new Vector3(1f, 0.0f, 0.0f);
                                fontString.GlowAlpha = 1f;
                                fontString.SetPulseFX(100, 4000, 100);
                            }
                        }
                        this.vote.inProgress = false;
                    }
                }
                --this.vote.time;
                return true;
            }));
        }
        public Dictionary<String, String> IsoCountries = new Dictionary<string, string>();
        public bool DrawPos = new bool();

        public List<Entity> Entitys = new List<Entity>();
        public List<string> EntitysStr = new List<string>();

        public List<Entity> AdminChat = new List<Entity>();
        public bool thisPlayerReq = new bool();
        public List<string> MapPositions = new List<string>();

        Random RNG = new Random();

        public HudElem.Fonts HudSmall;
        public HudElem.Fonts Objective;
        private struct Vote
        {
            public bool inProgress;
            public string type;
            public List<Entity> agree;
            public List<Entity> contro;
            public Entity plKick;
            public string obj;
            public int time;
        }
        //public void AntiRQ(Entity player)
        //{
        //    if (File.Exists("scripts\\GPIv3\\tempBans\\" + player.Name + ".txt"))
        //    {
        //        IsKicked.Add(player.Name);
        //        File.Delete("scripts\\GPIv3\\tempBans\\" + player.Name + ".txt");
        //        AfterDelay(250, () =>
        //        {
        //            Utilities.ExecuteCommand("tempbanclient " + player.GetEntityNumber() + " Rage-quit");
        //        });
        //    }
        //    OnInterval(100, delegate
        //    {
        //        if (player.SessionTeam == "axis" && Players.Count > 5)
        //        {
        //            player.CloseInGameMenu();
        //        }
        //        return true;
        //    });
        //    player.SpawnedPlayer += delegate ()
        //    {
        //        if (Players.Count > 5)
        //        {
        //            HudElem infected = HudElem.CreateFontString(player, HudElem.Fonts.Objective, 1.2f);
        //            infected.SetPoint("CENTER", "CENTER", 0, -110);
        //            infected.SetText("^7[^6LK^7] ^6Infected ^7cannot ^6leave ^7the ^6server.");
        //            infected.GlowAlpha = 1f;
        //            infected.SetPulseFX(100, 5000, 500);
        //            infected.HideWhenInMenu = true;
        //        }
        //    };
        //}
        void playerConnected(Entity player)
        {
            //Add to anti-cheat
            AntiCheat AntiCheat = new AntiCheat();
            bool enable_anticheat = new bool();
            string stri1 = "";
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("enable_anticheat"))
                {
                    stri1 = str.Split(new char[1] { '=' })[1];

                    enable_anticheat = Convert.ToBoolean(stri1);
                    break;
                }
            }
            if (enable_anticheat == true)
            {
                Log.Write(LogLevel.All, "enable_anticheat=true , continue");
                AntiCheat.AntiCheatS(player);
            }
            if (!enable_anticheat == true)
            {
                Log.Write(LogLevel.All, "enable_anticheat=false , discontinue");
            }

            //Check for same nicknames
            //special limit is 6 bc if player with name "asas" on the server, 
            //and the player with name "maybeasas" enter the server, he will be kicked
            //special limit prevent this, so if player name is "player"(6 sym) and other player name "player6"(7 sym), player6 will be kicked
            //But, if player "iamthebestplayer"(16 sym) will join, he will be kicked too, only bc of "player" in his name.
            //To prevent this, i did some maths:
            // p - playername length | r - result | s - str | f - final result
            // (p / 2) = r - s = f
            // (16 / 2) = 8 - 6 = 2
            // if "f" is smaller or equals 0, then the player will be kicked, in this case, i took "player" as the one already on the server
            //and "iamthebestplayer" as the new. The new player won't be kicked. Here are some examples:
            // new player length - 12 | player name which on the server length - 7
            // (12 / 2) = 6 - 7 = -1
            //the player will be kicked.
            // new player length - 15 | player name on the server length - 6
            // (15 / 2) = 7.5 - 6 = 1.5
            //the player won't be kicked.
            // new player length - 17 | player name on the server length - 14
            // (17 / 2) = 8.5 - 14 = -5.5
            //the player will be kicked.
            // new player length - 6 | player name on the server length - 6
            // (6 / 2) = 3 - 6 = -3
            //the player will be kicked.
            // new player length - 12 | player name on the server length - 6
            // (12 / 2) = 6 - 6 = 0
            //the player will be kicked.

            foreach (string str in EntitysStr)
            {
                if (player.Name.Contains(str) && str.Length >= 6)
                {
                    int pref = player.Name.Length / 2;
                    int f = pref - str.Length;

                    if (f <= 0)
                    {
                        AfterDelay(250, () =>
                        {
                            Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Impostor! ^7Player with this nickname ^6" + str + " ^7is already on the server.");
                        });
                    }
                    break;
                }
            }
            //Check for banned symbols
            //if (player.Name.Contains("`"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (`)^7)^7, Please change your nickname.");
            //    });
            //}
            if (player.Name.Contains(" "))
            {
                AfterDelay(250, () =>
                {
                    Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain SPACES^7)^7, Please change your nickname.");
                });
            }
            if (player.Name.Contains("^"))
            {
                AfterDelay(250, () =>
                {
                    Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (^)^7)^7, Please change your nickname.");
                });
            }
            //if (player.Name.Contains("~"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (~)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains("/"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (/)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains(@"\"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + @" ^1Banned nickname symbols ^7(^1Nickname should not contain (\)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains("|"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (|)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains("?"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (?)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains(":"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (:)^7)^7, Please change your nickname.");
            //    });
            //}
            if (player.Name.Contains("*"))
            {
                AfterDelay(250, () =>
                {
                    Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (*)^7)^7, Please change your nickname.");
                });
            }
            //if (player.Name.Contains(">"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (>)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains("<"))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (<)^7)^7, Please change your nickname.");
            //    });
            //}
            //if (player.Name.Contains("\""))
            //{
            //    AfterDelay(250, () =>
            //    {
            //        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Banned nickname symbols ^7(^1Nickname should not contain (\")^7)^7, Please change your nickname.");
            //    });
            //}
            //Special Event.
            if (player.Name.Contains("LiSsa"))
            {
                AfterDelay(250, () =>
                {
                    Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " ^1Impostor.");
                });
            }
            //Check ban hystory
            if (!File.Exists("scripts\\GPIv3\\IPBanlist\\" + player.IP.Address.ToString() + ".txt") && !File.Exists("scripts\\Banlist\\" + player.HWID.ToString() + ".txt"))
            {
                AfterDelay(1500, () =>
                {
                    Utilities.RawSayTo(player, TAG + " ^2No bans found^7. have a good day!");
                });
            }
            if (File.Exists("scripts\\GPIv3\\IPBanlist\\" + player.IP.Address.ToString() + ".txt") || File.Exists("scripts\\Banlist\\" + player.HWID.ToString() + ".txt"))
            {
                AfterDelay(1500, () =>
                {
                    Utilities.RawSayTo(player, TAG + " ^1ban hystory detected^7. try to not violate rules for not get ^1PERM-BANNED^7!");
                    Print(player.Name + " ban hystory detected. Saving data...");
                    ConLog.StringArray(player.Name + " ban hystory detected. Saving data...");
                    string IPAD = player.IP.Address.ToString();
                    string name = player.Name.ToString();
                    string HWID = player.HWID.ToString();
                    string GUID = player.GUID.ToString();
                    string XUID = player.GetXUID().ToString();
                    if (!File.Exists("scripts\\GPIv3\\BanDB\\" + player.HWID.ToString() + ".txt"))
                    {
                        File.WriteAllLines("scripts\\GPIv3\\BanDB\\" + player.HWID.ToString() + ".txt", new string[5]
                        {
                                "ip=" + IPAD,
                                "name=" + name,
                                "hwid=" + HWID,
                                "guid=" + GUID,
                                "xuid=" + XUID
                        });
                    }
                });
            }
            //Is data-banned 1
            if (File.Exists("scripts\\GPIv3\\Banlist\\" + player.GUID.ToString() + ".txt"))
            {
                string str1 = null;
                string str2 = null;
                string str3 = null;
                string str4 = null;
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\Banlist\\" + player.GUID.ToString() + ".txt"))
                {
                    if (str.StartsWith("ip"))
                    {
                        str1 = str.Split(new char[1]
                        {
                            '='
                        })[1];
                    }
                    if (str.StartsWith("hwid"))
                    {
                        str2 = str.Split(new char[1]
                        {
                            '='
                        })[1];
                    }
                    if (str.StartsWith("guid"))
                    {
                        str3 = str.Split(new char[1]
                        {
                            '='
                        })[1];
                    }
                    if (str.StartsWith("xuid"))
                    {
                        str4 = str.Split(new char[1]
                        {
                            '='
                        })[1];
                    }
                }
                if (player.IP.Address.ToString() == str1 || player.HWID.ToString() == str2 || player.GUID.ToString() == str3 || player.GetXUID().ToString() == str4)
                {
                    AfterDelay(250, () =>
                    {
                        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " You are ^1DATA-BANNED^7. For any questions, discord: ^6discord.gg/KMSx2kN7Xu");
                    });
                }
            }
            //Is data-banned 2
            if (File.Exists("scripts\\GPIv3\\BDB\\alldata.txt"))
            {
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\BDB\\alldata.txt"))
                {
                    if (str.Contains(player.Name) || str.Contains(player.HWID) || str.Contains(player.GUID.ToString()) || str.Contains(player.IP.Address.ToString()) || str.Contains(player.GetXUID().ToString()))
                    {
                        AfterDelay(250, () =>
                        {
                            Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " You are ^1DATA-BANNED^7. For any questions, discord: ^6discord.gg/KMSx2kN7Xu");
                        });
                        break;
                    }
                }
            }
            //Is ip-banned
            if (File.Exists("scripts\\GPIv3\\IPBanlist\\" + player.IP.Address.ToString() + ".txt"))
            {
                string str1 = null;
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\IPBanlist\\" + player.IP.Address.ToString() + ".txt"))
                {
                    if (str.StartsWith("ip"))
                    {
                        str1 = str.Split(new char[1]
                        {
                            '='
                        })[1];
                    }
                }
                if (player.IP.Address.ToString() == str1)
                {
                    AfterDelay(250, () =>
                    {
                        Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " You are ^1IP-BANNED^7. For any questions, discord: ^6discord.gg/KMSx2kN7Xu");
                    });
                }
            }
            //Is H-banned
            if (File.Exists("scripts\\GPIv3\\HBanlist\\" + player.GUID.ToString() + ".txt"))
            {
                AfterDelay(250, () =>
                {
                    Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " You are ^3DATA-BANNED^7. For any questions, discord: ^6discord.gg/KMSx2kN7Xu");
                });
            }
            //AntiRQ

            //Welcome message & list adding
            AfterDelay(500, (Action)(() =>
            {
                if (GetRankByName(player.Name) == "Admin")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^2[Admin] ^6" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.AdminsNames.Add(player.Name);
                }
                if (GetRankByName(player.Name) == "Moderator")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^1[Moder] ^6" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.Moderators.Add(player);
                    this.ModsNames.Add(player.Name);
                }
                if (GetRankByName(player.Name) == "StaffMod")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^3[StaffMod] ^6" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.StaffMods.Add(player);
                    this.ModsNames.Add(player.Name);
                }
                if (GetRankByName(player.Name) == "Helper")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^5[Helper] ^6" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.SuperMods.Add(player);
                    this.AdminsNames.Add(player.Name);
                }
                if (GetRankByName(player.Name) == "Friend")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^;[Friend] ^6" + player.Name + "^7!");
                }
                if (GetRankByName(player.Name) == "Donater")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^:" + player.Name + "^7!");
                    this.Donaters.Add(player);
                }
                if (GetRankByName(player.Name) == "Dev")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^:[DEV] ^5" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.AdminsNames.Add(player.Name);
                    this.Admins.Add(player);
                }
                if (GetRankByName(player.Name) == "Host")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^2" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.Admins.Add(player);
                    this.AdminsNames.Add(player.Name);
                }
                if (GetRankByName(player.Name) == "Curator")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^2[Curator] ^5" + player.Name + "^7!");
                    this.AdminChat.Add(player);
                    this.Curators.Add(player);
                    this.AdminsNames.Add(player.Name);
                }
                else if (GetRankByName(player.Name) == "User")
                {
                    Utilities.RawSayAll(TAG + " Welcome ^6" + player.Name + "^7!");
                }
                Utilities.RawSayTo(player, TAG + " Type ^6!rules^7 for all server rules or type ^6!help^7 for all commands.");
            }));
            this.MBS.OnConnectLogic(player);
            ConLog.PlayerConnectingEv(player);
            this.Entitys.Add(player);
            this.EntitysStr.Add(player.Name);
            this.CheckPlayerKills(player);
            string epc = null;
            AfterDelay(6500, () =>
            {
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                {
                    if (str.StartsWith("enable_pingchecker"))
                    {
                        epc = str.Split(new char[1] { '=' })[1];
                    }
                }
                if (epc == "true")
                {
                    PingChecker(player);
                }
            });
            //Position handler
            string str0 = null;
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("allow_afk"))
                {
                    str0 = str.Split(new char[1] { '=' })[1];
                }
            }
            if (str0 == "true")
            {
                /*DEBUG*/
                Print("allowafk=true.");
                /*DEBUG*/
            }
            if (str0 == "false")
            {
                /*DEBUG*/
                Print("allowafk=false, continue");
                /*DEBUG*/
                IntervalAB intervalAB = new IntervalAB();
                PositionHandler(player, intervalAB.IntervalA, intervalAB.PlayerPosA, intervalAB.IntervalB, intervalAB.IntervalC);
            }
            else if (str0 != "false" && str0 != "true")
            {
                /*DEBUG*/
                Print("allowafk= unknown value, please, set true or false. Server value set to true.");
                /*DEBUG*/
            }
        }
        internal void PingChecker(Entity entity)
        {
            string str1 = null;
            int maxping = 0;
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("max_ping"))
                {
                    str1 = str.Split(new char[1] { '=' })[1];
                    maxping = Convert.ToInt32(str1);
                }
            }
            OnInterval(250, () =>
            {
                if (entity.Ping >= maxping)
                {
                    IsKicked.Add(entity.Name);
                    Utilities.ExecuteCommand("dropclient " + entity.GetEntityNumber() + " Your ping is too high! (max " + maxping + ")");
                }
                return true;
            });
        }
        void playerDisconnected(Entity player)
        {
            string todelname = player.Name;
            if (player.SessionTeam == "axis" && !IsKicked.Contains(player.Name) && Players.Count > 3)
            {
                File.Create("scripts\\GPIv3\\tempBans\\" + player.Name + ".txt");
            }
            ConLog.PlayerDisconnectingEv(player);
            Entitys.Remove(player);
            EntitysStr.Remove(player.Name);
            if (AdminChat.Contains(player))
            {
                AdminChat.Remove(player);
            }
            AfterDelay(1000, () =>
            {
                IsKicked.Remove(todelname);
            });
        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        private void Incomingnuke(Entity player)
        {
            player.PlayLocalSound("nuke_incoming");
        }
        private void Explosenuke(Entity player)
        {
            player.PlayLocalSound("nuke_explosion");
            player.PlayLocalSound("nuke_wave");
        }
        private void Visionbynuke()
        {
            GSCFunctions.VisionSetNaked("mpnuke", 3);

            OnNotify("nuke_death", (Action)(() =>
            {
                GSCFunctions.VisionSetNaked("aftermath", 5);
                GSCFunctions.VisionSetPain("aftermath");
            }));
        }
        private void Deathbynuke(Entity player)
        {
            GSCFunctions.AmbientStop(1);
            if (GSCFunctions.IsAlive(player))
            {
                GSCFunctions.FinishPlayerDamage(player, player, player, 999999, 0, "NOD_EXPLOSIVE", "nuke_mp", player.Origin, player.Origin, "none", 0);
            }
            Notify("nuke_death");
        }
        private void NukePlayers(Entity player)
        {
            GSCFunctions.SetDvar("scr_nukeTimer", 10);
            GSCFunctions.SetDvar("scr_nukeCancelMode", 0);

            GSCFunctions.SetDvar("ui_bomb_timer", 4);
            GSCFunctions.SetDvar("ui_nuke_end_milliseconds", GSCFunctions.GetTime() + 10 * 1000);

            //GSCFunctions.SetCardTitle(player, "used_nuke");
            foreach (Entity players in Entitys)
            {
                GSCFunctions.ShowHudSplash(players, "used_nuke", player.EntRef);
                AfterDelay(10000, () =>
                {
                    GSCFunctions.SetDvar("ui_bomb_timer", 0);
                });
                AfterDelay(6700, () =>
                {
                    this.Incomingnuke(players);      //delay: 6.70 sec
                });
                AfterDelay(10000, () =>
                {
                    this.Explosenuke(players);       //delay: 10.0 sec
                });
                AfterDelay(9150, () =>
                {
                    this.Visionbynuke();            //delay: 9.25 sec
                });
                AfterDelay(10600, (Action)(() =>
                {
                    this.Deathbynuke(players);

                    AfterDelay(1000, () =>
                    {
                        HudElem reasonelem = HudElem.CreateServerFontString(Objective, 1.8f);
                        reasonelem.SetPoint("CENTER", "CENTER", 0, -70);
                        reasonelem.SetText("M.O.A.B");
                        reasonelem.GlowColor = new Vector3(0.65f, 0.10f, 0.05f);
                        reasonelem.GlowAlpha = 0.35f;
                        reasonelem.SetPulseFX(1000, 5000, 1);

                        players.Notify("menuresponse", "menu", "endround");
                    });
                }));

                players.PlayLocalSound("ui_mp_nukebomb_timer");
                AfterDelay(1000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(2000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(3000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(4000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(5000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(6000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(7000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(8000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(9000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
                AfterDelay(10000, (Action)(() =>
                {
                    players.PlayLocalSound("ui_mp_nukebomb_timer");
                }));
            }
        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        public override BaseScript.EventEat OnSay2(Entity player, string name, string message)
        {
            ConLog.PlayerMessageEv(player, message, GetRankByName(player.Name));
            return this.CommandFilter(player, message);
        }
        void ConfigSet()
        {
            if (!File.Exists("scripts\\GPIv3\\GPIconfig.txt"))
            {
                File.Create("scripts\\GPIv3\\GPIconfig.txt").Close();
                File.WriteAllLines("scripts\\GPIv3\\GPIconfig.txt", new string[40]
                {
                        "groups=User,Moderator,Helper,Admin,StaffMod,Friend,Donater,Curator,Host,Dev",
                        "User_xuids=*EVERYONE*",
                        "Moderator_xuids=",
                        "Friend_xuids=",
                        "StaffMod_xuids=",
                        "Donater_xuids=",
                        "Helper_xuids=",
                        "Admin_xuids=",
                        "Curator_xuids=",
                        "Dev_xuids=",
                        "User_commands=!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!pm,!report,!s,!suicide,!ReqMod,!rm,!discord,!dsc,!vote,!y,!n,!mbs,!ident,!level,!admins,!mods,!ver,!afk,!seed,!about,!anticheat",
                        "Friend_commands=!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!pm,!report,!s,!suicide,!ReqMod,!rm,!discord,!dsc,!vote,!y,!n,!mbs,!ident,!level,!admins,!mods,!ver,!afk,!seed,!about,!anticheat",
                        "Moderator_commands=!ac,!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!map,!kick,!drop,!uid,!pm,!report,!tb,!tempban,!s,!suicide,!kill,!discord,!dsc,!vote,!y,!n,!mbs,!ident,!br,!bring,!level,!admins,!mods,!ver,!afk,!seed,!about,!anticheat",
                        "StaffMod_commands=!ac,!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!map,!kick,!drop,!uid,!pm,!report,!tb,!tempban,!s,!suicide,!kill,!ban,!ipban,!nextmap,!discord,!dsc,!vote,!y,!n,!mbs,!ident,!kgb,!br,!bring,!level,!playerinfo,!pi,!whois,!admins,!mods,!ver,!afk,!seed,!about,!anticheat",
                        "Helper_commands=!ac,!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!map,!kick,!drop,!uid,!pm,!report,!tb,!tempban,!s,!suicide,!kill,!ban,!ac130,!convert,!gotopos,!savepos,!setpos,!getpos,!hwid,!spec,!discord,!dsc,!addweap,!takeweap,!vote,!y,!n,!mbs,!ident,!whois,!freeze,!br,!bring,!action,!poslist,!level,!playerinfo,!pi,!tpt,!goto,!admins,!mods,!ver,!groups,!afk,!poswhitelist,!poswl,!seed,!freeze,!about",
                        "Admin_commands=!ac,!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!map,!kick,!drop,!uid,!pm,!report,!tb,!tempban,!s,!suicide,!kill,!ban,!ac130,!convert,!hwid,!spec,!discord,!dsc,!vote,!y,!n,!mbs,!ident,!whois,!freeze,!br,!bring,!level,!playerinfo,!pi,!tpt,!goto,!admins,!mods,!ver,!groups,!afk,!poswhitelist,!poswl,!seed,!freeze,!about",
                        "Donater_commands=!help,!h,!rules,!version,!contact,!sources,!guid,!rank,!map,!kick,!drop,!uid,!pm,!report,!s,!suicide,!discord,!dsc,!vote,!y,!n,!mbs,!ident,!level,!admins,!mods,!ver,!afk,!seed,!about",
                        "Curator_commands=!help,!h,!hwid,!guid,!endnuke,!giveweap,!rank,!level,!rules,!sources,!contact,!version,!ver,!add,!takeweap,!addweap,!convert,!maprestart,!maprest,!fastrestart,!fastrest,!spec,!kill,!mods,!admins,!discord,!dsc,!s,!suicide,!gotopos,!report,!stopserver,!removepos,!savepos,!poslist,!ReqMod,!rm,!nextmap,!ammo,!setpos,!getpos,!pm,!switch,!endgame,!goto,!tpt,!bring,!br,!whois,!pi,!playerinfo,!spy,!ac,!team,!ident,!mbs,!n,!y,!vote,!map,!ac130,!unban,!ipban,!dban,!hban,!drop,!kick,!tempban,!tb,!ban,!action,!slot,!unadd,!remove,!groups,!afk,!cfg,!poswhitelist,!poswl,!seed,!generate,!saveplayer,!svpl,!freeze,!about,!anticheat",
                        "Host_commands=!help,!h,!hwid,!guid,!endnuke,!giveweap,!rank,!level,!rules,!sources,!contact,!version,!ver,!add,!takeweap,!addweap,!convert,!maprestart,!maprest,!fastrestart,!fastrest,!spec,!kill,!mods,!admins,!discord,!dsc,!s,!suicide,!gotopos,!report,!stopserver,!removepos,!savepos,!poslist,!ReqMod,!rm,!nextmap,!ammo,!setpos,!getpos,!pm,!switch,!endgame,!goto,!tpt,!bring,!br,!whois,!pi,!playerinfo,!spy,!ac,!team,!ident,!mbs,!n,!y,!vote,!map,!ac130,!unban,!ipban,!dban,!hban,!drop,!kick,!tempban,!tb,!ban,!action,!slot,!unadd,!remove,!groups,!afk,!cfg,!poswhitelist,!poswl,!seed,!generate,!saveplayer,!svpl,!freeze,!about,!anticheat",
                        "Dev_commands=!help,!h,!hwid,!guid,!endnuke,!giveweap,!rank,!level,!rules,!sources,!contact,!version,!ver,!add,!takeweap,!addweap,!convert,!maprestart,!maprest,!fastrestart,!fastrest,!spec,!kill,!mods,!admins,!discord,!dsc,!s,!suicide,!gotopos,!report,!stopserver,!removepos,!savepos,!poslist,!ReqMod,!rm,!nextmap,!ammo,!setpos,!getpos,!pm,!switch,!endgame,!goto,!tpt,!bring,!br,!whois,!pi,!playerinfo,!spy,!ac,!team,!ident,!mbs,!n,!y,!vote,!map,!ac130,!unban,!ipban,!dban,!hban,!drop,!kick,!tempban,!tb,!ban,!action,!slot,!unadd,!remove,!groups,!afk,!cfg,!poswhitelist,!poswl,!seed,!generate,!saveplayer,!svpl,!freeze,!about,!anticheat",
                        "User_level=1",
                        "Friend_level=5",
                        "Donater_level=9",
                        "Moderator_level=10",
                        "StaffMod_level=30",
                        "Helper_level=70",
                        "Curator_level=99",
                        "Admin_level=40",
                        "Friend_level=5",
                        "Dev_level=500",
                        "Curator_level=900",
                        "Host_level=1000",
                        "allow_afk=false",
                        "afk_timeout=300",
                        "max_ping=",
                        "enable_pingchecker=false",
                        "allow_random_seed=false",
                        "enable_anticheat=false",
                        "server_tag=^6LK^7",
                        "pos_whitelist=AgroCenter,TermCenter,BakaCenter,SancCenter,GulcCenter,BoarCenter,ResiCenter,PariCenter,LockCenter,PiazCenter,FallCenter,VillCenter,HardCenter,OutpCenter,LibeCenter,DomeCenter,MissCenter,FounCenter,OasiCenter,ArkaCenter,BootCenter,InterchCenter,CarbCenter,DownCenter,GetaCenter,LookCenter,overCenter,UndeCenter,SeatCenter,BlacCenter,ErosCenter,UturCenter,InterseCenter,VortCenter,DecoCenter,OffSCenter"
                });
            }
        }
        private void AutoMessage()
        {
            Random rng = new Random();
            string fact = null;
            OnInterval(270000, () =>
            {
                int ran = rng.Next(1, 21);
                if (ran == 1)
                {
                    fact = "this script made by 3 different people.";
                }
                if (ran == 2)
                {
                    fact = "^6LiteralLySugaR^7 did some math to write version 14.5";
                }
                if (ran == 3)
                {
                    fact = "the random fact idea was made bc ^6LiteralLySugaR^7 was bored.";
                }
                if (ran == 4)
                {
                    fact = "14.6 got longest pre-release series.";
                }
                if (ran == 5)
                {
                    fact = "this script was made from our ^2AIZ^7 server.";
                }
                if (ran == 6)
                {
                    fact = "^6LiteralLySugaR^7 don't really remember how he meet EC.";
                }
                if (ran == 7)
                {
                    fact = "^6LiSsa^7 is creator of first Modification of this script.";
                }
                if (ran == 8)
                {
                    fact = "im running out of ideas, but ^6random number^7 is ^68^7.";
                }
                if (ran == 9)
                {
                    fact = "commands ^6!h^7 & ^6!groups^7 are most interactive.";
                }
                if (ran == 10)
                {
                    fact = "^6LiteralLySugaR^7 did >147 updates in less than 3 months.";
                }
                if (ran == 11)
                {
                    fact = "^6LiteralLySugaR^7's motto is ^6haha^7.";
                }
                if (ran == 12)
                {
                    fact = "command ^6!mbs^7 was inspired from ^1Black Ops: Cold War^7.";
                }
                if (ran == 13)
                {
                    fact = "^6you cannot be first infected when jumping.";
                }
                if (ran == 14)
                {
                    fact = "^6LiteralLySugaR^7 like to ^6CTRL+C^7 & ^6CTRL+V^7.";
                }
                if (ran == 15)
                {
                    fact = "^6Im3adGirL^7 is the second girl-dev of this script.";
                }
                if (ran == 16)
                {
                    fact = "CAPS-commands are not supported.";
                }
                if (ran == 17)
                {
                    fact = "Infected can throw their nades in survivors.";
                }
                if (ran == 18)
                {
                    fact = "If you say that our server is shit or something, dont try to get back next time c:";
                }
                if (ran == 19)
                {
                    fact = "If you want to leave as infected, you may ask to kick, or just !vote kick";
                }
                if (ran == 20)
                {
                    fact = "Most of spots/out-of-map are fixed.";
                }
                if (ran == 21)
                {
                    fact = "^6SugaR^7 is a magic ^3C#^7 dev. -^6Im3adGirL^7";
                }
                if ((DateTime.Today.Day.ToString() + @"/" + DateTime.Today.Month.ToString() != "23/3") && (DateTime.Today.Day.ToString() + @"/" + DateTime.Today.Month.ToString() != "17/4"))
                {
                    AfterDelay(45000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Join our discord: ^6discord.gg/KMSx2kN7Xu");   //discord.gg/KMSx2kN7Xu
                    });
                    AfterDelay(90000, () =>
                    {
                        Utilities.RawSayAll(TAG + " ^6Do not cheat^7, you will get banned!");
                    });
                    AfterDelay(135000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Type ^6!help^7 to see all available commands.");
                    });
                    AfterDelay(180000, () =>
                    {
                        Utilities.RawSayAll(TAG + " We hope you enjoy the server :3");
                    });
                    AfterDelay(225000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Visit also [^5EC^7] servers!");
                    });
                    AfterDelay(270000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Did you know: " + fact);
                    });
                }
                if ((DateTime.Today.Day.ToString() + @"/" + DateTime.Today.Month.ToString()) == "23/3")
                {
                    AfterDelay(45000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Join our discord: ^6discord.gg/KMSx2kN7Xu");   //discord.gg/KMSx2kN7Xu
                    });
                    AfterDelay(90000, () =>
                    {
                        Utilities.RawSayAll(TAG + " ^6Do not cheat^7, you will get banned!");
                    });
                    AfterDelay(135000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Type ^6!help^7 to see all available commands.");
                    });
                    AfterDelay(180000, () =>
                    {
                        Utilities.RawSayAll(TAG + " We hope you enjoy the server :3");
                    });
                    AfterDelay(225000, () =>
                    {
                        Utilities.RawSayAll(TAG + " ^2Happy Birthday, ^6LiSsa^7!");
                    });
                    AfterDelay(270000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Did you know: " + fact);
                    });
                }
                if ((DateTime.Today.Day.ToString() + @"/" + DateTime.Today.Month.ToString()) == "17/4")
                {
                    AfterDelay(45000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Join our discord: ^6discord.gg/KMSx2kN7Xu");   //discord.gg/KMSx2kN7Xu
                    });
                    AfterDelay(90000, () =>
                    {
                        Utilities.RawSayAll(TAG + " ^6Do not cheat^7, you will get banned!");
                    });
                    AfterDelay(135000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Type ^6!help^7 to see all available commands.");
                    });
                    AfterDelay(180000, () =>
                    {
                        Utilities.RawSayAll(TAG + " We hope you enjoy the server :3");
                    });
                    AfterDelay(225000, () =>
                    {
                        Utilities.RawSayAll(TAG + " ^2Happy Birthday, ^6LiteralLySugaR^7!");
                    });
                    AfterDelay(270000, () =>
                    {
                        Utilities.RawSayAll(TAG + " Did you know: " + fact);
                    });
                }
                return true;
            });
        }
        //private void PlayerFly(Entity player)
        //{
        //    string CurrentGM = GSCFunctions.GetDvar("g_gametype");
        //    if (CurrentGM == "war")
        //    {
        //        if (player.ButtonPressed("vote yes"))
        //        {
        //            var Pos = player.GetOrigin();
        //            if (player.GetField<string>("sessionstate") != "spectator")
        //            {
        //                Utilities.RawSayTo(player, TAG + " You are now spectating.");
        //                player.AllowSpectateTeam("freelook", true);
        //                player.SetField("sessionstate", "spectator");
        //                player.SetContents(0);
        //                player.SetOrigin(Pos);
        //            }
        //            else
        //            {
        //                Utilities.RawSayTo(player, TAG + " You leaved spectator mode.");
        //                player.AllowSpectateTeam("freelook", false);
        //                player.SetField("sessionstate", "playing");
        //                player.SetContents(100);
        //                player.SetOrigin(Pos);
        //            }
        //        }
        //    }
        //}
        private void TellClient(Entity player, string message)
        {
            Utilities.RawSayTo(player, message);
        }
        private string FindMapByName(string name)
        {
            int num = 0;
            string str1 = (string)null;
            foreach (string str2 in this.maplist)
            {
                if (0 <= str2.IndexOf(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    str1 = str2;
                    ++num;
                }
            }
            if (num <= 1 && num == 1)
                return str1;
            else
                return (string)null;
        }
        private string FindPosByName(string name)
        {
            int num = 0;
            string str1 = (string)null;
            string str2 = (string)null;
            foreach (string str3 in File.ReadAllLines("scripts\\GPIv3\\PosList.txt"))
            {
                if (str3.StartsWith("posname"))
                {
                    str2 = str3.Split(new char[1]
                    {
                        '='
                    })[1];
                }
                if (0 <= str2.IndexOf(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    str1 = str2;
                    ++num;
                }
            }
            if (num <= 1 && num == 1)
            {
                return str1;
            }
            else { return (string)null; }
        }
        private int GetGroupLevel(string group)
        {
            string str = null;
            foreach (string string1 in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (string1.StartsWith(group + "_level"))
                {
                    str = string1.Split(new char[1]
                    {
                        '='
                    })[1];
                }
            }
            int level = Convert.ToInt32(str);
            return level;
        }
        private void AddToGroup(string group, Entity player, Entity entity)
        {
            string str1 = (string)null;
            string str2 = (string)null;
            foreach (string str3 in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str3.StartsWith("groups"))
                    str1 = str3.Split(new char[1]
                    {
                        '='
                    })[1];
            }
            foreach (string str3 in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str3.StartsWith(group + "_xuids"))
                    str2 = str3.Split(new char[1]
                    {
                        '='
                    })[1];
            }
            if (!str1.Contains(group))
                this.TellClient(player, "^2That group does not exist!");
            else if (str2.Contains(entity.GUID.ToString()))
            {
                this.TellClient(player, "^1That User is already in that group!");
            }
            else
            {
                string str3 = str2;
                string str4 = str2 + "," + entity.GUID.ToString();
                string str5 = File.ReadAllText("scripts\\GPIv3\\GPIconfig.txt");
                File.Delete("scripts\\GPIconfig.txt");
                using (StreamWriter streamWriter = new StreamWriter("scripts\\GPIv3\\GPIconfig.txt", true))
                {
                    string str6 = str5.Replace(group + "_xuids=" + str3, group + "_xuids=" + str4);
                    streamWriter.WriteLine(str6);
                }
            }
        }
        private void UnAddToGroup(string group, Entity player, Entity entity)
        {
            string str1 = (string)null;
            string str2 = (string)null;
            foreach (string str3 in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str3.StartsWith("groups"))
                    str1 = str3.Split(new char[1]
                    {
                        '='
                    })[1];
            }
            foreach (string str3 in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str3.StartsWith(group + "_xuids"))
                    str2 = str3.Split(new char[1]
                    {
                        '='
                    })[1];
            }
            if (!str1.Contains(group))
                this.TellClient(player, "^2That group does not exist!");
            else if (!str2.Contains(entity.GUID.ToString()))
            {
                this.TellClient(player, "^2Couldn't find the use in this group!");
            }
            else
            {
                string str3 = str2;
                string str4 = str2.Replace(entity.GUID.ToString(), "");
                string str5 = File.ReadAllText("scripts\\GPIv3\\GPIconfig.txt");
                File.Delete("scripts\\GPIv3\\GPIconfig.txt");
                using (StreamWriter streamWriter = new StreamWriter("scripts\\GPIv3\\GPIconfig.txt", true))
                {
                    string str6 = str5.Replace(group + "_xuids=" + str3, group + "_xuids=" + str4);
                    streamWriter.WriteLine(str6);
                    Utilities.RawSayAll(TAG + " ^6" + entity.Name + "^7 has been Removed from ^6" + group + "^7 group.");
                }
            }
        }
        public string GetGroup(string xuid)
        {
            string str = "User";
            if (this.UserGroup.ContainsKey(xuid))
                this.UserGroup.TryGetValue(xuid, out str);
            return str;
        }
        private bool GetPermission()
        {
            int num = 0;
            StreamReader streamReader1 = new StreamReader("scripts\\GPIv3\\GPIconfig.txt");
            string str1 = streamReader1.ReadLine();
            if (str1 == null)
                return false;
            streamReader1.Close();
            string str2 = str1.Split(new char[1]
            {
                '='
            })[1];
            this.listG = str2;
            string str3 = str2;
            char[] chArray1 = new char[1]
            {
                ','
            };
            foreach (string key in str3.Split(chArray1))
            {
                StreamReader streamReader2 = new StreamReader("scripts\\GPIv3\\GPIconfig.txt");
                string str4;
                while ((str4 = streamReader2.ReadLine()) != null)
                {
                    if (str4.StartsWith(key + "_xuids"))
                        this.Groups.Add(key, str4.Split(new char[1]
                        {
                            '='
                        })[1]);
                    if (str4.StartsWith(key + "_commands"))
                        this.gCommands.Add(key, str4.Split(new char[1]
                        {
                            '='
                        })[1]);
                    ++num;
                }
            }
            foreach (KeyValuePair<string, string> keyValuePair in this.Groups)
            {
                string str4 = keyValuePair.Value;
                char[] chArray2 = new char[1]
                {
                    ','
                };
                foreach (string key in str4.Split(chArray2))
                {
                    if (this.UserGroup.ContainsKey(key))
                        Print("The XUID: " + key + " is in multiple groups.", new object[0]);
                    else
                        this.UserGroup.Add(key, keyValuePair.Key);
                }
            }
            return true;
        }
        public bool canUseCommand(Entity player, string command)
        {
            string str1;
            if (this.gCommands.TryGetValue(this.GetGroup(player.GUID.ToString()), out str1))
            {
                if (str1.Equals("*ALL*"))
                    return true;
                string str2 = str1;
                char[] chArray = new char[1]
                {
                    ','
                };
                foreach (string str3 in str2.Split(chArray))
                {
                    if (str3.ToLower().Equals(command.ToLower()))
                        return true;
                }
            }
            return false;
        }
        //private void NewDSPL()
        //{
        //    int count = File.ReadAllLines("admin\\infected.dspl").Length;
        //    File.Create("admin\\Lines.txt");
        //    File.WriteAllLines("admin\\Lines.txt", new string[2]
        //    {
        //                    "byPlayer=true",
        //                    count.ToString()
        //    });
        //}
        internal string GetRankByName(string name)
        {
            string str = "User";
            Entity byName = this.FindByName(name);
            if (byName != null)
                str = this.GetGroup(byName.GUID.ToString());
            return str;
        }
        private static void Print(string format, params object[] p)
        {
            Log.Write(LogLevel.All, format, p);
        }
        Entity FindByName(string name)
        {

            int cont = 0;
            Entity player = null;
            foreach (Entity Player in Entitys)
            {
                if (0 <= Player.Name.IndexOf(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    player = Player;
                    cont++;
                }
            }
            if (cont > 1) { return null; }
            if (cont == 1) { return player; }

            return null;
        }
        //private void DSPLback()
        //{
        //    string str1 = (string)null;
        //    int newInt = new int();
        //    int ints = 1;
        //    string str3 = (string)null;
        //    if (File.Exists("admin\\Lines.txt"))
        //    {
        //        foreach (string str in File.ReadAllLines("admin\\Lines.txt"))
        //        {
        //            if (str.Contains(ints.ToString()))
        //            {
        //                str1 = str;
        //            }
        //        }
        //        foreach (string str2 in File.ReadAllLines("admin\\Lines.txt"))
        //        {
        //            if (str2.StartsWith("byPlayer"))
        //            {
        //                str3 = str2.Split(new char[1]
        //                {
        //                '='
        //                })[1];
        //            }
        //        }
        //        newInt = Convert.ToInt32(str1);
        //        if (newInt <= 2 && str3 == "true")
        //        {
        //            AfterDelay(1000, () =>
        //            {
        //                File.WriteAllLines("admin\\infected.dspl", new string[9]
        //                {
        //                "*,Cinf1,1",
        //                "*,Cinf2,1",
        //                "*,Cinf3,1",
        //                "*,Cinf4,1",
        //                "*,Cinf6,1",
        //                "*,Cinf7,1",
        //                "*,Cinf8,1",
        //                "*,Cinf9,1",
        //                "*,Cinf10,1"
        //                });
        //            });
        //            File.Delete("admin\\Lines.txt");
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        private BaseScript.EventEat CommandFilter(Entity player, string message)
        {
            string reason = "";
            string pmmessage = "";
            string tmsg = "";
            string cmsg = "";

            string[] strArray1 = message.Split(' ');
            if (strArray1 == null)
            {
                return EventEat.EatNone;
            }
            if (message.StartsWith("!") && !canUseCommand(player, strArray1[0]))
            {
                Utilities.RawSayTo(player, "You are ^1NOT ALLOWED^7 to use this command.");
                return EventEat.EatGame;
            }
            if (message.StartsWith("!") && canUseCommand(player, strArray1[0]))
            {
                for (int i = 0; i < strArray1.Length; i++)
                {
                    cmsg += " " + strArray1[i];
                }
                foreach (Entity entity in kgbLogic.KGB)
                {
                    this.kgbLogic.KgbLogic(entity, player, cmsg);
                }
            }
            long guid;
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!slot"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Your slot is: ^6" + player.GetEntityNumber() + "^7.");
                }
                if (strArray1.Length == 2)
                {
                    Entity Ent = FindByName(strArray1[1]);
                    if (Ent == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        Utilities.RawSayTo(player, "^6" + Ent.Name + " ^7slot is: ^6" + Ent.GetEntityNumber() + "^7.");
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            //if (strArray1[0].Equals("!action"))
            //{
            //    if (strArray1.Length <= 2 || strArray1.Length >= 4)
            //    {
            //        Utilities.RawSayTo(player, "Format: ^1!action^6 [slot] <kick/ban/tban>");
            //    }
            //    if (strArray1.Length == 3)
            //    {
            //        foreach (Entity toslot in Players)
            //        {
            //            if (strArray1[1] == toslot.GetEntityNumber().ToString())
            //            {
            //                ConLog.PlayerUseCommandOnEv(player, strArray1[0], toslot);
            //                if (strArray1[2].Equals("kick"))
            //                {
            //                    IsKicked.Add(toslot.Name);
            //                    //reason = "^6" + player.Name + " ^7kicked you from the server...";
            //                    Utilities.ExecuteCommand("kickclient " + strArray1[1]);
            //                    //reason = "";
            //                }
            //                if (strArray1[2].Equals("ban"))
            //                {
            //                    IsKicked.Add(toslot.Name);
            //                    //reason = "^6" + player.Name + " ^1PERM-Banned^7 you from the server...";
            //                    Utilities.ExecuteCommand("banclient " + strArray1[1]);
            //                    //reason = "";
            //                    File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + toslot.GUID.ToString() + ".txt", new string[1]
            //                    {
            //                            "name" + toslot.Name
            //                    });
            //                }
            //                if (strArray1[2].Equals("tban"))
            //                {
            //                    IsKicked.Add(toslot.Name);
            //                    //reason = "^6" + player.Name + " ^3TEMP-Banned^7 you from the server...";
            //                    Utilities.ExecuteCommand("tempbanclient " + strArray1[1]);
            //                    //reason = "";
            //                    File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + toslot.GUID.ToString() + ".txt", new string[1]
            //                    {
            //                            "name" + toslot.Name
            //                    });
            //                }
            //            }
            //            break;
            //        }
            //    }
            //    return EventEat.EatGame;
            //}
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!tb") || strArray1[0].Equals("!tempban"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!tempban/tb ^6<nickname> <reason>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    reason = "You have been ^6TEMP-BANNED^7 from the server.";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            IsKicked.Add(intruder.Name);
                            ConLog.PlayerBannedEv(intruder, player, reason, 2);
                            Utilities.ExecuteCommand("tempbanclient " + intruder.GetEntityNumber() + " \"" + reason + "\"");
                            File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + intruder.GUID.ToString() + ".txt", new string[1]
                            {
                            "name" + intruder.Name
                            });
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                if (strArray1.Length >= 3)
                {
                    reason = "";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Playergroup = GetRankByName(player.Name);
                        string inflictorgroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Playergroup);
                        int Ilevel = GetGroupLevel(inflictorgroup);
                        if (Plevel > Ilevel)
                        {
                            for (int i = 2; i < strArray1.Length; i++)
                            {
                                reason += " " + strArray1[i];
                            }
                            IsKicked.Add(intruder.Name);
                            ConLog.PlayerBannedEv(intruder, player, reason, 2);
                            Utilities.ExecuteCommand("tempbanclient " + intruder.GetEntityNumber() + " \"" + reason + "\"");
                            File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + intruder.GUID.ToString() + ".txt", new string[1]
                            {
                            "name=" + intruder.Name
                            });
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ban"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!ban ^6<nickname> <reason>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    reason = "You have been ^1PERM-BANNED^7 from the server.";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            string IPAD = intruder.IP.Address.ToString();
                            string name = intruder.Name.ToString();
                            string HWID = intruder.HWID.ToString();
                            string GUID = intruder.GUID.ToString();
                            string XUID = intruder.GetXUID().ToString();
                            File.WriteAllLines("scripts\\BanDB\\" + intruder.GUID.ToString() + ".txt", new string[5]
                            {
                                "ip=" + IPAD,
                                "name=" + name,
                                "hwid=" + HWID,
                                "guid=" + GUID,
                                "xuid=" + XUID
                            });
                            IsKicked.Add(intruder.Name);
                            ConLog.PlayerBannedEv(intruder, player, reason, 1);
                            Utilities.ExecuteCommand("banclient " + intruder.GetEntityNumber() + " \"" + reason + "\"");
                            File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + intruder.GUID.ToString() + ".txt", new string[1]
                            {
                            "name" + intruder.Name
                            });
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                if (strArray1.Length >= 3)
                {
                    reason = "";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            for (int i = 2; i < strArray1.Length; i++)
                            {
                                reason += " " + strArray1[i];
                            }
                            string IPAD = intruder.IP.Address.ToString();
                            string name = intruder.Name.ToString();
                            string HWID = intruder.HWID.ToString();
                            string GUID = intruder.GUID.ToString();
                            string XUID = intruder.GetXUID().ToString();
                            File.WriteAllLines("scripts\\BanDB\\" + intruder.GUID.ToString() + ".txt", new string[5]
                            {
                                "ip=" + IPAD,
                                "name=" + name,
                                "hwid=" + HWID,
                                "guid=" + GUID,
                                "xuid=" + XUID
                            });
                            IsKicked.Add(intruder.Name);
                            ConLog.PlayerBannedEv(intruder, player, reason, 1);
                            Utilities.ExecuteCommand("banclient " + intruder.GetEntityNumber() + " \"" + reason + "\"");
                            File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + intruder.GUID.ToString() + ".txt", new string[1]
                            {
                            "name=" + intruder.Name
                            });
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!kick"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!kick ^6<nickname> <reason>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    reason = "You have been kicked from the server...";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            IsKicked.Add(intruder.Name);
                            ConLog.PlayerKicked(intruder, player, reason);
                            Utilities.ExecuteCommand("kickclient " + intruder.GetEntityNumber() + " kicked by ^6" + player.Name + " ^7reason: \"" + reason + "\"");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                if (strArray1.Length >= 3)
                {
                    reason = "";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            IsKicked.Add(intruder.Name);
                            for (int i = 2; i < strArray1.Length; i++)
                            {
                                reason += " " + strArray1[i];
                            }
                            ConLog.PlayerKicked(intruder, player, reason);
                            Utilities.ExecuteCommand("kickclient " + intruder.GetEntityNumber() + " kicked by ^6" + player.Name + " ^7reason: \"" + reason + "\"");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!drop"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!drop ^6<nickname> <reason>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    reason = "You have been kicked from the server...";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            IsKicked.Add(intruder.Name);
                            ConLog.PlayerKicked(intruder, player, reason);
                            Utilities.ExecuteCommand("dropclient " + intruder.GetEntityNumber() + " Dropped by ^6" + player.Name + " ^7reason: \"" + reason + "\"");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                if (strArray1.Length >= 3)
                {
                    reason = "";
                    Entity intruder = FindByName(strArray1[1]);
                    if (intruder == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(intruder.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            IsKicked.Add(intruder.Name);
                            for (int i = 2; i < strArray1.Length; i++)
                            {
                                reason += " " + strArray1[i];
                            }
                            ConLog.PlayerKicked(intruder, player, reason);
                            Utilities.ExecuteCommand("dropclient " + intruder.GetEntityNumber() + " Dropped by ^6" + player.Name + " ^7reason: \"" + reason + "\"");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!dban"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!dban ^6<player>");
                }
                if (strArray1.Length == 2)
                {
                    Entity ipBan = FindByName(strArray1[1]);
                    if (ipBan == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        IsKicked.Add(ipBan.Name);
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(ipBan.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            string IP = ipBan.IP.Address.ToString();
                            string name = ipBan.Name.ToString();
                            string HWID = ipBan.HWID.ToString();
                            string GUID = ipBan.GUID.ToString();
                            string XUID = ipBan.GetXUID().ToString();
                            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\BDB\\alldata.txt", true);
                            sw.WriteLine(IP);
                            sw.WriteLine(name);
                            sw.WriteLine(XUID);
                            sw.WriteLine(GUID);
                            sw.WriteLine(HWID);
                            sw.WriteLine("===================================================");
                            sw.Flush();
                            sw.Close();
                            //StreamWriter streamWriter = new StreamWriter("scripts\\Banlist\\" + ipBan.Name + ".txt", false);
                            //streamWriter.WriteLine("ip=" + IP);
                            //streamWriter.WriteLine("name=" + ipBan.Name);
                            //streamWriter.WriteLine("hwid=" + ipBan.HWID);
                            //streamWriter.WriteLine("guid=" + ipBan.GUID);
                            //streamWriter.WriteLine("xuid=" + ipBan.GetXUID());
                            ConLog.PlayerBannedEv(ipBan, player, null, 4);
                            Utilities.ExecuteCommand("dropclient " + ipBan.GetEntityNumber() + " You are data banned.");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!hban"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!hban ^6<player>");
                }
                if (strArray1.Length == 2)
                {
                    Entity ipBan = FindByName(strArray1[1]);
                    if (ipBan == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        IsKicked.Add(ipBan.Name);
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(ipBan.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            string IP = ipBan.IP.Address.ToString();
                            string name = ipBan.Name.ToString();
                            string HWID = ipBan.HWID.ToString();
                            string GUID = ipBan.GUID.ToString();
                            string XUID = ipBan.GetXUID().ToString();
                            File.WriteAllLines("scripts\\GPIv3\\HBanlist\\" + ipBan.GUID.ToString() + ".txt", new string[5]
                                {
                                "ip=" + IP,
                                "name=" + name,
                                "hwid=" + HWID,
                                "guid=" + GUID,
                                "xuid=" + XUID
                                });
                            File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + ipBan.GUID.ToString() + ".txt", new string[5]
                                {
                                "ip=" + IP,
                                "name=" + name,
                                "hwid=" + HWID,
                                "guid=" + GUID,
                                "xuid=" + XUID
                                });
                            //StreamWriter streamWriter = new StreamWriter("scripts\\Banlist\\" + ipBan.Name + ".txt", false);
                            //streamWriter.WriteLine("ip=" + IP);
                            //streamWriter.WriteLine("name=" + ipBan.Name);
                            //streamWriter.WriteLine("hwid=" + ipBan.HWID);
                            //streamWriter.WriteLine("guid=" + ipBan.GUID);
                            //streamWriter.WriteLine("xuid=" + ipBan.GetXUID());
                            ConLog.PlayerBannedEv(ipBan, player, null, 4);
                            Utilities.ExecuteCommand("dropclient " + ipBan.GetEntityNumber() + " You are data banned.");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ipban"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!ipban ^6<player>");
                }
                if (strArray1.Length == 2)
                {
                    Entity ipBan = FindByName(strArray1[1]);
                    if (ipBan == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        IsKicked.Add(ipBan.Name);
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(ipBan.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            string IP = ipBan.IP.Address.ToString();
                            File.WriteAllLines("scripts\\GPIv3\\IPBanlist\\" + IP + ".txt", new string[2]
                                {
                                "ip=" + IP,
                                "name=" + ipBan.Name
                                });
                            string name = ipBan.Name.ToString();
                            string HWID = ipBan.HWID.ToString();
                            string GUID = ipBan.GUID.ToString();
                            string XUID = ipBan.GetXUID().ToString();
                            File.WriteAllLines("scripts\\GPIv3\\Banlist\\" + ipBan.GUID.ToString() + ".txt", new string[5]
                                {
                                "ip=" + IP,
                                "name=" + name,
                                "hwid=" + HWID,
                                "guid=" + GUID,
                                "xuid=" + XUID
                                });
                            //StreamWriter streamWriter = new StreamWriter("scripts\\IPBanlist\\" + ipBan.Name + ".txt", false);
                            //streamWriter.WriteLine("ip=" + IP);
                            //streamWriter.WriteLine("name=" + ipBan.Name);
                            ConLog.PlayerBannedEv(ipBan, player, null, 3);
                            Utilities.ExecuteCommand("dropclient " + ipBan.GetEntityNumber() + " You are IP-banned.");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!unban"))
            {
                if (strArray1.Length == 1 && strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!unban ^6[HWID]");
                    Utilities.RawSayTo(player, "WORK ONLY FOR: ^6TEMPBAN^7, ^6BAN^7.");
                }
                if (strArray1.Length == 2)
                {
                    ConLog.PlayerUnbanEv(player, strArray1[1]);
                    Utilities.ExecuteCommand("unban " + strArray1[1]);
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            //if (strArray1[0].Equals("!aimbot"))
            //{
            //    Aimbot.OnAimCommand(player);
            //    return EventEat.EatGame;
            //}
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ac130"))
            {
                string firstweapon = player.CurrentWeapon;
                if (strArray1.Length == 1)
                {
                    player.GiveWeapon("ac130_25mm_mp");
                    player.SwitchToWeapon("ac130_25mm_mp");

                    AfterDelay(60000, (Action)(() =>
                    {
                        player.SwitchToWeapon(firstweapon);
                        player.TakeWeapon("ac130_25mm_mp");
                    }));
                }
                if (strArray1[1].Equals("25"))
                {
                    player.GiveWeapon("ac130_25mm_mp");
                    player.SwitchToWeapon("ac130_25mm_mp");

                    AfterDelay(60000, (Action)(() =>
                    {
                        player.SwitchToWeapon(firstweapon);
                        player.TakeWeapon("ac130_25mm_mp");
                    }));
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1[1].Equals("40"))
                {
                    player.GiveWeapon("ac130_40mm_mp");
                    player.SwitchToWeapon("ac130_40mm_mp");

                    AfterDelay(60000, (Action)(() =>
                    {
                        player.SwitchToWeapon(firstweapon);
                        player.TakeWeapon("ac130_40mm_mp");
                    }));
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1[1].Equals("105"))
                {
                    player.GiveWeapon("ac130_105mm_mp");
                    player.SwitchToWeapon("ac130_105mm_mp");

                    AfterDelay(60000, (Action)(() =>
                    {
                        player.SwitchToWeapon(firstweapon);
                        player.TakeWeapon("ac130_105mm_mp");
                    }));
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1[1].Equals("all"))
                {
                    Utilities.RawSayAll(TAG + " All player are given ^6ac130_40mm_mp^7 for 20 seconds!");
                    foreach (Entity ac130player in Entitys)
                    {
                        string acfirstweapon = ac130player.CurrentWeapon;

                        ac130player.GiveWeapon("ac130_40mm_mp");
                        ac130player.SwitchToWeapon("ac130_40mm_mp");

                        AfterDelay(20000, (Action)(() =>
                        {
                            ac130player.SwitchToWeapon(acfirstweapon);
                            ac130player.TakeWeapon("ac130_40mm_mp");
                            Utilities.RawSayTo(ac130player, TAG + " 20 seconds are over.");
                        }));
                    }
                    return BaseScript.EventEat.EatGame;
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!map"))
            {
                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Format: ^6!map <mapname>");
                    return BaseScript.EventEat.EatGame;
                }
                string mapByName = this.FindMapByName(strArray1[1]);
                if (mapByName == null)
                {
                    Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found or ^6multiple^7 were found...");
                    return BaseScript.EventEat.EatGame;
                }
                else
                {
                    ConLog.PlayerMapEv(player, mapByName);
                    if (mapByName == "dome")
                        Utilities.ExecuteCommand("map mp_dome");
                    else if (mapByName == "bootleg")
                        Utilities.ExecuteCommand("map mp_bootleg");
                    else if (mapByName == "hardhat")
                        Utilities.ExecuteCommand("map mp_hardhat");
                    else if (mapByName == "lockdown" || mapByName == "alpha")
                        Utilities.ExecuteCommand("map mp_alpha");
                    else if (mapByName == "mission" || mapByName == "bravo")
                        Utilities.ExecuteCommand("map mp_bravo");
                    else if (mapByName == "carbon")
                        Utilities.ExecuteCommand("map mp_carbon");
                    else if (mapByName == "downturn" || mapByName == "exchange")
                        Utilities.ExecuteCommand("map mp_exchange");
                    else if (mapByName == "interchange")
                        Utilities.ExecuteCommand("map mp_interchange");
                    else if (mapByName == "fallen" || mapByName == "lambeth")
                        Utilities.ExecuteCommand("map mp_lambeth");
                    else if (mapByName == "bakaraa" || mapByName == "mogadishu")
                        Utilities.ExecuteCommand("map mp_mogadishu");
                    else if (mapByName == "resistance" || mapByName == "paris")
                        Utilities.ExecuteCommand("map mp_paris");
                    else if (mapByName == "arkaden" || mapByName == "plaza2")
                        Utilities.ExecuteCommand("map mp_plaza2");
                    else if (mapByName == "outpost" || mapByName == "radar")
                        Utilities.ExecuteCommand("map mp_radar");
                    else if (mapByName == "seatown")
                        Utilities.ExecuteCommand("map mp_seatown");
                    else if (mapByName == "underground")
                        Utilities.ExecuteCommand("map mp_underground");
                    else if (mapByName == "village")
                        Utilities.ExecuteCommand("map mp_village");
                    else if (mapByName == "terminal")
                        Utilities.ExecuteCommand("map mp_terminal_cls");
                    else if (mapByName == "overwatch")
                        Utilities.ExecuteCommand("map mp_overwatch");
                    else if (mapByName == "liberation" || mapByName == "park")
                        Utilities.ExecuteCommand("map mp_park");
                    else if (mapByName == "pizza" || mapByName == "italy")
                        Utilities.ExecuteCommand("map mp_italy");
                    else if (mapByName == "blackbox" || mapByName == "morningwood")
                        Utilities.ExecuteCommand("map mp_morningwood");
                    else if (mapByName == "sanctuary" || mapByName == "meteora")
                        Utilities.ExecuteCommand("map mp_meteora");
                    else if (mapByName == "foundation" || mapByName == "cement")
                        Utilities.ExecuteCommand("map mp_cement");
                    else if (mapByName == "oasis" || mapByName == "qadeem")
                        Utilities.ExecuteCommand("map mp_qadeem");
                    else if (mapByName == "aground")
                        Utilities.ExecuteCommand("map mp_aground_ss");
                    else if (mapByName == "erosion" || mapByName == "courtyard")
                        Utilities.ExecuteCommand("map mp_courtyard_ss");
                    else if (mapByName == "gateway" || mapByName == "hillside")
                        Utilities.ExecuteCommand("map mp_hillside_ss");
                    else if (mapByName == "lookout" || mapByName == "restrepo")
                        Utilities.ExecuteCommand("map mp_restrepo_ss");
                    else if (mapByName == "uturn" || mapByName == "burn")
                        Utilities.ExecuteCommand("map mp_burn_ss");
                    else if (mapByName == "intersection" || mapByName == "crosswalk")
                        Utilities.ExecuteCommand("map mp_crosswalk_ss");
                    else if (mapByName == "vortex" || mapByName == "six")
                        Utilities.ExecuteCommand("map mp_six_ss");
                    else if (mapByName == "decommission" || mapByName == "shipbreaker")
                        Utilities.ExecuteCommand("map mp_shipbreaker");
                    else if (mapByName == "offshore" || mapByName == "roughneck")
                        Utilities.ExecuteCommand("map mp_roughneck");
                    else if (mapByName == "gulch" || mapByName == "moab")
                        Utilities.ExecuteCommand("map mp_moab");
                    else if (mapByName == "boardwalk")
                        Utilities.ExecuteCommand("map mp_boardwalk");
                    else if (mapByName == "parish" || mapByName == "nola")
                        Utilities.ExecuteCommand("map mp_nola");
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            //if (strArray1[0].Equals("!mod"))
            //{
            //    if (strArray1.Length == 1 || strArray1.Length >= 3)
            //    {
            //        Utilities.RawSayTo(player, "Format: ^1!mod ^6<edit,play,done>");
            //    }
            //    if (strArray1.Length == 2)
            //    {
            //        if (strArray1[1].Equals("edit"))
            //        {
            //            string CurrMap = GSCFunctions.GetDvar("mapname");

            //            File.WriteAllLines("admin\\infected.dspl", new string[1]
            //                {
            //                    CurrMap + ",haha,1000"
            //                });
            //            Utilities.RawSayAll(TAG + " Server entered ^6EDIT MODE^7.");
            //            Utilities.ExecuteCommand("start_map_rotate");
            //        }
            //        if (strArray1[1].Equals("play"))
            //        {
            //            string CurrMap = GSCFunctions.GetDvar("mapname");

            //            string toRemove = CurrMap + ",haha,1000";
            //            File.WriteAllLines("admin\\infected.dspl", new string[1]
            //                {
            //                    CurrMap + ",Cinf7,1000"
            //                });
            //            Utilities.RawSayAll(TAG + " Server is on ^6TEST MODE^7.");
            //            Utilities.ExecuteCommand("start_map_rotate");
            //        }
            //        if (strArray1[1].Equals("done"))
            //        {
            //            string CurrMap = GSCFunctions.GetDvar("mapname");

            //            string toRemove = CurrMap + ",Cinf1,1000";
            //            File.WriteAllLines("admin\\infected.dspl", new string[9]
            //                {
            //                    "*,Cinf1,1",
            //                    "*,Cinf2,1",
            //                    "*,Cinf3,1",
            //                    "*,Cinf4,1",
            //                    "*,Cinf6,1",
            //                    "*,Cinf7,1",
            //                    "*,Cinf8,1",
            //                    "*,Cinf9,1",
            //                    "*,Cinf10,1",
            //                });
            //            Utilities.RawSayAll(TAG + " Server leaved ^6EDIT MODE^7.");
            //            Utilities.ExecuteCommand("start_map_rotate");
            //        }
            //    }
            //    return BaseScript.EventEat.EatGame;
            //}
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!vote"))
            {
                this.vote.time = 30;
                if (strArray1.Length <= 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!vote ^6<map,kick> <parameter>");
                    return EventEat.EatGame;
                }
                if (this.vote.inProgress)
                {
                    Utilities.RawSayTo(player, TAG + " ^6Another vote is in progress.");
                    return EventEat.EatGame;
                }
                if (strArray1[1].Equals("kick"))
                {
                    if (FindByName(strArray1[2]) == null)
                    {
                        Utilities.RawSayTo(player, "^1User not found or multiple were found.");
                        return EventEat.EatGame;
                    }
                    else
                    {
                        vote.agree = new List<Entity>();
                        vote.contro = new List<Entity>();
                        vote.plKick = FindByName(strArray1[2]);
                        vote.type = "kick";
                        vote.inProgress = false;
                        foreach (Entity currplayer in Players)
                        {

                            HudElem pvote = HudElem.CreateFontString(currplayer, HudSmall, 0.8f);
                            pvote.SetPoint("TOP", "TOP", 0, 450);
                            pvote.SetText("A player started a vote!");
                            pvote.GlowColor = new Vector3(0f, 0f, 1f);
                            pvote.GlowAlpha = 1.0f;
                            pvote.SetPulseFX(100, 3500, 100);
                        }
                        AfterDelay(3500, () => { vote.inProgress = true; });
                        return EventEat.EatGame;
                    }
                }
                if (strArray1[1].Equals("map"))
                {

                    int mapex = 0;
                    foreach (KeyValuePair<int, string> curmap in Maps)
                    {
                        if (curmap.Value.Split('=')[0] == strArray1[2])
                        {
                            mapex = 1;
                        }
                    }
                    if (mapex == 0)
                    {
                        Utilities.RawSayTo(player, "^1This map does not exist.");
                        return EventEat.EatGame;
                    }
                    else
                    {
                        vote.agree = new List<Entity>();
                        vote.contro = new List<Entity>();
                        vote.plKick = FindByName(strArray1[2]);
                        vote.obj = strArray1[2];
                        vote.type = "map";
                        vote.inProgress = false;
                        foreach (Entity currplayer in Players)
                        {

                            HudElem pvote = HudElem.CreateFontString(currplayer, HudSmall, 0.8f);
                            pvote.SetPoint("TOP", "TOP", 0, 450);
                            pvote.SetText("A player started a vote!");
                            pvote.GlowColor = new Vector3(0f, 0f, 1f);
                            pvote.GlowAlpha = 1.0f;
                            pvote.SetPulseFX(100, 3500, 100);
                        }
                        AfterDelay(3500, () => { vote.inProgress = true; });
                        return EventEat.EatGame;
                    }
                }
                return EventEat.EatGame;
            }
            if (strArray1[0].Equals("!y"))
            {
                if (!this.vote.inProgress)
                {
                    Utilities.RawSayTo(player, "^6No vote in progress, type !vote to start a vote.");
                    return BaseScript.EventEat.EatGame;
                }
                foreach (Entity entity in this.vote.agree)
                {
                    if (entity.Name == player.Name)
                    {
                        Utilities.RawSayTo(player, "^6You already voted.");
                        return BaseScript.EventEat.EatNone;
                    }
                }
                this.vote.agree.Add(player);
                return BaseScript.EventEat.EatGame;
            }
            if (strArray1[0].Equals("!n"))
            {
                if (!this.vote.inProgress)
                {
                    Utilities.RawSayTo(player, "^6No vote in progress, type !vote to start a vote.");
                    return BaseScript.EventEat.EatGame;
                }
                foreach (Entity entity in this.vote.contro)
                {
                    if (entity.Name == player.Name)
                    {
                        Utilities.RawSayTo(player, "^6You already voted.");
                        return BaseScript.EventEat.EatNone;
                    }
                }
                this.vote.contro.Add(player);
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!mbs"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!mbs ^6<kgb,mi6,cia,none>");
                }
                if (strArray1.Length >= 2)
                {
                    MBS.AddToFolder(player, strArray1[1]);
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ident"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!ident ^6<player>");
                }
                if (strArray1.Length == 2)
                {
                    Entity ToFind = FindByName(strArray1[1]);
                    if (ToFind == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        if (MBS.KGBs.Contains(ToFind))
                        {
                            Utilities.RawSayTo(player, TAG + " ^1" + ToFind.Name + " ^7identified as KGB agent.");
                        }
                        if (MBS.MI6s.Contains(ToFind))
                        {
                            Utilities.RawSayTo(player, TAG + " ^5" + ToFind.Name + " ^7identified as MI6 agent.");
                        }
                        if (MBS.CIAs.Contains(ToFind))
                        {
                            Utilities.RawSayTo(player, TAG + " ^4" + ToFind.Name + " ^7identified as CIA agent.");
                        }
                        else if (!MBS.KGBs.Contains(ToFind) && !MBS.MI6s.Contains(ToFind) && !MBS.CIAs.Contains(ToFind))
                        {
                            Utilities.RawSayTo(player, TAG + " Unable to identify ^6" + ToFind.Name + " ^7..");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!team"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!team ^6<message>");
                }
                if (strArray1.Length >= 2)
                {
                    for (int i = 1; i < strArray1.Length; i++)
                    {
                        tmsg += " " + strArray1[i];
                    }
                    if (MBS.KGBs.Contains(player))
                    {
                        foreach (Entity all in MBS.KGBs)
                        {
                            Utilities.RawSayTo(all, "[^1KGB^7] ^1" + player.Name + "^7: " + tmsg);
                        }
                    }
                    if (MBS.MI6s.Contains(player))
                    {
                        foreach (Entity all in MBS.MI6s)
                        {
                            Utilities.RawSayTo(all, "[^5MI6^7] ^5" + player.Name + "^7: " + tmsg);
                        }
                    }
                    if (MBS.CIAs.Contains(player))
                    {
                        foreach (Entity all in MBS.CIAs)
                        {
                            Utilities.RawSayTo(all, "[^4CIA^7] ^4" + player.Name + "^7: " + tmsg);
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ac"))
            {
                tmsg = "";
                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Fomat: ^1!ac ^6<message>");
                }
                else
                {
                    for (int i = 1; i < strArray1.Length; i++)
                    {
                        tmsg += " " + strArray1[i];
                    }
                    foreach (Entity entityAC in AdminChat)
                    {
                        Utilities.RawSayTo(entityAC, "[^;AdminChat^7] ^;" + player.Name + "^7: " + tmsg);
                    }

                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!afk"))
            {
                OnAfkCommand(player);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!spy"))
            {
                kgbLogic.OnKgbCommand(player);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!whois") || strArray1[0].Equals("!pi") || strArray1[0].Equals("!playerinfo"))
            {
                string ServerPrefix = TAG + "";
                if (strArray1.Length <= 1)
                {
                    Utilities.RawSayTo(player, ServerPrefix + " ^7Format: ^1!playerinfo ^2<playername>");
                }
                if (strArray1.Length == 2)
                {
                    Entity playerinfo = FindByName(strArray1[1]);
                    if (playerinfo == null)
                    {
                        Utilities.RawSayTo(player, ServerPrefix + " ^5Failed^7 to found or ^5multiple^7 were found...");
                    }
                    else
                    {
                        Utilities.RawSayTo(player, ServerPrefix + " --------PlayerInfo--------");
                        AfterDelay(1000, (Action)(() =>
                        {
                            Utilities.RawSayTo(player, ServerPrefix + " Name: ^2" + playerinfo.Name);
                        }));
                        AfterDelay(2000, (Action)(() =>
                        {
                            Utilities.RawSayTo(player, ServerPrefix + " IP: ^2" + playerinfo.IP.Address);
                        }));
                        AfterDelay(3000, (Action)(() =>
                        {
                            Utilities.RawSayTo(player, ServerPrefix + " HWID: ^2" + playerinfo.HWID.ToString());
                        }));
                        /* this was for AIZombies
                                    AfterDelay(4000, (Action)(() =>
                                    {
                                        int totalBalance = (int)player.GetPlayerData("money");
                                        Utilities.RawSayTo(player, ServerPrefix + " Bank: ^2" + totalBalance + "$");
                                    }));*/
                        AfterDelay(5000, (Action)(() =>
                        {
                            Utilities.RawSayTo(player, ServerPrefix + " Rank: ^2" + GetRankByName(playerinfo.Name));
                        }));
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!br") || strArray1[0].Equals("!bring"))
            {
                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Format: ^6!bring/!br <player>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    if (strArray1[1].Equals("all") && GetRankByName(player.Name) != "Moderator")
                    {
                        ConLog.PlayerUseCommandEv(player, strArray1[0]);
                        foreach (Entity tpplayers in Entitys)
                        {
                            tpplayers.SetOrigin(player.Origin);
                            Utilities.RawSayTo(tpplayers, "^6" + player.Name + " ^7bring you to him.");
                            return BaseScript.EventEat.EatGame;
                        }
                    }
                    Entity tpplayer = FindByName(strArray1[1]);
                    if (tpplayer == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        ConLog.PlayerUseCommandOnEv(player, strArray1[0], tpplayer);
                        tpplayer.SetOrigin(player.Origin);
                        Utilities.RawSayTo(tpplayer, "^6" + player.Name + " ^7bring you to him.");
                        return BaseScript.EventEat.EatGame;
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!tpt"))
            {
                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!tpt^6 <player1> <player2>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length >= 2 && strArray1.Length <= 3)
                {
                    Entity tpt1 = FindByName(strArray1[1]);
                    Entity tpt2 = FindByName(strArray1[2]);
                    if (tpt1 == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found ^6<Player1>^7 or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    if (tpt2 == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found ^6<Player2>^7 or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    if (tpt1 == null && tpt2 == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found both players or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        ConLog.PlayerUseCommandOnEv(player, strArray1[0], tpt1);
                        tpt1.SetOrigin(tpt2.Origin);
                        Utilities.RawSayTo(tpt1, TAG + " ^6" + player.Name + " ^7bring you to ^6" + tpt2.Name + "^7.");
                        Utilities.RawSayTo(tpt2, TAG + " ^6" + player.Name + " ^7bring to you ^6" + tpt1.Name + "^7.");
                        return BaseScript.EventEat.EatGame;
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!goto"))
            {
                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!goto^6 <player>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    Entity gotop = FindByName(strArray1[1]);
                    if (gotop == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found or ^6multiple^7 were found...");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        player.SetOrigin(gotop.Origin);
                        Utilities.RawSayTo(player, TAG + " Teleported to ^6" + gotop.Name + "^7!");
                        Utilities.RawSayTo(gotop, TAG + " ^6" + player.Name + "^7 Teleported to you.");
                        return BaseScript.EventEat.EatGame;
                    }
                }
            }
            //next 41 lines you can delete, if you want tho...
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            //if (strArray1[0].Equals("!suicide") || strArray1[0].Equals("!s"))
            //{
            //    player.FinishPlayerDamage(player, player, 99999, 0, "MOD_UNKNOWN", "default_weapon", player.Origin, player.Origin, "none", 0);
            //    return BaseScript.EventEat.EatGame;
            //}
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            //if (strArray1[0].Equals("!kill"))
            //{
            //    if (strArray1.Length < 2)
            //    {
            //        Utilities.RawSayTo(player, "Format: ^1!kill^6 <player>");
            //        return BaseScript.EventEat.EatGame;
            //    }
            //    if (strArray1.Length == 2)
            //    {
            //        if (strArray1[1].Equals("all"))
            //        {
            //            foreach (Entity targets in Entitys)
            //            {
            //                Utilities.RawSayAll("^6" + player.Name + " ^7Killed all.");
            //                targets.FinishPlayerDamage(targets, player, 99999, 0, "MOD_UNKNOWN", "default_weapon", targets.Origin, targets.Origin, "none", 0);
            //            }
            //            return BaseScript.EventEat.EatGame;
            //        }
            //        Entity target = FindByName(strArray1[1]);
            //        if (target == null)
            //        {
            //            Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found or ^6multiple^7 were found...");
            //            return BaseScript.EventEat.EatGame;
            //        }
            //        else
            //        {
            //            Utilities.RawSayTo(target, "^6" + player.Name + " ^7Killed you.");
            //            target.FinishPlayerDamage(target, player, 99999, 0, "MOD_UNKNOWN", "defaultweapon_mp", target.Origin, target.Origin, "none", 0);
            //            return BaseScript.EventEat.EatGame;
            //        }
            //    }
            //    return BaseScript.EventEat.EatGame;
            //}
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!endgame"))
            {

                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!endgame^6 <reason>");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length > 1)
                {
                    string reasons = "Game ended by ^6" + player.Name + "^7 for^6";

                    for (int index = 1; index < strArray1.Length; index++)
                    {
                        reasons += " " + strArray1[index];
                    }

                    HudElem reasonelem = HudElem.CreateServerFontString(Objective, 1.8f);
                    reasonelem.SetPoint("CENTER", "CENTER", 0, -70);
                    reasonelem.SetText(reasons);
                    reasonelem.GlowColor = new Vector3(5.0f, 0.4f, 5.5f);
                    reasonelem.GlowAlpha = 0.7f;
                    reasonelem.SetPulseFX(60, 5000, 1000);

                    ConLog.PlayerUseCommandEv(player, strArray1[0]);
                    player.Notify("menuresponse", "menu", "endround");
                    return EventEat.EatGame;
                }
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!switch"))
            {
                if (player.SessionTeam == "allies")
                {
                    AfterDelay(250, () =>
                    {
                        player.SetField("team", "axis");
                        player.SessionTeam = "axis";
                    });
                }
                if (player.SessionTeam == "axis")
                {
                    AfterDelay(250, () =>
                    {
                        player.SetField("team", "allies");
                        player.SessionTeam = "allies";
                    });
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!pm"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!pm ^6<player> <message>");
                }
                if (strArray1.Length >= 2)
                {
                    Entity pm = FindByName(strArray1[1]);
                    if (pm == null)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        for (int index = 2; index < strArray1.Length; index++)
                        {
                            pmmessage += " " + strArray1[index];
                        }
                        Utilities.RawSayTo(player, "[^6You ^7>^6 " + pm.Name + "^7] " + pmmessage);
                        Print("[" + player.Name + " > " + pm.Name + "] " + pmmessage);
                        Utilities.RawSayTo(pm, "[^6" + player.Name + " ^7>^6 You^7] " + pmmessage);
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!getpos"))
            {
                float x = player.Origin.X;
                float y = player.Origin.Y;
                float z = player.Origin.Z;

                Utilities.RawSayTo(player, "Current pos(xyz): ^6" + x + " " + y + " " + z);
                Print(player.Name + "Pos(xyz)= " + x + " " + y + " " + z);
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!setpos"))
            {
                string toPlusX = null;
                string toPlusY = null;
                string toPlusZ = null;
                string zero = "";
                if (strArray1.Length == 1 || strArray1.Length > 5)
                {
                    Utilities.RawSayTo(player, "Format: ^1!setpos^6 <x,+north/-south> <y,+west/-east> <z,+up/-down>");
                    Utilities.RawSayTo(player, "^6[!]^7 same axis | ^6[+]^7 add to axis | ^6[-]^7 remove from axis");
                }
                if (strArray1.Length >= 2 && strArray1.Length < 5)
                {
                    if (strArray1[1].Equals("[!]"))
                    {
                        strArray1[1] = player.Origin.X.ToString();
                    }
                    if (strArray1[2].Equals("[!]"))
                    {
                        strArray1[2] = player.Origin.Y.ToString();
                    }
                    if (strArray1[3].Equals("[!]"))
                    {
                        strArray1[3] = player.Origin.Z.ToString();
                    }
                    if (strArray1[1].StartsWith("[+"))
                    {
                        toPlusX = strArray1[1].Split(new char[1]
                        {
                            ']'
                        })[1];
                        strArray1[1] = (Convert.ToSingle(toPlusX) + player.Origin.X).ToString();
                        strArray1[1].Replace("[+]", zero);
                    }
                    if (strArray1[2].StartsWith("[+"))
                    {
                        toPlusY = strArray1[2].Split(new char[1]
                        {
                            ']'
                        })[1];
                        strArray1[2] = (Convert.ToSingle(toPlusY) + player.Origin.Y).ToString();
                        strArray1[2].Replace("[+]", zero);
                    }
                    if (strArray1[3].StartsWith("[+"))
                    {
                        toPlusZ = strArray1[3].Split(new char[1]
                        {
                            ']'
                        })[1];
                        strArray1[3] = (Convert.ToSingle(toPlusZ) + player.Origin.Z).ToString();
                        strArray1[3].Replace("[+]", zero);
                    }

                    if (strArray1[1].StartsWith("[-"))
                    {
                        toPlusX = strArray1[1].Split(new char[1]
                        {
                            ']'
                        })[1];
                        strArray1[1].Replace("[-]", zero);
                        strArray1[1] = (player.Origin.X - Convert.ToSingle(toPlusX)).ToString();
                    }
                    if (strArray1[2].StartsWith("[-"))
                    {
                        toPlusY = strArray1[2].Split(new char[1]
                        {
                            ']'
                        })[1];
                        strArray1[2].Replace("[-]", zero);
                        strArray1[2] = (player.Origin.Y - Convert.ToSingle(toPlusY)).ToString();
                    }
                    if (strArray1[3].StartsWith("[-"))
                    {
                        toPlusZ = strArray1[3].Split(new char[1]
                        {
                            ']'
                        })[1];
                        strArray1[3].Replace("[-]", zero);
                        strArray1[3] = (player.Origin.Z - Convert.ToSingle(toPlusZ)).ToString();
                    }

                    float x = Convert.ToSingle(strArray1[1]);
                    float y = Convert.ToSingle(strArray1[2]);
                    float z = Convert.ToSingle(strArray1[3]);

                    //Print(player.Name + " Pos before " + player.Origin);
                    player.SetOrigin(new Vector3(x, y, z));
                    //Print(player.Name + " teleported to " + player.Origin);
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ammo"))
            {
                if (strArray1.Length == 1)
                {
                    string Weap = player.GetCurrentWeapon();
                    player.GiveMaxAmmo(Weap);
                }
                if (strArray1.Length == 2)
                {
                    Entity toGive = FindByName(strArray1[1]);
                    if (toGive == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple ^7were found...");
                    }
                    else
                    {
                        ConLog.PlayerUseCommandOnEv(player, strArray1[0], toGive);
                        string Weap = toGive.GetCurrentWeapon();
                        toGive.GiveMaxAmmo(Weap);
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!nextmap"))
            {
                Utilities.ExecuteCommand("start_map_rotate");
                Utilities.RawSayAll(TAG + " nextmap set!");
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!ReqMod") || strArray1[0].Equals("!rm"))
            {
                if (strArray1.Length < 3 || strArray1.Length >= 4)
                {
                    Utilities.RawSayTo(player, "Format: ^1!ReqMod^7/^1!rm <Your Discord tag> <Admin name>^7.");
                    return BaseScript.EventEat.EatGame;
                }
                if (strArray1.Length == 3)
                {
                    Entity admin = FindByName(strArray1[2]);
                    if (admin == null)
                    {
                        Utilities.RawSayTo(player, TAG + " This admin ^6is'nt on the server^7 or ^6failed^7 to found.");
                        return BaseScript.EventEat.EatGame;
                    }
                    else
                    {
                        Utilities.RawSayTo(player, "^2Request sent^7!");
                        Utilities.RawSayTo(admin, "Incomming Mod request from: ^6" + player.Name + " ^2" + strArray1[1]);
                        Print("[REQ] a Mod request from: " + player.Name + " " + strArray1[1]);
                        ConLog.StringArray("[REQ] a Mod request from: " + player.Name + " " + strArray1[1]);
                        return BaseScript.EventEat.EatGame;
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!poslist"))
            {
                string pn = null;
                string posthis = null;
                foreach (string strpos in File.ReadAllLines("scripts\\GPIv3\\PosList.txt"))
                {
                    if (strpos.StartsWith("posname"))
                    {
                        pn = strpos.Split(new char[1]
                        {
                            '='
                        })[1];
                    }
                    if (File.Exists("scripts\\GPIv3\\SavedPos\\" + pn + ".txt"))
                    {
                        foreach (string strpm in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + pn + ".txt"))
                        {
                            if (strpm.StartsWith("map"))
                            {
                                posthis = strpm.Split(new char[1]
                                {
                                    '='
                                })[1];
                            }
                        }
                    }
                    if (posthis == GSCFunctions.GetDvar("mapname"))
                    {
                        if (!MapPositions.Contains(pn))
                        {
                            MapPositions.Add(pn);
                        }
                    }
                }
                string result = string.Join("^7,^6", MapPositions.ToArray());
                Utilities.RawSayTo(player, "Current map positions: ^6" + result);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!savepos"))
            {
                string str1 = null;
                int num = 0;

                if (strArray1.Length == 1 || strArray1.Length > 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!savepos ^6<pos name>(no spacebar)");
                    Utilities.RawSayTo(player, "Example: ^1!savepos ^6YourPosName");
                    return EventEat.EatGame;
                }
                if (strArray1.Length == 2)
                {
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\PosList.txt"))
                    {
                        if (str.StartsWith("posname"))
                        {
                            str1 = str.Split(new char[1]
                            {
                                '='
                            })[1];
                        }
                        if (str1.Contains(strArray1[1]))
                        {
                            ++num;
                        }
                    }
                    if (num == 1)
                    {
                        Utilities.RawSayTo(player, TAG + " This position already exists!");
                    }
                    else if (num == 0)
                    {
                        StreamWriter streamWriter = new StreamWriter("scripts\\GPIv3\\PosList.txt", true);
                        StreamWriter streamWriter1 = new StreamWriter("scripts\\GPIv3\\SavedPos\\" + strArray1[1].ToString() + ".txt");

                        streamWriter.WriteLine("posname=" + strArray1[1].ToString());
                        streamWriter.Flush();
                        streamWriter.Close();

                        streamWriter1.WriteLine("originX=" + player.Origin.X);
                        streamWriter1.WriteLine("originY=" + player.Origin.Y);
                        streamWriter1.WriteLine("originZ=" + player.Origin.Z);
                        streamWriter1.WriteLine("map=" + GSCFunctions.GetDvar("mapname"));
                        streamWriter1.Flush();
                        streamWriter1.Close();

                        Utilities.RawSayTo(player, TAG + " Position ^6" + strArray1[1].ToString() + " ^7set!");
                    }
                    return EventEat.EatGame;
                }
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!poswhitelist") || strArray1[0].Equals("!poswl"))
            {
                string line;
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!poswhitelist^7/^1!poswl ^6<page>");
                }
                if (strArray1.Length == 2)
                {
                    //settings
                    int pages = 0;
                    int maxN = 0;
                    int minN = 0;
                    int arayvalue = 0;

                    int n1 = 0;
                    int n2 = 0;
                    int n3 = 0;
                    int n4 = 0;
                    int n5 = 0;
                    int n6 = 0;
                    int n7 = 0;
                    int n8 = 0;
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                    {
                        if (str.StartsWith("pos_whitelist="))
                        {
                            line = str.Substring(14);
                            string[] list = line.Split(new char[] { ',' });

                            //setting up pages & commands
                            string strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                            int length = list.Length;
                            int final = 0;
                            int lastPnum = 0;
                            if (length.ToString().EndsWith("0")) { final = length + 0; lastPnum = 0; }
                            if (length.ToString().EndsWith("1")) { final = length + 9; lastPnum = 1; }
                            if (length.ToString().EndsWith("2")) { final = length + 8; lastPnum = 2; }
                            if (length.ToString().EndsWith("3")) { final = length + 7; lastPnum = 3; }
                            if (length.ToString().EndsWith("4")) { final = length + 6; lastPnum = 4; }
                            if (length.ToString().EndsWith("5")) { final = length + 5; lastPnum = 5; }
                            if (length.ToString().EndsWith("6")) { final = length + 4; lastPnum = 6; }
                            if (length.ToString().EndsWith("7")) { final = length + 3; lastPnum = 7; }
                            if (length.ToString().EndsWith("8")) { final = length + 2; lastPnum = 8; }
                            if (length.ToString().EndsWith("9")) { final = length + 1; lastPnum = 9; }
                            pages = final / 10;
                            maxN = 9;
                            minN = 0;
                            arayvalue = minN;

                            n1 = 1;
                            n2 = 2;
                            n3 = 3;
                            n4 = 4;
                            n5 = 5;
                            n6 = 6;
                            n7 = 7;
                            n8 = 8;

                            //if page is bigger than the book
                            if (Convert.ToInt32(strArray1[1]) > pages)
                            {
                                Utilities.RawSayTo(player, TAG + " There is no more pages!");
                                break;
                            }
                            //Page 0?
                            if (Convert.ToInt32(strArray1[1]) == 0)
                            {
                                Utilities.RawSayTo(player, TAG + " Why page 0?");
                                break;
                            }
                            //No book?
                            if (Convert.ToInt32(strArray1[1]) < 0)
                            {
                                Utilities.RawSayTo(player, TAG + " Why negative numbers??");
                                break;
                            }
                            //If smaller or equals than pages and bigger than 0
                            if (Convert.ToInt32(strArray1[1]) <= pages && Convert.ToInt32(strArray1[1]) > 0)
                            {
                                Utilities.RawSayTo(player, "--- ^2Whitelist ^7(^2" + strArray1[1] + "/" + pages + "^7) ---");
                                //If page = 1
                                if (Convert.ToInt32(strArray1[1]) == 1)
                                {
                                    minN = 0;
                                    n1 = 1;
                                    n2 = 2;
                                    n3 = 3;
                                    n4 = 4;
                                    n5 = 5;
                                    n6 = 6;
                                    n7 = 7;
                                    n8 = 8;
                                    maxN = 9;
                                    if (lastPnum == 1)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN];
                                    }
                                    if (lastPnum == 2)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1];
                                    }
                                    if (lastPnum == 3)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2];
                                    }
                                    if (lastPnum == 4)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3];
                                    }
                                    if (lastPnum == 5)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4];
                                    }
                                    if (lastPnum == 6)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5];
                                    }
                                    if (lastPnum == 7)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6];
                                    }
                                    if (lastPnum == 8)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7];
                                    }
                                    if (lastPnum == 9)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8];
                                    }
                                    if (lastPnum == 0)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    }
                                }
                                //Pages from 2 to pre-last
                                if (Convert.ToInt32(strArray1[1]) != 1 && Convert.ToInt32(strArray1[1]) < pages && Convert.ToInt32(strArray1[1]) != pages)
                                {
                                    maxN = (Convert.ToInt32(strArray1[1]) * 10) - 1;
                                    n1 = (maxN - 1);
                                    n2 = (maxN - 2);
                                    n3 = (maxN - 3);
                                    n4 = (maxN - 4);
                                    n5 = (maxN - 5);
                                    n6 = (maxN - 6);
                                    n7 = (maxN - 7);
                                    n8 = (maxN - 8);
                                    minN = (maxN - 9);
                                    strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                }
                                //Last page
                                if (Convert.ToInt32(strArray1[1]) == pages)
                                {
                                    maxN = (Convert.ToInt32(strArray1[1]) * 10) - 1;
                                    n1 = (maxN - 8);
                                    n2 = (maxN - 7);
                                    n3 = (maxN - 6);
                                    n4 = (maxN - 5);
                                    n5 = (maxN - 4);
                                    n6 = (maxN - 3);
                                    n7 = (maxN - 2);
                                    n8 = (maxN - 1);
                                    minN = (maxN - 9);

                                    if (lastPnum == 1)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN];
                                    }
                                    if (lastPnum == 2)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1];
                                    }
                                    if (lastPnum == 3)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2];
                                    }
                                    if (lastPnum == 4)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3];
                                    }
                                    if (lastPnum == 5)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4];
                                    }
                                    if (lastPnum == 6)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5];
                                    }
                                    if (lastPnum == 7)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6];
                                    }
                                    if (lastPnum == 8)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7];
                                    }
                                    if (lastPnum == 9)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8];
                                    }
                                    if (lastPnum == 0)
                                    {
                                        strarr = TAG + " Positions: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    }
                                }
                                //Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7)");
                                Utilities.RawSayTo(player, strarr);

                                //if (keyValuePair.Key == this.GetRankByName(player.Name))
                                //{
                                //    if (keyValuePair.Value.Length < (Convert.ToInt32(strArray1[1]) * 10))
                                //    {
                                //        char[] strCA = keyValuePair.Value.Replace(",", "^7,^6").ToCharArray();
                                //    }
                                //    Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7)");
                                //    Utilities.RawSayTo(player, "You can use: ^6" + "//dat array of commands//");
                                //}
                                break;
                            }
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }

            if (strArray1[0].Equals("!removepos"))
            {
                string[] poss = null;
                string pos = null;
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!removepos ^6<pos name>");
                }
                if (strArray1.Length == 2)
                {
                    string Position = FindPosByName(strArray1[1]);
                    if (Position == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                    {
                        if (str.StartsWith("pos_whitelist"))
                        {
                            pos = str.Split(new char[1] { '=' })[1];
                            poss = pos.Split(new char[] { ',' });
                            break;
                        }
                    }
                    if (poss.Contains(Position))
                    {
                        Utilities.RawSayTo(player, TAG + " You ^6cannot delete^7 that position!");
                    }
                    if (!poss.Contains(Position))
                    {
                        foreach (string str in File.ReadAllLines("scripts\\GPIv3\\PosList.txt"))
                        {
                            if (str.StartsWith("posname=" + Position))
                            {
                                string toRemove = "posname=" + Position;
                                var tempFile = Path.GetTempFileName();
                                var Keep = File.ReadLines("scripts\\GPIv3\\PosList.txt").Where(l => l != toRemove);

                                File.WriteAllLines(tempFile, Keep);

                                File.Delete("scripts\\GPIv3\\PosList.txt");
                                File.Move(tempFile, "scripts\\GPIv3\\PosList.txt");

                                File.Delete("scripts\\GPIv3\\SavedPos\\" + Position + ".txt");
                            }
                        }
                        Utilities.RawSayTo(player, TAG + " Position ^6" + Position + " ^7Successfully deleted.");
                    }

                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!stopserver"))
            {
                ConLog.PlayerUseCommandEv(player, strArray1[0]);
                Utilities.RawSayAll(TAG + " Stopping server . . .");
                Utilities.ExecuteCommand("killserver");
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!report"))
            {
                if (strArray1.Length <= 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!report^6 <player> <reason>");
                }
                if (strArray1.Length >= 3)
                {
                    Entity repoted = FindByName(strArray1[1]);
                    if (repoted == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        for (int index = 2; index < strArray1.Length; index++)
                        {
                            reason += " " + strArray1[index];
                        }
                        Print("Player Report: " + repoted.Name + " for: " + reason);
                        Utilities.RawSayTo(player, TAG + " Report sent and archived!");
                        StreamWriter writer = new StreamWriter("scripts\\GPIv3\\ReportList.txt", true);
                        writer.WriteLine("name=" + repoted.Name + "(" + GetRankByName(repoted.Name) + ") HWID(" + repoted.HWID + ")");
                        writer.Flush();
                        writer.Close();
                        StreamWriter writer1 = new StreamWriter("scripts\\GPIv3\\Reported\\" + repoted.HWID + ".txt");
                        writer1.WriteLine("reason=" + reason);
                        writer1.WriteLine("name=" + repoted.Name);
                        writer1.WriteLine("guid=" + repoted.GUID);
                        writer1.WriteLine("hwid=" + repoted.HWID);
                        writer1.WriteLine("xuid=" + repoted.GetXUID());
                        writer1.WriteLine("IP=" + repoted.IP.Address);
                        writer1.WriteLine("Rank=" + GetRankByName(repoted.Name));
                        writer1.WriteLine("Report by= " + player.Name + " HWID(" + player.HWID + ")");
                        writer1.Flush();
                        writer1.Close();
                        foreach (Entity admin in Players)
                        {
                            if (GetRankByName(admin.Name) == "Admin" || GetRankByName(admin.Name) == "Curator" || GetRankByName(admin.Name) == "SuperMod" || GetRankByName(admin.Name) == "StaffMod" || GetRankByName(admin.Name) == "Moderator")
                            {
                                Utilities.RawSayTo(admin, "[^1" + player.Name + "^7>^1REPORT^7] On ^6" + repoted.Name + "^7 for: ^6" + reason);
                            }
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!gotopos"))
            {
                string CurrMap = GSCFunctions.GetDvar("mapname");
                string str1 = (string)null;
                string str2 = (string)null;
                string str3 = (string)null;
                string GetMap = (string)null;

                if (strArray1.Length == 1 || strArray1.Length > 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!gotopos ^6<pos name> <player>");
                }
                if (strArray1.Length == 2)
                {
                    string PosName = FindPosByName(strArray1[1]);
                    if (PosName == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        foreach (string str in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                        {
                            if (str.StartsWith("map"))
                            {
                                GetMap = str.Split(new char[1]
                                {
                                    '='
                                })[1];
                            }
                        }
                        if (GetMap != CurrMap)
                        {
                            Utilities.RawSayTo(player, "^6Failed^7 to connect maps! (different maps ^6" + GetMap + "^7, ^6" + CurrMap + "^7)");
                        }
                        else if (GetMap == CurrMap)
                        {
                            Utilities.RawSayTo(player, TAG + " Maps connected ^6" + GetMap + "^7, ^6" + CurrMap);
                            foreach (string str4 in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                            {
                                if (str4.StartsWith("originX"))
                                {
                                    str1 = str4.Split(new char[1]
                                    {
                                        '='
                                    })[1];
                                }
                            }
                            foreach (string str5 in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                            {
                                if (str5.StartsWith("originY"))
                                {
                                    str2 = str5.Split(new char[1]
                                    {
                                        '='
                                    })[1];
                                }
                            }
                            foreach (string str6 in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                            {
                                if (str6.StartsWith("originZ"))
                                {
                                    str3 = str6.Split(new char[1]
                                    {
                                        '='
                                    })[1];
                                }
                            }
                            float x = Convert.ToSingle(str1, new CultureInfo("en-US"));
                            float y = Convert.ToSingle(str2, new CultureInfo("en-US"));
                            float z = Convert.ToSingle(str3, new CultureInfo("en-US"));

                            player.SetOrigin(new Vector3(x, y, z));
                            Utilities.RawSayTo(player, TAG + " Teleported to ^6" + PosName + " ^7position!");
                        }
                    }
                }
                if (strArray1.Length == 3)
                {
                    Entity totp = FindByName(strArray1[2]);
                    if (totp == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(totp.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            string PosName = FindPosByName(strArray1[1]);
                            if (PosName == null)
                            {
                                Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                            }
                            else
                            {
                                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                                {
                                    if (str.StartsWith("map"))
                                    {
                                        GetMap = str.Split(new char[1]
                                        {
                                    '='
                                        })[1];
                                    }
                                }
                                if (GetMap != CurrMap)
                                {
                                    Utilities.RawSayTo(player, "^6Failed^7 to connect maps! (different maps ^6" + GetMap + "^7, ^6" + CurrMap + "^7)");
                                }
                                else if (GetMap == CurrMap)
                                {
                                    Utilities.RawSayTo(player, TAG + " Maps connected ^6" + GetMap + "^7, ^6" + CurrMap);
                                    foreach (string str4 in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                                    {
                                        if (str4.StartsWith("originX"))
                                        {
                                            str1 = str4.Split(new char[1]
                                            {
                                        '='
                                            })[1];
                                        }
                                    }
                                    foreach (string str5 in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                                    {
                                        if (str5.StartsWith("originY"))
                                        {
                                            str2 = str5.Split(new char[1]
                                            {
                                        '='
                                            })[1];
                                        }
                                    }
                                    foreach (string str6 in File.ReadAllLines("scripts\\GPIv3\\SavedPos\\" + PosName + ".txt"))
                                    {
                                        if (str6.StartsWith("originZ"))
                                        {
                                            str3 = str6.Split(new char[1]
                                            {
                                        '='
                                            })[1];
                                        }
                                    }
                                    float x = Convert.ToSingle(str1, new CultureInfo("en-US"));
                                    float y = Convert.ToSingle(str2, new CultureInfo("en-US"));
                                    float z = Convert.ToSingle(str3, new CultureInfo("en-US"));

                                    totp.SetOrigin(new Vector3(x, y, z));
                                    Utilities.RawSayTo(player, TAG + " Player ^6" + totp.Name + " ^7teleported to ^6" + PosName + " ^7position!");
                                    Utilities.RawSayTo(totp, TAG + " Player ^6" + player.Name + " ^7teleported you to ^6" + PosName + " ^7position.");
                                }
                            }
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!s") || strArray1[0].Equals("!suicide"))
            {
                ConLog.PlayerUseCommandEv(player, strArray1[0]);
                AfterDelay(10, () =>
                {
                    if (GSCFunctions.IsAlive(player))
                    {
                        GSCFunctions.FinishPlayerDamage(player, player, player, 9000, 0, "NOD_FALLING", "none", player.Origin, player.Origin, "none", 0);  //Why this shit is working only in !endnuke script??
                    }
                });
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!discord") || strArray1[0].Equals("!dsc"))
            {
                Utilities.RawSayTo(player, "^7[^6LK^7] ^7Our ^2discord^7: ^6discord.gg/KMSx2kN7Xu");
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!admins"))
            {
                string Admin = string.Join("^7,^6", AdminsNames.ToArray());
                Utilities.RawSayTo(player, TAG + " Admins online: ^6" + Admin);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!mods"))
            {
                string Moders = string.Join("^7,^6", ModsNames.ToArray());
                Utilities.RawSayTo(player, TAG + " Mods online: ^6" + Moders);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!kill"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!kill ^6<player,all>");
                }
                if (strArray1.Length == 2)
                {
                    if (strArray1[1].Equals("all"))
                    {
                        if (!(Admins.Contains(player) || Curators.Contains(player) || SuperMods.Contains(player)))
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot use parameter <^1all^7> on this command!");
                        }
                        if (Admins.Contains(player) || Curators.Contains(player) || SuperMods.Contains(player))
                        {
                            foreach (Entity players in Players)
                            {
                                AfterDelay(10, () =>
                                {
                                    GSCFunctions.FinishPlayerDamage(players, players, players, 9000, 0, "MOD_FALLING", "none", players.Origin, players.Origin, "none", 0);
                                });
                            }
                            Utilities.RawSayAll(TAG + " Everyone were killed by ^6" + player.Name + "^7.");
                        }
                    }
                    else if (!strArray1[1].Equals("all"))
                    {
                        Entity toKill = FindByName(strArray1[1]);
                        if (toKill == null)
                        {
                            Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        }
                        else
                        {
                            string Pgroup = GetRankByName(player.Name);
                            string Igroup = GetRankByName(toKill.Name);
                            int Plevel = GetGroupLevel(Pgroup);
                            int Ilevel = GetGroupLevel(Igroup);
                            if (Plevel > Ilevel)
                            {
                                AfterDelay(10, () =>
                                {
                                    GSCFunctions.FinishPlayerDamage(toKill, toKill, toKill, 9000, 0, "MOD_FALLING", "none", toKill.Origin, toKill.Origin, "none", 0);
                                });
                                Utilities.RawSayTo(player, TAG + " player ^6" + toKill.Name + " ^7killed.");
                                Utilities.RawSayTo(toKill, TAG + " player ^6" + player.Name + " ^7killed you.");
                            }
                            if (Plevel <= Ilevel)
                            {
                                Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                            }
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!spec"))
            {
                ConLog.PlayerUseCommandEv(player, strArray1[0]);
                Vector3 PosTo = new Vector3(player.Origin.X, player.Origin.Y, player.Origin.Z + 52);
                Vector3 PosFrom = new Vector3(player.Origin.X, player.Origin.Y, player.Origin.Z - 52);
                if (player.SessionState != "spectator")
                {
                    Utilities.RawSayTo(player, TAG + " You are now spectating.");
                    player.AllowSpectateTeam("freelook", true);
                    player.SessionState = "spectator";
                    player.SetContents(0);
                    player.SetOrigin(PosTo);
                }
                else
                {
                    Utilities.RawSayTo(player, TAG + " You are no longer spectating.");
                    player.AllowSpectateTeam("freelook", false);
                    player.SessionState = "playing";
                    player.SetContents(100);
                    player.SetOrigin(PosFrom);
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!fastrestart") || strArray1[0].Equals("!fastrest"))
            {
                ConLog.PlayerUseCommandEv(player, strArray1[0]);
                Utilities.ExecuteCommand("fast_restart");
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!maprestart") || strArray1[0].Equals("!maprest"))
            {
                ConLog.PlayerUseCommandEv(player, strArray1[0]);
                Utilities.ExecuteCommand("map_restart");
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            //if (strArray1[0].Equals("!mod"))
            //{
            //    string CurrentGM = GSCFunctions.GetDvar("getDvar");
            //    if (strArray1.Length == 1 || strArray1.Length >= 3)
            //    {
            //        Utilities.RawSayTo(player, "Format: ^1!mod ^6<edit,play>");
            //    }
            //    if (strArray1.Length == 2)
            //    {
            //        if (strArray1[1].Equals("edit"))
            //        {
            //            string CurrMap = GSCFunctions.GetDvar("mapname");
            //            if (File.Exists("admin\\haha.dsr"))
            //            {
            //                StreamWriter streamWriter = new StreamWriter("admin\\haha.dspl");
            //                streamWriter.WriteLine(CurrMap + ",haha,1000");
            //                streamWriter.Flush();
            //                streamWriter.Close();

            //                Utilities.ExecuteCommand("map_rotate haha");
            //                Utilities.ExecuteCommand("start_map_rotate");
            //            }
            //        }
            //        if (strArray1[1].Equals("!play"))
            //        {
            //            string CurrMap = GSCFunctions.GetDvar("mapname");
            //            if (File.Exists("admin\\BackTo.dspl"))
            //            {
            //                StreamWriter streamWriter = new StreamWriter("admin\\BackTo.dspl");
            //                streamWriter.WriteLine(CurrMap + ",Cinf1,1000");
            //                streamWriter.Flush();
            //                streamWriter.Close();

            //                Utilities.ExecuteCommand("map_rotate BackTo");
            //                Utilities.ExecuteCommand("start_map_rotate");
            //                Utilities.ExecuteCommand("map_rotate infected");
            //            }
            //        }
            //    }
            //    return EventEat.EatGame;
            //}
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!convert"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!convert ^6<weapon>");
                }
                if (strArray1.Length == 2)
                {
                    if (strArray1[1].Equals("currweap"))
                    {
                        string ConsWeaps = player.CurrentWeapon.ToString();
                        Utilities.RawSayTo(player, "^6 Current weapon ^7converted name is: ^6" + ConsWeaps);
                    }
                    else
                    {
                        string ConsWeap = FindWeapByname(strArray1[1]);
                        if (ConsWeap == null)
                        {
                            Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                        }
                        else
                        {
                            string Final = ConvertToConsName(ConsWeap);
                            if (Final == null)
                            {
                                Utilities.RawSayTo(player, "^6Failed^7 to convert...");
                            }
                            else
                            {
                                Utilities.RawSayTo(player, "^6" + strArray1[1] + "^7/^6" + ConsWeap + " ^7converted name is: ^6" + Final);
                            }
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!addweap"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 4)
                {
                    Utilities.RawSayTo(player, "Format: ^1!addweap ^6<weap> <player>");
                }
                if (strArray1.Length == 2)
                {
                    this.AddWeap(player, strArray1[1]);
                }
                if (strArray1.Length == 3)
                {
                    Entity toGive = FindByName(strArray1[2]);
                    if (toGive == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        this.AddWeap(toGive, strArray1[1]);
                        Utilities.RawSayTo(toGive, TAG + " You are given ^6" + strArray1[1] + " ^7by ^6" + player.Name);
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!takeweap"))
            {
                string currWeap = player.CurrentWeapon;
                player.TakeWeapon(currWeap);
                if (strArray1.Length == 2)
                {
                    Entity toGive = FindByName(strArray1[1]);
                    if (toGive == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(toGive.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            ConLog.PlayerUseCommandOnEv(player, strArray1[0], toGive);
                            string currWeaps = toGive.CurrentWeapon;
                            toGive.TakeWeapon(currWeaps);
                            Utilities.RawSayTo(toGive, TAG + " ^6" + player.Name + " ^7took your weapon.");
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!add"))
            {
                if (strArray1.Length < 2)
                {
                    Utilities.RawSayTo(player, "Format: ^6!add <group> <player>");
                    return BaseScript.EventEat.EatGame;
                }
                Entity adder = FindByName(strArray1[2]);
                if (adder == null)
                {
                    Utilities.RawSayTo(player, "^6Failed^7 to found player or ^6multiple^7 were found...");
                    return BaseScript.EventEat.EatGame;
                }
                else
                {
                    string Pgroup = GetRankByName(player.Name);
                    string Igroup = GetRankByName(adder.Name);
                    int Plevel = GetGroupLevel(Pgroup);
                    int Ilevel = GetGroupLevel(Igroup);
                    if (Plevel > Ilevel)
                    {
                        Utilities.RawSayTo(player, TAG + " ^6" + player.Name + " ^7Added ^6" + adder.Name + " ^7to ^6" + strArray1[1]);
                        ConLog.PlayerUseCommandOnEv(player, strArray1[0], adder);
                        AddToGroup(strArray1[1], player, adder);
                    }
                    if (Plevel <= Ilevel)
                    {
                        Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!unadd") || strArray1[0].Equals("!remove"))
            {
                if (strArray1.Length <= 2)
                {
                    Utilities.RawSayTo(player, "Format: ^1!unadd ^6<group> <player>");
                }
                else
                {
                    Entity byName = this.FindByName(strArray1[2]);
                    if (byName == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found player or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string Pgroup = GetRankByName(player.Name);
                        string Igroup = GetRankByName(byName.Name);
                        int Plevel = GetGroupLevel(Pgroup);
                        int Ilevel = GetGroupLevel(Igroup);
                        if (Plevel > Ilevel)
                        {
                            ConLog.PlayerUseCommandOnEv(player, strArray1[0], byName);
                            this.UnAddToGroup(strArray1[1], player, byName);
                        }
                        if (Plevel <= Ilevel)
                        {
                            Utilities.RawSayTo(player, TAG + " You cannot execute that command on higher rank!");
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!cfg"))
            {
                string str1 = null;
                if (strArray1.Length < 3 || strArray1.Length >= 4)
                {
                    Utilities.RawSayTo(player, TAG + " Format: ^1!cfg ^6<config_opt> <value>");
                    Utilities.RawSayTo(player, TAG + " ^1WARNING: ^7wrong values can cause bugs!");
                }
                if (strArray1.Length == 3)
                {
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                    {
                        if (str.StartsWith(strArray1[1]) && !(str.Contains("commands=") || str.Contains("xuids=") || str.Contains("groups=") || str.Contains("poswhitelist=")))
                        {
                            str1 = str.Split(new char[1] { '=' })[1];
                            string str5 = File.ReadAllText("scripts\\GPIv3\\GPIconfig.txt");
                            File.Delete("scripts\\GPIv3\\GPIconfig.txt");
                            using (StreamWriter streamWriter = new StreamWriter("scripts\\GPIv3\\GPIconfig.txt", true))
                            {
                                string str6 = str5.Replace(strArray1[1] + "=" + str1, strArray1[1] + "=" + strArray1[2]);
                                streamWriter.WriteLine(str6);
                                Utilities.RawSayAll(TAG + " Server setting ^6" + strArray1[1] + " ^7changed from ^6" + str1 + " ^7to ^6" + strArray1[2] + "^7.");
                            }
                            break;
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!seed"))
            {
                string seed = null;
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\Seed\\Saves.txt"))
                {
                    if (str.StartsWith("init"))
                    {
                        seed = str.Split(new char[1] { '=' })[1];
                        break;
                    }
                }
                Utilities.RawSayTo(player, TAG + " Server Seed: ^3" + seed);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!generate"))
            {
                bool allowRS = false;
                foreach (string str in File.ReadLines("scripts\\GPIv3\\GPIconfig.txt"))
                {
                    if (str.StartsWith("allow_random_seed"))
                    {
                        allowRS = Convert.ToBoolean(str.Split(new char[1] { '=' })[1]);
                        break;
                    }
                }
                if (allowRS == true)
                {
                    LinesDSPL.Clear();
                    this.SeedGenerator();
                    Utilities.RawSayAll(TAG + " ^6" + player.Name + " ^7generated new server seed.");
                    string seed = null;
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\Seed\\Saves.txt"))
                    {
                        if (str.StartsWith("init"))
                        {
                            seed = str.Split(new char[1] { '=' })[1];
                            break;
                        }
                    }
                    AfterDelay(750, () => { Utilities.RawSayAll(TAG + " New Server Seed: ^3" + seed); });
                    return EventEat.EatGame;
                }
                if (allowRS == false)
                {
                    Utilities.RawSayTo(player, TAG + " Failed to generate (Config: allow_random_seed is disabled).");
                    return EventEat.EatGame;
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!bannedsymbols") || strArray1[0].Equals("!bs"))
            {
                string str1 = "";
                foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                {
                    if (str.StartsWith("bannedsymbols"))
                    {
                        str1 = str.Split(new char[1] { '=' })[1];
                        break;
                    }
                }
                Utilities.RawSayTo(player, TAG + " Banned symbols: ^6" + str1);
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!anticheat"))
            {
                Utilities.RawSayTo(player, TAG + " ^6GPI S.AC v1.0.2^7.");
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!version") || strArray1[0].Equals("!ver"))
            {
                Utilities.RawSayTo(player, "Version:^6 GPI 15.3.3M (Public Release)");
                Utilities.RawSayTo(player, "Devs: ^6LiteralLySugaR^7, ^6LiSsa^7, ^5MRX450^7, ^6Im3adGirL^7");
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!contact"))
            {
                Utilities.RawSayTo(player, "Discord: ^6B R o k e N ∴ s M i L e#5863");
                Utilities.RawSayTo(player, "Steam: ^2/id/ReportForFree/");
                Utilities.RawSayTo(player, "Server Discord: ^6discord.gg/KMSx2kN7Xu");
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!sources"))
            {
                Utilities.RawSayTo(player, "^6ADMIN_CONTROL^7 by ^6bingo007");
                Utilities.RawSayTo(player, "^6IAM^7 by ^6Sa3id");
                Utilities.RawSayTo(player, "^6Special thanks^7 to ^5MRX450^7 for helping");
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!rules"))
            {
                AfterDelay(1200, (Action)(() =>
                {
                    Utilities.RawSayTo(player, "[^61^7] No offensive threat.");
                    AfterDelay(1200, (Action)(() =>
                    {
                        Utilities.RawSayTo(player, "[^62^7] No cheats.");
                        AfterDelay(1200, (Action)(() =>
                        {
                            Utilities.RawSayTo(player, "[^63^7] No camp after MOAB.");
                            AfterDelay(1200, (Action)(() =>
                            {
                                Utilities.RawSayTo(player, "[^64^7] No Head-CP.");
                                AfterDelay(1200, (Action)(() =>
                                {
                                    Utilities.RawSayTo(player, "[^65^7] You are allowed to use ^6!s^7 as infected.");
                                }));
                            }));
                        }));
                    }));
                }));
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!freeze"))
            {
                if (strArray1.Length < 2 || strArray1.Length > 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!freeze ^6<player> <param>");
                }
                if (strArray1.Length == 2)
                {
                    Entity toFreeze = FindByName(strArray1[1]);
                    if (toFreeze == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found player or ^6multiple^7 were found...");
                    }
                    else
                    {
                        ConLog.PlayerUseCommandOnEv(player, strArray1[0], toFreeze);
                        freezeLogic.OnFreezeCommand(toFreeze, player);
                    }
                }
                if (strArray1.Length == 3)
                {
                    if (strArray1[2].Equals("get"))
                    {
                        Entity toFreeze = FindByName(strArray1[1]);
                        if (toFreeze == null)
                        {
                            Utilities.RawSayTo(player, "^6Failed^7 to found player or ^6multiple^7 were found...");
                        }
                        else
                        {
                            if (freezeLogic.Freezed.Contains(toFreeze))
                            {
                                Utilities.RawSayTo(player, TAG + " Player ^6" + toFreeze.Name + " ^7is freezed.");
                            }
                            if (!freezeLogic.Freezed.Contains(toFreeze))
                            {
                                Utilities.RawSayTo(player, TAG + " Player ^6" + toFreeze.Name + " ^7is not freezed.");
                            }
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!saveplayer") || strArray1[0].Equals("!svpl"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!saveplayer ^6<player>");
                }
                if (strArray1.Length == 2)
                {
                    Entity toFind = FindByName(strArray1[1]);
                    if (toFind == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found player or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string IP = toFind.IP.Address.ToString();
                        string name = toFind.Name.ToString();
                        string HWID = toFind.HWID.ToString();
                        string GUID = toFind.GUID.ToString();
                        string XUID = toFind.GetXUID().ToString();
                        StreamWriter sw = new StreamWriter("scripts\\GPIv3\\SavedPlayer\\alldata.txt", true);
                        sw.WriteLine("Ip= " + IP);
                        sw.WriteLine("Name= " + name);
                        sw.WriteLine("XUID= " + XUID);
                        sw.WriteLine("GUID= " + GUID);
                        sw.WriteLine("HWID= " + HWID);
                        sw.WriteLine("SavedBy: " + player.Name);
                        sw.WriteLine("===================================================");
                        sw.Flush();
                        sw.Close();
                        Utilities.RawSayTo(player, TAG + " Player data saved.");
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!level"))
            {
                if (strArray1.Length == 1)
                {
                    string rank = GetRankByName(player.Name);
                    string str1 = null;
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                    {
                        if (str.StartsWith(rank + "_level"))
                        {
                            str1 = str.Split(new char[1]
                            {
                                '='
                            })[1];
                        }
                    }
                    Utilities.RawSayTo(player, TAG + " Your rank level is: ^6" + str1);
                }
                if (strArray1.Length == 2)
                {
                    Entity entity = FindByName(strArray1[1]);
                    if (entity == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found player or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string rank = GetRankByName(entity.Name);
                        string str2 = null;
                        foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                        {
                            if (str.StartsWith(rank + "_level"))
                            {
                                str2 = str.Split(new char[1]
                                {
                                    '='
                                })[1];
                            }
                        }
                        Utilities.RawSayTo(player, TAG + " ^6" + entity.Name + " ^7rank level is: ^6" + str2);
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!rank"))
            {
                if (strArray1.Length < 2)
                {
                    string plgr = GetRankByName(player.Name);
                    Utilities.RawSayTo(player, "Your rank is: ^6" + plgr + "^7.");
                }
                if (strArray1.Length > 1)
                {
                    Entity ranker = FindByName(strArray1[1]);
                    if (ranker == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string thisplgr = GetRankByName(ranker.Name);
                        if (thisplgr == "Host")
                        {
                            Utilities.RawSayTo(player, "^6" + ranker.Name + "^7 rank is: ^6User^7.");
                        }
                        else if (thisplgr != "Host")
                        {
                            Utilities.RawSayTo(player, "^6" + ranker.Name + "^7 rank is: ^6" + thisplgr + "^7.");
                        }
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!giveweap"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, "Format: ^1!giveweap ^6<cons_weapon>");
                }
                if (strArray1.Length == 2)
                {
                    player.GiveWeapon(strArray1[1]);
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!endnuke"))
            {
                ConLog.PlayerUseCommandEv(player, strArray1[0]);
                this.NukePlayers(player);
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!guid"))
            {
                if (strArray1.Length == 1)
                {
                    Entity player1 = player;
                    guid = player.GUID;
                    string message1 = "^6Your guid is: ^2" + guid.ToString();
                    Utilities.RawSayTo(player1, message1);
                }
                if (strArray1.Length == 2 && GetRankByName(player.Name) != "User")
                {
                    Entity guider = FindByName(strArray1[1]);
                    if (guider == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        Entity player2 = player;
                        guid = guider.GUID;
                        string message2 = "^6" + guider.Name + " ^7guid is: ^2" + guid.ToString();
                        Utilities.RawSayTo(player2, message2);
                        Print(guider.Name + " guid is: " + guid.ToString());
                    }
                }
                if (strArray1.Length == 2 && GetRankByName(player.Name) == "User")
                {
                    Utilities.RawSayTo(player, TAG + " You are ^6NOT ALLOWED^7 to see other players GUID.");
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!hwid"))
            {
                if (strArray1.Length == 1)
                {
                    string hwid = player.HWID;
                    string message1 = "^6Your hwid is: ^2" + hwid;
                    Utilities.RawSayTo(player, message1);
                }

                if (strArray1.Length == 2)
                {
                    Entity hwider = FindByName(strArray1[1]);
                    if (hwider == null)
                    {
                        Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
                    }
                    else
                    {
                        string hwid = hwider.HWID;
                        string message2 = "^6" + hwider.Name + " ^7guid is: ^2" + hwid;
                        Utilities.RawSayTo(player, message2);
                        Print(hwider.Name + " hwid is: " + hwid);
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!groups"))
            {
                string line;
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!groups ^6<page>");
                }
                if (strArray1.Length == 2)
                {
                    //settings
                    int pages = 0;
                    int maxN = 0;
                    int minN = 0;
                    int arayvalue = 0;

                    int n1 = 0;
                    int n2 = 0;
                    int n3 = 0;
                    int n4 = 0;
                    int n5 = 0;
                    int n6 = 0;
                    int n7 = 0;
                    int n8 = 0;
                    foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
                    {
                        if (str.StartsWith("groups="))
                        {
                            line = str.Substring(7);
                            string[] list = line.Split(new char[] { ',' });

                            //setting up pages & commands
                            string strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                            int length = list.Length;
                            int final = 0;
                            int lastPnum = 0;
                            if (length.ToString().EndsWith("0")) { final = length + 0; lastPnum = 0; }
                            if (length.ToString().EndsWith("1")) { final = length + 9; lastPnum = 1; }
                            if (length.ToString().EndsWith("2")) { final = length + 8; lastPnum = 2; }
                            if (length.ToString().EndsWith("3")) { final = length + 7; lastPnum = 3; }
                            if (length.ToString().EndsWith("4")) { final = length + 6; lastPnum = 4; }
                            if (length.ToString().EndsWith("5")) { final = length + 5; lastPnum = 5; }
                            if (length.ToString().EndsWith("6")) { final = length + 4; lastPnum = 6; }
                            if (length.ToString().EndsWith("7")) { final = length + 3; lastPnum = 7; }
                            if (length.ToString().EndsWith("8")) { final = length + 2; lastPnum = 8; }
                            if (length.ToString().EndsWith("9")) { final = length + 1; lastPnum = 9; }
                            pages = final / 10;
                            maxN = 9;
                            minN = 0;
                            arayvalue = minN;

                            n1 = 1;
                            n2 = 2;
                            n3 = 3;
                            n4 = 4;
                            n5 = 5;
                            n6 = 6;
                            n7 = 7;
                            n8 = 8;

                            //if page is bigger than the book
                            if (Convert.ToInt32(strArray1[1]) > pages)
                            {
                                Utilities.RawSayTo(player, TAG + " There is no more pages!");
                                break;
                            }
                            //Page 0?
                            if (Convert.ToInt32(strArray1[1]) == 0)
                            {
                                Utilities.RawSayTo(player, TAG + " Why page 0?");
                                break;
                            }
                            //No book?
                            if (Convert.ToInt32(strArray1[1]) < 0)
                            {
                                Utilities.RawSayTo(player, TAG + " Why negative numbers??");
                                break;
                            }
                            //If smaller or equals than pages and bigger than 0
                            if (Convert.ToInt32(strArray1[1]) <= pages && Convert.ToInt32(strArray1[1]) > 0)
                            {
                                Utilities.RawSayTo(player, "--- ^2Groups ^7(^2" + strArray1[1] + "/" + pages + "^7) ---");
                                //If page = 1
                                if (Convert.ToInt32(strArray1[1]) == 1)
                                {
                                    minN = 0;
                                    n1 = 1;
                                    n2 = 2;
                                    n3 = 3;
                                    n4 = 4;
                                    n5 = 5;
                                    n6 = 6;
                                    n7 = 7;
                                    n8 = 8;
                                    maxN = 9;
                                    strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    if (lastPnum == 1 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN];
                                    }
                                    if (lastPnum == 2 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1];
                                    }
                                    if (lastPnum == 3 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2];
                                    }
                                    if (lastPnum == 4 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3];
                                    }
                                    if (lastPnum == 5 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4];
                                    }
                                    if (lastPnum == 6 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5];
                                    }
                                    if (lastPnum == 7 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6];
                                    }
                                    if (lastPnum == 8 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7];
                                    }
                                    if (lastPnum == 9 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8];
                                    }
                                    if (lastPnum == 0 && pages == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    }
                                }
                                //Pages from 2 to pre-last
                                if (Convert.ToInt32(strArray1[1]) != 1 && Convert.ToInt32(strArray1[1]) < pages && Convert.ToInt32(strArray1[1]) != pages)
                                {
                                    maxN = (Convert.ToInt32(strArray1[1]) * 10) - 1;
                                    n1 = (maxN - 1);
                                    n2 = (maxN - 2);
                                    n3 = (maxN - 3);
                                    n4 = (maxN - 4);
                                    n5 = (maxN - 5);
                                    n6 = (maxN - 6);
                                    n7 = (maxN - 7);
                                    n8 = (maxN - 8);
                                    minN = (maxN - 9);
                                    strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                }
                                //Last page
                                if (Convert.ToInt32(strArray1[1]) == pages)
                                {
                                    maxN = (Convert.ToInt32(strArray1[1]) * 10) - 1;
                                    n1 = (maxN - 8);
                                    n2 = (maxN - 7);
                                    n3 = (maxN - 6);
                                    n4 = (maxN - 5);
                                    n5 = (maxN - 4);
                                    n6 = (maxN - 3);
                                    n7 = (maxN - 2);
                                    n8 = (maxN - 1);
                                    minN = (maxN - 9);

                                    if (lastPnum == 1)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN];
                                    }
                                    if (lastPnum == 2)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1];
                                    }
                                    if (lastPnum == 3)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2];
                                    }
                                    if (lastPnum == 4)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3];
                                    }
                                    if (lastPnum == 5)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4];
                                    }
                                    if (lastPnum == 6)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5];
                                    }
                                    if (lastPnum == 7)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6];
                                    }
                                    if (lastPnum == 8)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7];
                                    }
                                    if (lastPnum == 9)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8];
                                    }
                                    if (lastPnum == 0)
                                    {
                                        strarr = TAG + " Groups: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    }
                                }
                                //Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7)");
                                Utilities.RawSayTo(player, strarr);

                                //if (keyValuePair.Key == this.GetRankByName(player.Name))
                                //{
                                //    if (keyValuePair.Value.Length < (Convert.ToInt32(strArray1[1]) * 10))
                                //    {
                                //        char[] strCA = keyValuePair.Value.Replace(",", "^7,^6").ToCharArray();
                                //    }
                                //    Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7)");
                                //    Utilities.RawSayTo(player, "You can use: ^6" + "//dat array of commands//");
                                //}
                                break;
                            }
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!help") || strArray1[0].Equals("!h"))
            {
                if (strArray1.Length == 1)
                {
                    Utilities.RawSayTo(player, "Format: ^1!help^7/^1!h ^6<page>");
                    //foreach (KeyValuePair<string, string> keyValuePair in this.gCommands)
                    //{
                    //    if (keyValuePair.Key == this.GetRankByName(player.Name))
                    //    {
                    //        this.TellClient(player, "^6You can use: ^7" + keyValuePair.Value.Replace(",", "^6,^7"));
                    //    }
                    //}
                }
                if (strArray1.Length == 2)
                {
                    //settings
                    int pages = 0;
                    int maxN = 0;
                    int minN = 0;
                    int arayvalue = 0;

                    int n1 = 0;
                    int n2 = 0;
                    int n3 = 0;
                    int n4 = 0;
                    int n5 = 0;
                    int n6 = 0;
                    int n7 = 0;
                    int n8 = 0;
                    foreach (KeyValuePair<string, string> keyValuePair in this.gCommands)
                    {
                        if (keyValuePair.Key == this.GetRankByName(player.Name))
                        {
                            //putting all available commands in string[].
                            string commands = keyValuePair.Value.Replace(",", ",");
                            string[] list = commands.Split(new char[] { ',' });

                            //setting up pages & commands
                            string strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                            int length = list.Length;
                            int final = 0;
                            int lastPnum = 0;
                            if (length.ToString().EndsWith("0")) { final = length + 0; lastPnum = 0; }
                            if (length.ToString().EndsWith("1")) { final = length + 9; lastPnum = 1; }
                            if (length.ToString().EndsWith("2")) { final = length + 8; lastPnum = 2; }
                            if (length.ToString().EndsWith("3")) { final = length + 7; lastPnum = 3; }
                            if (length.ToString().EndsWith("4")) { final = length + 6; lastPnum = 4; }
                            if (length.ToString().EndsWith("5")) { final = length + 5; lastPnum = 5; }
                            if (length.ToString().EndsWith("6")) { final = length + 4; lastPnum = 6; }
                            if (length.ToString().EndsWith("7")) { final = length + 3; lastPnum = 7; }
                            if (length.ToString().EndsWith("8")) { final = length + 2; lastPnum = 8; }
                            if (length.ToString().EndsWith("9")) { final = length + 1; lastPnum = 9; }
                            pages = final / 10;
                            maxN = 9;
                            minN = 0;
                            arayvalue = minN;

                            n1 = 1;
                            n2 = 2;
                            n3 = 3;
                            n4 = 4;
                            n5 = 5;
                            n6 = 6;
                            n7 = 7;
                            n8 = 8;

                            //if page is bigger than the book
                            if (Convert.ToInt32(strArray1[1]) > pages)
                            {
                                Utilities.RawSayTo(player, TAG + " There is no more pages!");
                                break;
                            }
                            //Page 0?
                            if (Convert.ToInt32(strArray1[1]) == 0)
                            {
                                Utilities.RawSayTo(player, TAG + " Why page 0?");
                                break;
                            }
                            //No book?
                            if (Convert.ToInt32(strArray1[1]) < 0)
                            {
                                Utilities.RawSayTo(player, TAG + " Why negative numbers??");
                                break;
                            }
                            //If smaller or equals than pages and bigger than 0
                            if (Convert.ToInt32(strArray1[1]) <= pages && Convert.ToInt32(strArray1[1]) > 0)
                            {
                                Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7) ---");
                                //If page = 1
                                if (Convert.ToInt32(strArray1[1]) == 1)
                                {
                                    minN = 0;
                                    n1 = 1;
                                    n2 = 2;
                                    n3 = 3;
                                    n4 = 4;
                                    n5 = 5;
                                    n6 = 6;
                                    n7 = 7;
                                    n8 = 8;
                                    maxN = 9;
                                    strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    if (lastPnum == 1 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN];
                                    }
                                    if (lastPnum == 2 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1];
                                    }
                                    if (lastPnum == 3 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2];
                                    }
                                    if (lastPnum == 4 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3];
                                    }
                                    if (lastPnum == 5 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4];
                                    }
                                    if (lastPnum == 6 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5];
                                    }
                                    if (lastPnum == 7 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6];
                                    }
                                    if (lastPnum == 8 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7];
                                    }
                                    if (lastPnum == 9 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8];
                                    }
                                    if (lastPnum == 0 && pages == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    }
                                }
                                //Pages from 2 to pre-last
                                if (Convert.ToInt32(strArray1[1]) != 1 && Convert.ToInt32(strArray1[1]) < pages && Convert.ToInt32(strArray1[1]) != pages)
                                {
                                    maxN = (Convert.ToInt32(strArray1[1]) * 10) - 1;
                                    n1 = (maxN - 1);
                                    n2 = (maxN - 2);
                                    n3 = (maxN - 3);
                                    n4 = (maxN - 4);
                                    n5 = (maxN - 5);
                                    n6 = (maxN - 6);
                                    n7 = (maxN - 7);
                                    n8 = (maxN - 8);
                                    minN = (maxN - 9);
                                    strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                }
                                //Last page
                                if (Convert.ToInt32(strArray1[1]) == pages)
                                {
                                    maxN = (Convert.ToInt32(strArray1[1]) * 10) - 1;
                                    n1 = (maxN - 8);
                                    n2 = (maxN - 7);
                                    n3 = (maxN - 6);
                                    n4 = (maxN - 5);
                                    n5 = (maxN - 4);
                                    n6 = (maxN - 3);
                                    n7 = (maxN - 2);
                                    n8 = (maxN - 1);
                                    minN = (maxN - 9);

                                    if (lastPnum == 1)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN];
                                    }
                                    if (lastPnum == 2)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1];
                                    }
                                    if (lastPnum == 3)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2];
                                    }
                                    if (lastPnum == 4)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3];
                                    }
                                    if (lastPnum == 5)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4];
                                    }
                                    if (lastPnum == 6)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5];
                                    }
                                    if (lastPnum == 7)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6];
                                    }
                                    if (lastPnum == 8)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7];
                                    }
                                    if (lastPnum == 9)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8];
                                    }
                                    if (lastPnum == 0)
                                    {
                                        strarr = TAG + " You can use: ^2" + list[minN] + "^7,^2" + list[n1] + "^7,^2" + list[n2] + "^7,^2" + list[n3] + "^7,^2" + list[n4] + "^7,^2" + list[n5] + "^7,^2" + list[n6] + "^7,^2" + list[n7] + "^7,^2" + list[n8] + "^7,^2" + list[maxN];
                                    }
                                }
                                //Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7)");
                                Utilities.RawSayTo(player, strarr);

                                //if (keyValuePair.Key == this.GetRankByName(player.Name))
                                //{
                                //    if (keyValuePair.Value.Length < (Convert.ToInt32(strArray1[1]) * 10))
                                //    {
                                //        char[] strCA = keyValuePair.Value.Replace(",", "^7,^6").ToCharArray();
                                //    }
                                //    Utilities.RawSayTo(player, "--- ^2Help ^7(^2" + strArray1[1] + "/" + pages + "^7)");
                                //    Utilities.RawSayTo(player, "You can use: ^6" + "//dat array of commands//");
                                //}
                                break;
                            }
                        }
                    }
                }
                return BaseScript.EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            if (strArray1[0].Equals("!about"))
            {
                if (strArray1.Length == 1 || strArray1.Length >= 3)
                {
                    Utilities.RawSayTo(player, TAG + " Usage: ^1!about ^6<!command>^7.");
                }
                if (strArray1.Length == 2)
                {
                    if (strArray1[1].Equals("!about"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows short info about commands. Usage: ^1!about ^6<!command>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!help") || strArray1[1].Equals("!h"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows all available commands. Usage: ^1!help^7/^1!h ^6[page]^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!hwid"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows player HWID. Usage: ^1!hwid ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!guid"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows your/player GUID. Usage: ^1!guid ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!endnuke"))
                    {
                        Utilities.RawSayTo(player, TAG + " End round with a nuke. Usage: ^1!endnuke^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!giveweap"))
                    {
                        Utilities.RawSayTo(player, TAG + " Give a weapon. Usage: ^1!giveweap ^6<full_console_weapon_name>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!rank"))
                    {
                        Utilities.RawSayTo(player, TAG + " Show your/player. Usage: ^1!rank ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!level"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows your/player rank level. Usage: ^1!level ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!rules"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows all rules. Usage: ^1!rules^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!sources"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows scripts that were used. Usage: ^1!sources^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!contact"))
                    {
                        Utilities.RawSayTo(player, TAG + " Show ways to contact the script dev (LiteralLySugaR). Usage: ^1!contact^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!version") || strArray1[1].Equals("!ver"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows the plugin version. Usage: ^1!version^7/^1!ver^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!add"))
                    {
                        Utilities.RawSayTo(player, TAG + " Add to rank a player. Usage: ^1!add ^6<group> <player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!takeweap"))
                    {
                        Utilities.RawSayTo(player, TAG + " Take a weapon from you/player. Usage: ^1!takeweap ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!addweap"))
                    {
                        Utilities.RawSayTo(player, TAG + " Give weapon to a player. Usage: ^1!addweap ^6<full_console_weapon_name> <player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!convert"))
                    {
                        Utilities.RawSayTo(player, TAG + " Convert weapon (ex: usp) to console name (iw5_usp45_mp). Usage: ^1!convert ^6<weapon>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!maprest") || strArray1[1].Equals("!maprestart"))
                    {
                        Utilities.RawSayTo(player, TAG + " Restart current map. Usage: ^1!maprestart^7/^1!maprest^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!fastrestart") || strArray1[1].Equals("!fastrest"))
                    {
                        Utilities.RawSayTo(player, TAG + " Do a fast restart. Usage: ^1!fastrestart^7/^1!fastrest^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!spec"))
                    {
                        Utilities.RawSayTo(player, TAG + " Enter/exit fly mode. Usage: ^1!spec^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!kill"))
                    {
                        Utilities.RawSayTo(player, TAG + " Kill a player. Usage: ^1!kill ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!mods"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows online moderators. Usage: ^1!mods^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!admins"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows online admins. Usage: ^1!admins^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!discord") || strArray1[1].Equals("!dsc"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows discord server link. Usage: ^1!discord^7/^1!dsc^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!suicide") || strArray1[1].Equals("!s"))
                    {
                        Utilities.RawSayTo(player, TAG + " Kill yourself. Usage: ^1!suicide^7/^1!s^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!gotopos"))
                    {
                        Utilities.RawSayTo(player, TAG + " Go to a specific position. Usage: ^1!gotopos ^6<position_name>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!report"))
                    {
                        Utilities.RawSayTo(player, TAG + " Report a player. Usage: ^1!report ^6<player> <reason>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!stopserver"))
                    {
                        Utilities.RawSayTo(player, TAG + " Stops the server. Usage: ^1!stopserver^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!removepos"))
                    {
                        Utilities.RawSayTo(player, TAG + " Remove saved position. Usage: ^1!removepos ^6<position>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!savepos"))
                    {
                        Utilities.RawSayTo(player, TAG + " Save a position. Usage: ^1!savepos ^6<position_name>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!poslist"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows all positions on the current map. Usage: ^1!poslist^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ReqMod") || strArray1[1].Equals("!rm"))
                    {
                        Utilities.RawSayTo(player, TAG + " Request moderator. Usage: ^1!ReqMod^7/^1!rm ^6<your discord tag> <admin to request>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!nextmap"))
                    {
                        Utilities.RawSayTo(player, TAG + " Start next map. Usage: ^1!nextmap^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ammo"))
                    {
                        Utilities.RawSayTo(player, TAG + " Add max ammo to current weapon. Usage: ^1!ammo ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!setpos"))
                    {
                        Utilities.RawSayTo(player, TAG + " Advanced coords-teleportation command. Usage: ^1!setpos ^6[x] [y] [z]^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!getpos"))
                    {
                        Utilities.RawSayTo(player, TAG + " Get your current coords. Usage: ^1!getpos^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!pm"))
                    {
                        Utilities.RawSayTo(player, TAG + " Write a private message to a player. Usage: ^1!pm ^6<player> <message>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!switch"))
                    {
                        Utilities.RawSayTo(player, TAG + " switch team (debug-used). Usage: ^1!switch^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!endgame"))
                    {
                        Utilities.RawSayTo(player, TAG + " Finish current game. Usage: ^1!endgame ^6<reason>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!goto"))
                    {
                        Utilities.RawSayTo(player, TAG + " Go to a player. Usage: ^1!goto ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!tpt"))
                    {
                        Utilities.RawSayTo(player, TAG + " teleport player1 to player2. Usage: ^1!tpt ^6<player1> <player2>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!bring") || strArray1[1].Equals("!br"))
                    {
                        Utilities.RawSayTo(player, TAG + " Bring a player. Usage: ^1!bring^7/^1!br ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!whois"))
                    {
                        Utilities.RawSayTo(player, TAG + " Get info about player. Usage: ^1!whois ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!playerinfo") || strArray1[1].Equals("!pi"))
                    {
                        Utilities.RawSayTo(player, TAG + " Same as ^1!whois^7 command.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!spy"))
                    {
                        Utilities.RawSayTo(player, TAG + " Allows to see what commands players are using. Usage: ^1!spy^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ac"))
                    {
                        Utilities.RawSayTo(player, TAG + " send message to admin chat. Usage: ^1!ac ^6<message>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!team"))
                    {
                        Utilities.RawSayTo(player, TAG + " I don't really remember what this does... Usage: ^1!team ^6<message>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ident"))
                    {
                        Utilities.RawSayTo(player, TAG + " Get player's mbs. Usage: ^1!ident ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!mbs"))
                    {
                        Utilities.RawSayTo(player, TAG + " Set your mbs. Usage: ^1!mbs ^6<cia,mi6,kgb,none>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!n") || strArray1[1].Equals("!y"))
                    {
                        Utilities.RawSayTo(player, TAG + " vote no, vote yes during votes. Usage: ^1!n^7/^1!y^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!vote"))
                    {
                        Utilities.RawSayTo(player, TAG + " Vote for map or kick. Usage: ^1!vote ^6<map,kick> <arg>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!map"))
                    {
                        Utilities.RawSayTo(player, TAG + " Change the map. Usage: ^1!map ^6<mapname>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ac130"))
                    {
                        Utilities.RawSayTo(player, TAG + " Gives AC130 gun. Usage: ^1!ac130 ^6[25,40,105]^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!unban"))
                    {
                        Utilities.RawSayTo(player, TAG + " Unban a player (currently work for vanilla bans). Usage: ^1!unban ^6<HWID>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ipban"))
                    {
                        Utilities.RawSayTo(player, TAG + " Ip-ban a player. Usage: ^1!ipban ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!dban") || strArray1[1].Equals("!hban"))
                    {
                        Utilities.RawSayTo(player, TAG + " Event-ban a player.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!drop") || strArray1[1].Equals("!kick"))
                    {
                        Utilities.RawSayTo(player, TAG + " Kick a player (idk what difference between drop and kick). Usage: ^1!drop^7/^1!kick ^6<player> <reason>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!tempban") || strArray1[1].Equals("!tb"))
                    {
                        Utilities.RawSayTo(player, TAG + " Temp-ban a player. Usage: ^1!tempban^7/^1!tb ^6<player> <reason>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!ban"))
                    {
                        Utilities.RawSayTo(player, TAG + " Perm-ban a player. Usage: ^1!ban ^6<player> <reason>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!action"))
                    {
                        Utilities.RawSayTo(player, TAG + " ^1REMOVED COMMAND^7. Usage: ^1!action ^6<kick,ban,tempban> [player] <reason>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!slot"))
                    {
                        Utilities.RawSayTo(player, TAG + " Shows your/player slot on the server. Usage: ^1!slot ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!unadd") || strArray1[1].Equals("!remove"))
                    {
                        Utilities.RawSayTo(player, TAG + " Remove a player from rank. Usage: ^1!unadd^7/^1!remove ^6<group> <player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!groups"))
                    {
                        Utilities.RawSayTo(player, TAG + " Get a list of all ranks. Usage: ^1!groups ^6[page]^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!afk"))
                    {
                        Utilities.RawSayTo(player, TAG + " Give immune against afk system when you are really afk (not moving). Usage: ^1!afk^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!cfg"))
                    {
                        Utilities.RawSayTo(player, TAG + " Change the config. Usage: ^1!cfg ^6<setting_name> {value}^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!poswhitelist") || strArray1[1].Equals("!poswl"))
                    {
                        Utilities.RawSayTo(player, TAG + " Get a list of whitelisted positions. Usage: ^1!poswhitelist^7/^1!poswl ^6[page]^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!seed"))
                    {
                        Utilities.RawSayTo(player, TAG + " Get current server seed. Usage: ^1!seed^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!generate"))
                    {
                        Utilities.RawSayTo(player, TAG + " Generate new server seed. Usage: ^1!generate^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!saveplayer") || strArray1[1].Equals("!svpl"))
                    {
                        Utilities.RawSayTo(player, TAG + " Saves player info. Usage: ^1!saveplayer^7/^1!svpl ^6<player>^7.");
                        return EventEat.EatGame;
                    }
                    if (strArray1[1].Equals("!freeze"))
                    {
                        Utilities.RawSayTo(player, TAG + " Freeze a player. Usage: ^1!freeze ^6<player> <get>^7.");
                        return EventEat.EatGame;
                    }
                    //I will leave that. Just for fun so people think this command exists XD
                    // +fun description, hahaha
                    if (strArray1[1].Equals("!anticheat"))
                    {
                        Utilities.RawSayTo(player, TAG + " Tbh i added this so you know that i have this done. Usage: ^1!anticheat^7.");
                        return EventEat.EatGame;
                    }
                    else
                    {
                        Utilities.RawSayTo(player, TAG + " This command does not exist or dont have a description.");
                        return EventEat.EatGame;
                    }
                }
                return EventEat.EatGame;
            }
            /* -------------------------------------------------------------------------------------------------------------------------------------- */
            return EventEat.EatNone;
        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        //internal void DeathLogic(Entity entity, int IntervalA, int IntervalB, int IntervalC, Vector3 PlayerPosA, Vector3 Pos, int type)
        //{
        //    entity.SpawnedPlayer += delegate ()
        //    {
        //        AfterDelay(2000, () =>
        //        {

        //        });
        //    };
        //}
        internal void PositionHandler(Entity player, int IntervalA, Vector3 PlayerPosA, int IntervalB, int IntervalC)
        {
            IntervalB = 0;
            IntervalC = 0;
            OnInterval(4000, () =>
            {
                IntervalB = 0;
                IntervalC = 0;
                PlayerPosA = player.Origin;
                if (Players.Contains(player))
                {
                    if (GSCFunctions.IsAlive(player) && IntervalA == 2 && PlayerPosA.ToString() == player.Origin.ToString())
                    {
                        /*DEBUG*/
                        //Print("player " + player.Name + " is afk detected");
                        /*DEBUG*/
                        IsAfk(player, IntervalB, PlayerPosA, PlayerPosA, IntervalA, IntervalC);
                        IntervalA = 0;
                        IntervalB = 0;
                        IntervalC = 0;
                        return false;
                    }
                    if (GSCFunctions.IsAlive(player) && IntervalA != 2 && (PlayerPosA.ToString() != player.Origin.ToString()))
                    {
                        /*DEBUG*/
                        //Print("player " + player.Name + " moved on IntervalA");
                        /*DEBUG*/
                        IntervalA = 0;
                        IntervalB = 0;
                        IntervalC = 0;
                        return true;
                    }
                    if (!GSCFunctions.IsAlive(player))
                    {
                        /*DEBUG*/
                        //Print("player " + player.Name + " died on IntervalA");
                        /*DEBUG*/
                        player.SpawnedPlayer += delegate ()
                        {
                            PlayerPosA = player.Origin;
                            IntervalB = 0;
                            IntervalC = 0;
                            return;
                            //AfterDelay(2000, () =>
                            //{
                            //    PlayerPosA = player.Origin;
                            //    IntervalB = 0;
                            //    IntervalC = 0;
                            //    return;
                            //});
                            //return;
                        };
                        return true;
                    }
                }
                if (!Players.Contains(player))
                {
                    IntervalA = 0;
                    IntervalB = 0;
                    IntervalC = 0;
                    return false;
                }
                /*DEBUG*/
                //Print("IntervalA=" + IntervalA);
                /*DEBUG*/
                IntervalB = 0;
                IntervalC = 0;
                ++IntervalA;
                return true;
            });
        }
        internal void IsAfk(Entity player, int IntervalB, Vector3 Pos, Vector3 PlayerPosA, int IntervalA, int IntervalC)
        {
            IntervalA = 0;
            IntervalC = 0;
            Pos = player.Origin;
            OnInterval(1000, () =>
            {
                IntervalA = 0;
                IntervalC = 0;
                /*DEBUG*/
                //Print("IntervalB= " + IntervalB);
                /*DEBUG*/
                if (Players.Contains(player))
                {
                    if (GSCFunctions.IsAlive(player))
                    {
                        if (AFKs.Contains(player))
                        {
                            /*DEBUG*/
                            //Print("player " + player.Name + " is in afk list");
                            /*DEBUG*/
                            IntervalB = 0;
                            IntervalA = 0;
                            IntervalC = 0;
                            return true;
                        }
                        if (!AFKs.Contains(player) && IntervalB == 10 && player.Origin.ToString() == Pos.ToString())
                        {
                            /*DEBUG*/
                            //Print("player " + player.Name + " isnt in afk list");
                            /*DEBUG*/
                            IntervalB = 0;
                            IntervalA = 0;
                            IntervalC = 0;
                            this.AfkTimeOut(player, IntervalC, Pos, IntervalA, PlayerPosA, IntervalB);
                            return false;
                        }
                        if (!AFKs.Contains(player) && IntervalB < 10 && (player.Origin.ToString() != Pos.ToString()))
                        {
                            /*DEBUG*/
                            //Print("player " + player.Name + " moved on IntervalB");
                            /*DEBUG*/
                            IntervalB = 0;
                            IntervalA = 0;
                            IntervalC = 0;
                            this.PositionHandler(player, IntervalA, PlayerPosA, IntervalB, IntervalC);
                            return false;
                        }
                    }
                    if (!GSCFunctions.IsAlive(player))
                    {
                        /*DEBUG*/
                        //Print("player " + player.Name + " died on IntervalB");
                        /*DEBUG*/
                        player.SpawnedPlayer += delegate ()
                        {
                            Pos = player.Origin;
                            IntervalA = 0;
                            IntervalC = 0;
                            return;
                            //AfterDelay(2000, () =>
                            //{
                            //    Pos = player.Origin;
                            //    IntervalA = 0;
                            //    IntervalC = 0;
                            //    return;
                            //});
                            //return;
                        };
                        return true;
                    }
                }
                if (!Players.Contains(player))
                {
                    IntervalA = 0;
                    IntervalB = 0;
                    IntervalC = 0;
                    return false;
                }
                IntervalA = 0;
                IntervalC = 0;
                ++IntervalB;
                return true;
            });
        }
        internal void AfkTimeOut(Entity player, int IntervalC, Vector3 Pos, int IntervalA, Vector3 PlayerPosA, int IntervalB)
        {
            int timeout = 0;
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("afk_timeout"))
                {
                    timeout = Convert.ToInt32(str.Split(new char[1] { '=' })[1]);
                }
            }
            IntervalB = 0;
            IntervalA = 0;
            OnInterval(2000, () =>
            {
                IntervalB = 0;
                IntervalA = 0;
                /*DEBUG*/
                //Print("IntervalC= " + IntervalC);
                /*DEBUG*/
                if (Players.Contains(player))
                {
                    if (GSCFunctions.IsAlive(player))
                    {
                        if (IntervalC == (timeout - 60) && player.Origin.ToString() == Pos.ToString() && !AFKs.Contains(player))
                        {
                            player.IPrintLnBold("WARNING: you will be disconnected due to inactivity.");
                        }
                        if (IntervalC >= timeout && player.Origin.ToString() == Pos.ToString() && !AFKs.Contains(player))
                        {
                            /*DEBUG*/
                            //Print("player " + player.Name + " is kicked.");
                            /*DEBUG*/
                            IntervalC = 0;
                            IntervalB = 0;
                            IntervalA = 0;
                            IsKicked.Add(player.Name);
                            Utilities.ExecuteCommand("dropclient " + player.GetEntityNumber() + " Afk timeout.");
                            return false;
                        }
                        if (IntervalC < timeout && (player.Origin.ToString() != Pos.ToString()))
                        {
                            /*DEBUG*/
                            //Print("player " + player.Name + " moved on IntervalC");
                            /*DEBUG*/
                            IntervalC = 0;
                            IntervalA = 0;
                            IntervalB = 0;
                            this.PositionHandler(player, IntervalA, PlayerPosA, IntervalB, IntervalC);
                            return false;
                        }
                        if (IntervalC < timeout && AFKs.Contains(player))
                        {
                            /*DEBUG*/
                            //Print("player " + player.Name + " is afk detected on IntervalC");
                            /*DEBUG*/
                            IntervalC = 0;
                            IntervalB = 0;
                            IntervalA = 0;
                            this.PositionHandler(player, IntervalA, PlayerPosA, IntervalB, IntervalC);
                            return false;
                        }
                    }
                    if (!GSCFunctions.IsAlive(player))
                    {
                        /*DEBUG*/
                        //Print("player " + player.Name + " died on IntervalC");
                        /*DEBUG*/
                        player.SpawnedPlayer += delegate ()
                        {
                            Pos = player.Origin;
                            IntervalB = 0;
                            IntervalA = 0;
                            return;
                            //AfterDelay(2000, () =>
                            //{
                            //    Pos = player.Origin;
                            //    IntervalB = 0;
                            //    IntervalA = 0;
                            //    return;
                            //});
                            //return;
                        };
                        return true;
                    }
                }
                if (!Players.Contains(player))
                {
                    IntervalA = 0;
                    IntervalB = 0;
                    IntervalC = 0;
                    return false;
                }
                Pos = player.Origin;
                IntervalB = 0;
                IntervalA = 0;
                IntervalC += 2;
                return true;
            });
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        internal int chance = 0;
        internal string[] line = null;
        internal int passnum = 0;
        internal string strSeed = "";
        private protected List<string> DLCmaps = new List<string>
        {
            "mp_hillside_ss",
            "mp_restrepo_ss",
            "mp_overwatch",
            "mp_terminal_cls",
            "mp_park",
            "mp_italy",
            "mp_morningwood",
            "mp_meteora",
            "mp_cement",
            "mp_qadeem",
            "mp_aground_ss",
            "mp_courtyard_ss",
            "mp_burn_ss",
            "mp_crosswalk_ss",
            "mp_six_ss",
            "mp_shipbreaker",
            "mp_roughneck",
            "mp_moab",
            "mp_boardwalk",
            "mp_nola"
        };
        private protected List<string> CML = new List<string>
        {
            "mp_dome",
            "mp_plaza2",
            "mp_alpha",
            //"mp_hardhat",
            //"mp_bootleg",
            //"mp_interchange",
            //"mp_carbon",
            //"mp_exchange",
            "mp_radar",
            "mp_hillside_ss",
            "mp_restrepo_ss",
            "mp_overwatch",
            //"mp_lambeth",
            "mp_terminal_cls",
            "mp_underground",
            //"mp_village",
            //"mp_bravo",
            //"mp_paris",
            //"mp_mogadishu",
            "mp_seatown",
            "mp_park",
            "mp_italy",
            "mp_morningwood",
            "mp_meteora",
            "mp_cement",
            "mp_qadeem",
            "mp_aground_ss",
            "mp_courtyard_ss",
            "mp_burn_ss",
            "mp_crosswalk_ss",
            "mp_six_ss",
            "mp_shipbreaker",
            "mp_roughneck",
            "mp_moab",
            "mp_boardwalk",
            "mp_nola"
        };
        internal void SeedSaving(string seed, string initSeed, int chance)
        {
            /*DEBUG*/
            //Print("Seed=" + strSeed);
            /*DEBUG*/
            string[] line = new string[3];
            line[0] = "seed=" + seed;
            line[1] = "init=" + initSeed;
            line[2] = "chance=" + chance;
            if (!File.Exists("scripts\\GPIv3\\Seed\\Saves.txt"))
            {
                File.Create("scripts\\GPIv3\\Seed\\Saves.txt").Close();
            }
            File.WriteAllLines("scripts\\GPIv3\\Seed\\Saves.txt", line);
            /*DEBUG*/
            //Print("Seed saved as: seed=" + strSeed + " init=" + SeedFull[0] + SeedFull[1] + SeedFull[2] + SeedFull[3] + " chance=" + chance);
            /*DEBUG*/
        }
        internal void SeedGenerator()
        {
            StreamWriter sw = new StreamWriter("scripts\\GPIv3\\Seed\\Gen.txt", false);
            //Ok, this idea gave me Im3adGirL, why im doing this?
            //for dlc maps to be choosen often than regular
            //1-3 numbers: map to be choosen
            //4-6 numbers - gametype
            //7-9 numbers - percentage of gametype
            //10-12 numbers - percentage of nextseed
            //Seed generator
            int seed1 = preseed1.Next(0, 25);
            /*DEBUG*/
            //Print("Seed1=" + seed1);
            /*DEBUG*/
            int seed2 = preseed2.Next(0, 14);
            /*DEBUG*/
            //Print("Seed2=" + seed2);
            /*DEBUG*/
            int seed3 = preseed3.Next(100, 999);
            /*DEBUG*/
            //Print("Seed3=" + seed3);
            /*DEBUG*/
            int seed4 = preseed4.Next(35, 99);
            /*DEBUG*/
            //Print("Seed4=" + seed4);
            /*DEBUG*/
            strSeed = seed1.ToString() + seed2.ToString() + seed3.ToString() + seed4.ToString();
            sw.WriteLine(strSeed);
            sw.Flush();
            sw.Close();
            SeedDecoder(seed1, seed2, seed3, seed4);
        }
        internal void SeedDecoder(int s1, int s2, int s3, int s4)
        {
            string rmap = CML[s1];
            /*DEBUG*/
            //Print("rmap=" + rmap);
            /*DEBUG*/
            string rgametype = GameTypes[s2];
            /*DEBUG*/
            //Print("rgt=" + rgametype);
            /*DEBUG*/
            chance = s4;
            /*DEBUG*/
            //Print("chance=" + chance);
            /*DEBUG*/
            if (DLCmaps.Contains(rmap) && s3 <= 550)
            {
                s3 += 200;
            }
            this.SeedFull.Add(strSeed);
            SeedFinal(rmap, rgametype, s3);
        }
        internal void SeedFinal(string map, string gametype, int percentage)
        {
            if (passnum <= 6)
            {
                this.LinesDSPL.Add(map + "," + gametype + "," + percentage);
                /*DEBUG*/
                //Print("line=" + LinesDSPL.Count);
                /*DEBUG*/
                ++passnum;
                this.SeedGenerator();
            }
            if (passnum >= 7)
            {
                AfterDelay(250, () =>
                {
                    passnum = 1;
                    SeedWriteDSPL(line);
                });
            }
        }
        internal void SeedWriteDSPL(string[] line)
        {
            string convertedSeed = (Convert.ToInt64(SeedFull[0]) + Convert.ToInt64(SeedFull[1]) + Convert.ToInt64(SeedFull[2]) + Convert.ToInt64(SeedFull[3]) + Convert.ToInt64(SeedFull[4]) + Convert.ToInt64(SeedFull[5]) + Convert.ToInt64(SeedFull[6])).ToString();
            line = LinesDSPL.ToArray();
            File.WriteAllLines("admin\\infected.dspl", line);
            this.SeedSaving(strSeed, convertedSeed, chance);
        }
        internal List<string> GameTypes = new List<string>
        {
            "Cinf1",
            "Cinf2",
            "Cinf3",
            "Cinf4",
            "Cinf5",
            "Cinf6",
            "Cinf7",
            "Cinf8",
            "Cinf9",
            "Cinf10",
            "Cinf11",
            //"Cinf12",
            "Cinf13",
            "Cinf14",
            "Cinf15",
            "Cinf16"
        };

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        internal int game_unit = 64;
        internal int TA_radius = 5;
        internal int KillsLimit = 24;

        internal void CheckPlayerKills(Entity entity)
        {
            OnInterval(10, () =>
            {
                if (entity.Kills > KillsLimit && entity.SessionTeam == "allies")
                {
                    entity.IPrintLnBold("you got >24 kills, move or die.");
                    AntiCampRA rA = new AntiCampRA();
                    TriggerArea(entity, rA.PX, rA.MX, rA.PY, rA.MY, rA.PZ, rA.MZ, rA.A);
                    return false;
                }
                return true;
            });
        }
        internal void TriggerArea(Entity entity, float PX, float MX, float PY, float MY, float PZ, float MZ, int A)
        {
            AfterDelay(1000, () =>
            {
                float X = entity.Origin.X;
                float Y = entity.Origin.Y;
                float Z = entity.Origin.Z;

                PX = X + (game_unit * TA_radius);
                MX = X - (game_unit * TA_radius);

                PY = Y + (game_unit * TA_radius);
                MY = Y - (game_unit * TA_radius);

                PZ = Z + (game_unit * TA_radius);
                MZ = Z - (game_unit * TA_radius);
                /*DEBUG*/
                //Print("trigger areaP=" + PX + " " + PY + " " + PZ);
                //Print("trigger areaM=" + MX + " " + MY + " " + MZ);
                /*DEBUG*/
                AntiCamp(entity, PX, MX, PY, MY, PZ, MZ, A);
            });
        }
        internal void AntiCamp(Entity entity, float PX, float MX, float PY, float MY, float PZ, float MZ, int A)
        {
            OnInterval(5000, () =>
            {
                float X = entity.Origin.X;
                float Y = entity.Origin.Y;
                float Z = entity.Origin.Z;
                if (entity.IsAlive && entity.SessionTeam == "allies" && A == 15)
                {
                    entity.IPrintLnBold("you have ^120 seconds^7 to move or you will be killed.");
                }
                if (entity.IsAlive && entity.SessionTeam == "allies" && A == 35)
                {
                    AfterDelay(10, () =>
                    {
                        Utilities.RawSayAll(TAG + " ^6" + entity.Name + " ^7Camped too much...");
                        entity.IPrintLn("you died. We warned you.");
                        entity.FinishPlayerDamage(entity, entity, 9000, 0, "MOD_UNKNOWN", "none", entity.Origin, entity.Origin, "none", 0);
                        A = 0;
                    });
                }
                if (entity.IsAlive && entity.SessionTeam == "allies")
                {
                    //Idk i just used my own logic to understand how it will recognize where is minus and where is plus in player origin
                    if (((PX) > (X) && (X) > (MX)) && ((PY) > (Y) && (Y) > (MY)) && ((PZ) > (Z) && (Z) > (MZ)))
                    {
                        A += 5;
                        return true;
                    }
                    else
                    {
                        A = 0;
                        PX = X + (game_unit * TA_radius);
                        MX = X - (game_unit * TA_radius);

                        PY = Y + (game_unit * TA_radius);
                        MY = Y - (game_unit * TA_radius);

                        PZ = Z + (game_unit * TA_radius);
                        MZ = Z - (game_unit * TA_radius);
                        return true;
                    }
                }
                if (entity.IsAlive && entity.SessionTeam == "axis")
                {
                    A = 0;
                    return false;
                }
                return true;
            });
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        internal void OnAfkCommand(Entity entity)
        {
            if (AFKs.Contains(entity))
            {
                AfterDelay(250, () =>
                {
                    AfterDelay(250, () =>
                    {
                        AFKs.Remove(entity);
                        Utilities.RawSayTo(entity, "[^:AFK^7] player ^:" + entity.Name + " ^7is no longer afk.");
                    });
                });
            }
            if (!AFKs.Contains(entity))
            {
                AfterDelay(250, () =>
                {
                    CheckAfkSP checkAfk = new CheckAfkSP();
                    AFKs.Add(entity);
                    Utilities.RawSayTo(entity, "[^:AFK^7] player ^:" + entity.Name + " ^7is afk.");
                    CheckAfk(entity, checkAfk.SavedPos);
                });
            }
        }
        internal void CheckAfk(Entity entity, Vector3 SavedPos)
        {
            int FirstI = new int();
            SavedPos = entity.Origin;
            OnInterval(2000, () =>
            {
                if (GSCFunctions.IsAlive(entity) && SavedPos.ToString() == entity.Origin.ToString())
                {
                    return true;
                }
                if (GSCFunctions.IsAlive(entity) && (SavedPos.ToString() != entity.Origin.ToString() && AFKs.Contains(entity)))
                {
                    this.OnAfkCommand(entity);
                    return false;
                }
                if (GSCFunctions.IsAlive(entity) && FirstI == 2)
                {
                    SavedPos = entity.Origin;
                    return true;
                }
                if (!GSCFunctions.IsAlive(entity))
                {
                    entity.SpawnedPlayer += delegate ()
                    {
                        SavedPos = entity.Origin;
                        return;
                    };
                    return true;
                }
                ++FirstI;
                return true;
            });
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        //NOTE: The script bellow was a work for !shop command, but, in the middle of proccess
        //i changed my mind and just discontinued this thing. Now its still just here and some
        //parts are used for !convert command. I think i won't delete this, in case of what...
        
        static List<string> AllWeaponsConsIW5 = new List<string>
        {
            "iw5_riotshieldjugg_mp",
            //Pistols
            "iw5_usp45_mp",
            "iw5_p99_mp",
            "iw5_mp412_mp",
            "iw5_44magnum_mp",
            "iw5_fnfiveseven_mp",
            "iw5_deserteagle_mp",
            //LMG
            "iw5_fmg9_mp",
            "iw5_skorpion_mp",
            "iw5_mp9_mp",
            "iw5_g18_mp",
            //SMG
            "iw5_mp5_mp",
            "iw5_p90_mp",
            "iw5_pp90m1_mp",
            "iw5_ump45_mp",
            "iw5_mp7_mp",
            "iw5_m9_mp",
            //Assault Rifles
            "iw5_ak47_mp",
            "iw5_m16_mp",
            "iw5_m4_mp",
            "iw5_fad_mp",
            "iw5_acr_mp",
            "iw5_type95_mp",
            "iw5_mk14_mp",
            "iw5_scar_mp",
            "iw5_g36c_mp",
            "iw5_cm901_mp",
            //Lauchers
            "iw5_smaw_mp",
            //Sniper rifles
            "iw5_dragunov_mp",
            "iw5_msr_mp",
            "iw5_barrett_mp",
            "iw5_rsass_mp",
            "iw5_as50_mp",
            "iw5_l96a1_mp",
            //Shotguns
            "iw5_ksg_mp",
            "iw5_1887_mp",
            "iw5_striker_mp",
            "iw5_aa12_mp",
            "iw5_usas12_mp",
            "iw5_spas12_mp",
            //MG
            "iw5_m60_mp",
            "iw5_mk46_mp",
            "iw5_pecheneg_mp",
            "iw5_sa80_mp",
            "iw5_mg36_mp"
        };
        static List<string> AllWeaponsConsMP = new List<string>
        {
            //Lauchers
            "gl_mp",
            "m320_mp",
            "rpg_mp",
            "stinger_mp",
            "javelin_mp",
            "xm25_mp",
            //Death Equipements
            "c4_mp",
            "claymore_mp",
            "semtex_mp",
            "frag_grenade_mp",
            "throwingknife_mp",
            "bouncingbetty_mp",
            //Tactical Equipement
            "trophy_mp",
            "scrambler_mp",
            "flash_grenade_mp",
            "smoke_grenade_mp",
            "concussion_grenade_mp",
            "emp_grenade_mp",
            "portable_radar_mp"
        };

        /* ----------------------------------------------------------------- */
        /* --------------------- NOW TO THE MAIN LOGIC --------------------- */
        /* ----------------------------------------------------------------- */

        internal bool isWorking = new bool();
        internal Random random = new Random();

        internal void IsEnabledRandom()
        {
            OnNotify("spawned_player", () =>
            {
                if (Players.Count >= 8)
                {
                    int RN = random.Next(1, 16);
                    if (RN <= 8)
                    {
                        this.isWorking = false;
                    }
                    if (RN >= 9)
                    {
                        this.isWorking = true;
                    }
                }
            });
        }
        static List<string> BlackListedWeaponsCons = new List<string>
        {
            //Lauchers
            "gl_mp",
            "m320_mp",
            "iw5_smaw_mp",
            "stinger_mp",
            "xm25_mp",
            //Tactical Equipement
            "trophy_mp",
            "scrambler_mp",
            "flash_grenade_mp",
            "smoke_grenade_mp",
            "concussion_grenade_mp",
            "emp_grenade_mp",
            "portable_radar_mp"
        };
        internal void AddWeap(Entity player, string toBuy)
        {
            string ThisBuy = FindWeapByname(toBuy);
            if (ThisBuy == null)
            {
                Utilities.RawSayTo(player, "^6Failed^7 to found or ^6multiple^7 were found...");
            }
            else
            {
                string FinalReq = ConvertToConsName(ThisBuy);
                if (FinalReq == "null")
                {
                    Utilities.RawSayTo(player, "^6Failed^7 to convert...");
                }
                else
                {
                    foreach (string str in Pistols)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 250$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in SMG)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 2000$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in AssaultRifles)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 3000$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in LMG)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 1500$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in MG)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 7000$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in SniperRifles)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 2000$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in ShotGuns)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 5000$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in Launchers)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 2500$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    foreach (string str in Misc)
                    {
                        if (str.Contains(FinalReq))
                        {
                            //Remove 2500$, take current weapon and give the buy one.
                            string CurrWeap = player.CurrentWeapon;
                            //player.TakeWeapon(CurrWeap);
                            player.GiveWeapon(FinalReq);
                        }
                    }
                    Utilities.RawSayTo(player, TAG + " You are given ^6" + FinalReq);
                }
            }
        }
        internal string FindWeapByname(string weapon)
        {
            int num = 0;
            string str1 = (string)null;
            foreach (string str2 in AllWeaponsMiCons)
            {
                if (0 <= str2.IndexOf(weapon, StringComparison.InvariantCultureIgnoreCase))
                {
                    str1 = str2;
                    ++num;
                }
            }
            if (num <= 1 && num == 1)
                return str1;
            else
                return (string)null;
        }
        internal string ConvertToConsName(string weapon)
        {
            int num = 0;
            string iw5 = "iw5_";
            string mp = "_mp";
            string str1 = null;
            if (weapon == "pm9")
            {
                weapon = "m9";
            }
            if (weapon == "riotshield")
            {
                weapon = "riotshieldjugg";
            }
            if (weapon == "m4a1")
            {
                weapon = "m4";
            }
            if (weapon == "m1887")
            {
                weapon = "1887";
            }
            if (weapon == "l86lsw")
            {
                weapon = "sa80";
            }

            foreach (string str2 in AllWeaponsConsIW5)
            {
                if (str2.Contains(weapon))
                {
                    str1 = (iw5 + weapon + mp);
                    ++num;
                }
            }
            foreach (string str2 in AllWeaponsConsMP)
            {
                if (str2.Contains(weapon))
                {
                    str1 = (weapon + mp);
                    ++num;
                }
            }
            if (num <= 1 && num == 1)
                return str1;
            else { return (string)null; }
        }
        static List<string> Pistols = new List<string>
        {
            "iw5_usp45_mp",
            "iw5_p99_mp",
            "iw5_mp412_mp",
            "iw5_44magnum_mp",
            "iw5_fnfiveseven_mp",
            "iw5_deserteagle_mp"
        };
        static List<string> LMG = new List<string>
        {
            "iw5_fmg9_mp",
            "iw5_skorpion_mp",
            "iw5_mp9_mp",
            "iw5_g18_mp"
        };
        static List<string> SMG = new List<string>
        {
            "iw5_mp5_mp",
            "iw5_p90_mp",
            "iw5_pp90m1_mp",
            "iw5_ump45_mp",
            "iw5_mp7_mp",
            "iw5_m9_mp"
        };
        static List<string> AssaultRifles = new List<string>
        {
            "iw5_ak47_mp",
            "iw5_m16_mp",
            "iw5_m4_mp",
            "iw5_fad_mp",
            "iw5_acr_mp",
            "iw5_type95_mp",
            "iw5_mk14_mp",
            "iw5_scar_mp",
            "iw5_g36c_mp",
            "iw5_cm901_mp"
        };
        static List<string> Launchers = new List<string>
        {
            "iw5_smaw_mp",
            "gl_mp",
            "m320_mp",
            "rpg_mp",
            "stinger_mp",
            "javelin_mp",
            "stinger_mp",
            "xm25_mp"
        };
        static List<string> SniperRifles = new List<string>
        {
            "iw5_dragunov_mp",
            "iw5_msr_mp",
            "iw5_barrett_mp",
            "iw5_rsass_mp",
            "iw5_as50_mp",
            "iw5_l96a1_mp"
        };
        static List<string> ShotGuns = new List<string>
        {
            "iw5_ksg_mp",
            "iw5_1887_mp",
            "iw5_striker_mp",
            "iw5_aa12_mp",
            "iw5_usas12_mp",
            "iw5_spas12_mp"
        };
        static List<string> MG = new List<string>
        {
            "iw5_m60_mp",
            "iw5_mk46_mp",
            "iw5_pecheneg_mp",
            "iw5_sa80_mp",
            "iw5_mg36_mp"
        };
        static List<string> DE = new List<string>
        {
            "c4_mp",
            "claymore_mp",
            "semtex_mp",
            "frag_grenade_mp",
            "throwingknife_mp",
            "bouncingbetty_mp"
        };
        static List<string> TE = new List<string>
        {
            "trophy_mp",
            "scrambler_mp",
            "flash_grenade_mp",
            "smoke_grenade_mp",
            "concussion_grenade_mp",
            "emp_grenade_mp",
            "portable_radar_mp"
        };
        static List<string> Misc = new List<string>
        {
            "iw5_riotshieldjugg_mp"
        };
        static List<string> AllWeaponsMiCons = new List<string>
        {
            "riotshield",
            //Pistols
            "usp45",
            "p99",
            "mp412",
            "44magnum",
            "fnfiveseven",
            "deserteagle",
            //LMG
            "fmg9",
            "skorpion",
            "mp9",
            "g18",
            //SMG
            "mp5",
            "p90",
            "pp90m1",
            "ump45",
            "mp7",
            "pm9",              //-m9
            //Assault Rifles
            "ak47",
            "m16",
            "m4a1",             //-m4
            "fad",
            "acr",
            "type95",
            "mk14",
            "scar",
            "g36c",
            "cm901",
            //Lauchers
            "gl",
            "m320",
            "rpg",
            "smaw",
            "stinger",
            "javelin",
            "xm25",
            //Sniper rifles
            "dragunov",
            "msr",
            "barrett",
            "rsass",
            "as50",
            "l96a1",
            //Shotguns
            "ksg",
            "m1887",            //-1887
            "striker",
            "aa12",
            "usas12",
            "spas12",
            //MG
            "m60",
            "mk46",
            "pecheneg",
            "l86lsw",           //-sa80
            "mg36",
            //Death Equipements
            "c4",
            "claymore",
            "semtex",
            "frag_grenade",
            "throwingknife",
            "bouncingbetty",
            //Tactical Equipement
            "trophy",
            "scrambler",
            "flash_grenade",
            "smoke_grenade",
            "concussion_grenade",
            "emp_grenade",
            "portable_radar"
        };
    }
}
