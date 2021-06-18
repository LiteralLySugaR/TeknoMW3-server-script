using System.Collections.Generic;
using System.IO;
using InfinityScript;

namespace InfectedServerSsa
{
    internal class MBS : BaseScript
    {
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
        internal List<Entity> KGBs = new List<Entity>();
        internal List<Entity> MI6s = new List<Entity>();
        internal List<Entity> CIAs = new List<Entity>();

        internal string TAG = "";
        internal void OnConnectLogic(Entity player)
        {
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("server_tag"))
                {
                    TAG = str.Split(new char[1] { '=' })[1];
                }
            }
            if (File.Exists("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb"))
            {
                this.KGBs.Add(player);
            }
            if (File.Exists("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6"))
            {
                this.MI6s.Add(player);
            }
            if (File.Exists("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia"))
            {
                this.CIAs.Add(player);
            }
            this.WeaponLogic(player);
        }
        internal void WeaponLogic(Entity player)
        {
            AfterDelay(500, () =>
            {
                if (player.SessionTeam != "axis")
                {
                    if (KGBs.Contains(player))
                    {
                        string CurrWeap = player.GetCurrentWeapon();
                        string Final = Converter(CurrWeap);
                        if (LMG.Contains(Final) && Final != "iw5_skorpion_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_skorpion_mp_xmags");
                            player.SwitchToWeapon("iw5_skorpion_mp_xmags");
                        }
                        if (SMG.Contains(Final) && Final != "iw5_pp90m1_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_pp90m1_mp_reflexsmg_xmags");
                            player.SwitchToWeapon("iw5_pp90m1_mp_reflexsmg_xmags");
                        }
                        if (AssaultRifles.Contains(Final) && Final != "iw5_ak47_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_ak47_mp_gp25_xmags");
                            player.SwitchToWeapon("iw5_ak47_mp_gp25_xmags");
                        }
                        if (SniperRifles.Contains(Final) && Final != "iw5_dragunov_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_dragunov_mp_acog_xmags");
                            player.SwitchToWeapon("iw5_dragunov_mp_acog_xmags");
                        }
                        if (ShotGuns.Contains(Final) && Final != "iw5_usas12_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_usas12_mp_reflex_xmags");
                            player.SwitchToWeapon("iw5_usas12_mp_reflex_xmags");
                        }
                        if (MG.Contains(Final) && Final != "iw5_pecheneg_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_pecheneg_mp_grip_acog");
                            player.SwitchToWeapon("iw5_pecheneg_mp_grip_acog");
                        }
                        Utilities.RawSayTo(player, "[^1KGB^7] We gave our weapon, Comrade!");
                    }
                    if (MI6s.Contains(player))
                    {
                        string CurrWeap = player.GetCurrentWeapon();
                        string Final = Converter(CurrWeap);
                        if (LMG.Contains(Final) && Final != "iw5_fmg9_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_fmg9_mp_akimbo");
                            player.SwitchToWeapon("iw5_fmg9_mp_akimbo");
                        }
                        if (SMG.Contains(Final) && Final != "iw5_ump45_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_ump45_mp_acogsmg_xmags");
                            player.SwitchToWeapon("iw5_ump45_mp_acogsmg_xmags");
                        }
                        if (AssaultRifles.Contains(Final) && Final != "iw5_cm901_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_cm901_mp_reflex_xmags");
                            player.SwitchToWeapon("iw5_cm901_mp_reflex_xmags");
                        }
                        if (SniperRifles.Contains(Final) && Final != "iw5_l96a1_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_as50_mp_acog_xmags");
                            player.SwitchToWeapon("iw5_as50_mp_acog_xmags");
                        }
                        if (ShotGuns.Contains(Final) && Final != "iw5_striker_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_striker_mp_grip_xmags");
                            player.SwitchToWeapon("iw5_striker_mp_grip_xmags");
                        }
                        if (MG.Contains(Final) && Final != "iw5_sa80_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_sa80_mp_grip_reflexlmg");
                            player.SwitchToWeapon("iw5_sa80_mp_grip_reflexlmg");
                        }
                        Utilities.RawSayTo(player, "[^5MI6^7] You are given your weapon.");
                    }
                    if (CIAs.Contains(player))
                    {
                        string CurrWeap = player.GetCurrentWeapon();
                        string Final = Converter(CurrWeap);
                        if (LMG.Contains(Final) && Final != "iw5_mp9_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_mp9_mp_xmags");
                            player.SwitchToWeapon("iw5_mp9_mp_xmags");
                        }
                        if (SMG.Contains(Final) && Final != "iw5_p90_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_p90_mp_reflexsmg_xmags");
                            player.SwitchToWeapon("iw5_p90_mp_reflexsmg_xmags");
                        }
                        if (AssaultRifles.Contains(Final) && Final != "iw5_m4_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_m4_mp_acog_xmags");
                            player.SwitchToWeapon("iw5_m4_mp_acog_xmags");
                        }
                        if (SniperRifles.Contains(Final) && Final != "iw5_msr_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_msr_mp_acog_xmags");
                            player.SwitchToWeapon("iw5_msr_mp_acog_xmags");
                        }
                        if (ShotGuns.Contains(Final) && Final != "iw5_ksg_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_ksg_mp_grip_xmags");
                            player.SwitchToWeapon("iw5_ksg_mp_grip_xmags");
                        }
                        if (MG.Contains(Final) && Final != "iw5_m60_mp")
                        {
                            player.TakeWeapon(CurrWeap);
                            player.GiveWeapon("iw5_m60_mp_grip_reflexlmg");
                            player.SwitchToWeapon("iw5_m60_mp_grip_reflexlmg");
                        }
                        Utilities.RawSayTo(player, "[^4CIA^7] You are given your weapon.");
                    }
                }
            });
        }
        internal void AddToFolder(Entity player, string group)
        {
            if (group == "none")
            {
                File.Delete("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6");
                File.Delete("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia");
                File.Delete("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb");
            }
            if (group == "kgb" || (group == "kgb" && (MI6s.Contains(player) || CIAs.Contains(player))))
            {
                if (File.Exists("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb"))
                {
                    Utilities.RawSayTo(player, "[^1KGB^7] You are already in KGB, Comrade.");
                }
                if (!File.Exists("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb"))
                {
                    File.Delete("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia");
                    File.Delete("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6");
                    File.Create("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb");
                    Utilities.RawSayTo(player, "[^1KGB^7] You are now KGB, Comrade.");
                }
            }
            if (group == "mi6" || (group == "mi6" && (KGBs.Contains(player) || CIAs.Contains(player))))
            {
                if (File.Exists("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6"))
                {
                    Utilities.RawSayTo(player, "[^5MI6^7] You are already in MI6.");
                }
                if (!File.Exists("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6"))
                {
                    File.Delete("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia");
                    File.Delete("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb");
                    File.Create("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6");
                    Utilities.RawSayTo(player, "[^5MI6^7] You are now MI6.");
                }
            }
            if (group == "cia" || (group == "cia" && (MI6s.Contains(player) || KGBs.Contains(player))))
            {
                if (File.Exists("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia"))
                {
                    Utilities.RawSayTo(player, "[^4CIA^7] You are already in CIA.");
                }
                if (!File.Exists("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia"))
                {
                    File.Delete("scripts\\GPIv3\\MBS\\MI6\\" + player.Name + ".mi6");
                    File.Delete("scripts\\GPIv3\\MBS\\KGB\\" + player.Name + ".kgb");
                    File.Create("scripts\\GPIv3\\MBS\\CIA\\" + player.Name + ".cia");
                    Utilities.RawSayTo(player, "[^4CIA^7] You are now CIA.");
                }
            }
            if (group != "kgb" && group != "mi6" && group != "cia" && group != "none")
            {
                Utilities.RawSayTo(player, TAG + " that group does'nt exists!");
            }
        }
        internal string Converter(string weapon)
        {
            int num = 0;
            string iw5 = "iw5";
            string[] str1 = weapon.Split('_');
            string mp = "mp";
            string full = null;
            if (str1[2].Equals(mp))
            {
                full = (iw5 + "_" + str1[1] + "_" + mp);
                ++num;
            }
            if (num <= 1 && num == 1)
                return full;
            else { return (string)null; }
        }
    }
}
