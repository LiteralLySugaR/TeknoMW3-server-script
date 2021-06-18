using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace InfectedServerSsa
{
    public class Shop : BaseScript
    {
        public Shop()
        {
            this.IsEnabledRandom();
        }
        static List<string> AllWeaponsCons = new List<string>
        {
            "riotshield_mp",
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
            "gl_mp",
            "m320_mp",
            "rpg_mp",
            "iw5_smaw_mp",
            "stinger_mp",
            "javelin_mp",
            "xm25_mp",
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
            "iw5_mg36_mp",
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
            "m9",
            //Assault Rifles
            "ak47",
            "m16",
            "m4",
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
            "1887",
            "striker",
            "aa12",
            "usas12",
            "spas12",
            //MG
            "m60",
            "mk46",
            "pecheneg",
            "sa80",
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
        internal void MainShop()
        {

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

            foreach (string str2 in AllWeaponsCons)
            {
                if (str2.Contains(weapon))
                {
                    string this1 = str2.IndexOf(iw5).ToString();
                    string this2 = str2.LastIndexOf(mp).ToString() /*+ weapon*/;
                    //Check if both "iw5_" "_mp" are in line
                    if (this1 == iw5 && this2 == mp)
                    {
                        str1 = (iw5 + weapon + mp);
                        ++num;
                    }
                    //Check if only "_mp" exists
                    if (this2 == mp)
                    {
                        str1 = (weapon + mp);
                        ++num;
                    }
                }
            }
            if (num <= 1 && num == 1)
                return str1;
            else { return (string)null; }
        }
    }
}
