using System.Collections.Generic;
using System.IO;
using InfinityScript;

namespace InfectedServerSsa
{
    public class AntiRQ : BaseScript
    {
        public int time = 25;
        internal string TAG = "";
        public AntiRQ()
        {
            foreach (string str in File.ReadAllLines("scripts\\GPIv3\\GPIconfig.txt"))
            {
                if (str.StartsWith("server_tag"))
                {
                    TAG = str.Split(new char[1] { '=' })[1];
                }
            }
            //Thx to MRX450 again for helping in that
            PlayerConnected += delegate (Entity player)
            {
                if (File.Exists("scripts\\GPIv3\\tempBans\\" + player.Name + ".txt"))
                {
                    File.Delete("scripts\\GPIv3\\tempBans\\" + player.Name + ".txt");
                    AfterDelay(250, () =>
                    {
                        Utilities.ExecuteCommand("tempbanclient " + player.GetEntityNumber() + " Rage-quit previously.");
                    });
                }
                OnInterval(100, delegate
                {
                    if (player.SessionTeam == "axis" && Players.Count >= 5)
                    {
                        player.CloseInGameMenu();
                    }
                    return true;
                });
                player.SpawnedPlayer += delegate ()
                {
                    if (Players.Count >= 5)
                    {
                        HudElem infected = HudElem.CreateFontString(player, HudElem.Fonts.Objective, 1.2f);
                        infected.SetPoint("CENTER", "CENTER", 0, -110);
                        infected.SetText("^7" + TAG + " ^6Infected ^7cannot ^6leave ^7the ^6server.");
                        infected.GlowAlpha = 1f;
                        infected.SetPulseFX(100, 7000, 600);
                        infected.HideWhenInMenu = true;
                    }
                };
            };
            PlayerDisconnected += delegate (Entity player)
            {
                this.Disconnected(player);
            };
        }
        internal void Disconnected(Entity entity)
        {
            if (entity.SessionTeam == "axis" && Players.Count >= 5)
            {
                File.Create("scripts\\GPIv3\\tempBans\\" + entity.Name + ".txt");
            }
        }
    }
}
