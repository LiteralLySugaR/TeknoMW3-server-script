using InfinityScript;

namespace InfectedServerSsa
{
    public class UserHud : BaseScript
    {
        public UserHud()
        {
            //Thx MRX450
            base.PlayerConnected += delegate (Entity player)
            {
                HudElem hudElem = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 0.7f);
                hudElem.SetPoint("BOTTOM", "BOTTOM", 0, -5);
                hudElem.SetText("");
                hudElem.HideWhenInMenu = true;
                hudElem.GlowAlpha = 0f;
                HudElem Name = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 0.7f);
                HudElem Slot = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 0.7f);
                Name.SetPoint("BOTTOM", "BOTTOM", 0, -5);
                Name.SetText("^1| ^6NAME ^1| ^7 " + player.Name + " ^1| ^6SLOT ^1| ^7 " + player.EntRef.ToString());
                Name.HideWhenInMenu = true;
                Slot.HideWhenInMenu = true;

                HudElem Discord = HudElem.CreateFontString(player, HudElem.Fonts.HudSmall, 0.7f);
                Discord.SetPoint("LEFT", "LEFT", 6, -130);
                Discord.SetText("^6discord.gg^7/^6KMSx2kN7Xu");
                Discord.HideWhenInMenu = true;
            };
        }
    }
}
