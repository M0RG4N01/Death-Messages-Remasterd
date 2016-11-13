using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned;
using Rocket.Core;
using UnityEngine;
using Rocket.Unturned.Plugins;
using SDG;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using DeathMessages;
using Steamworks;
using SDG.Unturned;
using Rocket.API.Serialisation;
using Rocket.Unturned.Player;

namespace Remastered.DeathMessages
{
    public class PlayerDeath : RocketPlugin<DMC2>
    {
        public static PlayerDeath Instance;
        public static UnturnedPlayer murderer3;
        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("Death Messages Remastered has been loaded!");
            #region Event
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerUpdateHealth += UnturnedPlayerEvents_OnPlayerUpdateHealth;

            #endregion
            Rocket.Core.Logging.Logger.LogWarning("--");
            if (Configuration.Instance.suicidemsg)
            {
                Rocket.Core.Logging.Logger.LogWarning("Suicide messages are enabled!");
            }
            else
            {
                Rocket.Core.Logging.Logger.LogError("Suicide messages are disabled!");
            }
            if (Configuration.Instance.healthwarningmsg)
            {
                Rocket.Core.Logging.Logger.LogWarning("Health warning messages are enabled!");
            }
            else
            {
                Rocket.Core.Logging.Logger.LogError("Health warning messages are disabled!");
            }
            Rocket.Core.Logging.Logger.LogWarning("--");

        }


        private void UnturnedPlayerEvents_OnPlayerDeath(Rocket.Unturned.Player.UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)

        {
            murderer3 = UnturnedPlayer.FromCSteamID(murderer);
            int num = Provider.clients.Count;
            if (Instance.Configuration.Instance.Groups !=null && Instance.Configuration.Instance.Groups.Count > 0)
                {
                foreach (SteamPlayer current in Provider.clients)
                {
                    if (CheckDeathMessage(current.playerID.steamID))
                    {
                        num--;
                    }
                }
            }
            {
                if (cause.ToString() == "ZOMBIE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.zombie + " ", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "GUN")
                {
                    if (limb == ELimb.SKULL)
                        UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.headshotgun + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() +  "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    else
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + Configuration.Instance.gun + " " + player.CharacterName + " " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "MELEE")
                {
                    if (limb == ELimb.SKULL)
                        UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.headchop + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " +  "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    else
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + Configuration.Instance.melee + " " + player.CharacterName + " " + Configuration.Instance.melee2, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "PUNCH")
                {
                    if (limb == ELimb.SKULL)
                        UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.headpunch + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    else
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + Configuration.Instance.punch + " " + player.CharacterName + " " + Configuration.Instance.punch2, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "SHRED")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.shred, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "ROADKILL")
                {
                    UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + Configuration.Instance.roadkill + " " + player.CharacterName + "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "SPARK")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.spark, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "VEHICLE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.vehicle, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "FOOD")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.food, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "WATER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.water, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "INFECTION")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.infection, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "BLEEDING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.bleeding, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "LANDMINE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.landmine, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "BREATH")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.breath, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "GRENADE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.grenade, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "FREEZING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.freezing, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "SENTRY")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.sentry, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "CHARGE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.charge, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "MISSILE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.missile, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "BONES")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.bones, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "SPLASH")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.splash, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "ACID")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.acid, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "SPIT")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.spit, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "BURNING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.fire, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "BURNER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.fire, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }
                else if (cause.ToString() == "BOULDER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.boulder, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }

                else if (cause.ToString() == "SUICIDE" && Configuration.Instance.suicidemsg)
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.suicide, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                }

            }
        }
        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerUpdateHealth -= UnturnedPlayerEvents_OnPlayerUpdateHealth;
        }

        public void UnturnedPlayerEvents_OnPlayerUpdateHealth(Rocket.Unturned.Player.UnturnedPlayer player, byte health)
        {
            if (this.Configuration.Instance.healthwarningmsg)
            {
                if (health == 25)
                {
                    UnturnedChat.Say(player, this.Configuration.Instance.warning1, Color.yellow);
                    UnturnedChat.Say(player, this.Configuration.Instance.warning2, Color.yellow);
                }
            }
        }
        private bool CheckDeathMessage(CSteamID CSteamID)
        {
            if (SteamAdminlist.checkAdmin(CSteamID))
            {
                return true;
            }
            foreach (RocketPermissionsGroup current in R.Permissions.GetGroups(new RocketPlayer(CSteamID.ToString(), null, false), true))
            {
                if (Instance.Configuration.Instance.Groups.Contains(current.Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
