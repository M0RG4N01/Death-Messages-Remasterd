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

namespace Remastered.DeathMessages
{
    public class PlayerDeath : RocketPlugin<DMC2>
    {
        public static PlayerDeath Instance;
        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("##########################################");
            Rocket.Core.Logging.Logger.Log("Death Messages Remastered has been loaded!");
            #region Event
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            Rocket.Unturned.Events.UnturnedPlayerEvents.OnPlayerUpdateHealth += UnturnedPlayerEvents_OnPlayerUpdateHealth;

            #endregion
            Rocket.Core.Logging.Logger.LogError("PLEASE NOTE:");
            Rocket.Core.Logging.Logger.LogError("Don't forget to set the permission 'deathmessage' in one of the groups.");
            Rocket.Core.Logging.Logger.Log("##########################################");

            
        }

        private void UnturnedPlayerEvents_OnPlayerDeath(Rocket.Unturned.Player.UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            if (player.HasPermission("deathmessage"))
            {
                if (cause.ToString() == "ZOMBIE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.zombie + " ", Color.red);
                }
                else if (cause.ToString() == "GUN")
                {
                    if (limb == ELimb.SKULL)
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.headshotgun + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + "!", Color.red);
                    else
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.gun + " " + player.CharacterName + "!", Color.red);
                }
                else if (cause.ToString() == "MELEE")
                {
                    if (limb == ELimb.SKULL)
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.headchop + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + "!", Color.red);
                    else
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.melee + " " + player.CharacterName + " " + this.Configuration.Instance.melee2, Color.red);
                }
                else if (cause.ToString() == "PUNCH")
                {
                    if (limb == ELimb.SKULL)
                        UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.headpunch + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + "!", Color.red);
                    else
                        UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.punch + " " + player.CharacterName + " " + this.Configuration.Instance.punch2, Color.red);
                }
                else if (cause.ToString() == "SHRED")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.shred, Color.red);
                }
                else if (cause.ToString() == "ROADKILL")
                {
                    UnturnedChat.Say(Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + " " + this.Configuration.Instance.roadkill + " " + player.CharacterName + "!", Color.red);
                }
                else if (cause.ToString() == "SPARK")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.spark, Color.red);
                }
                else if (cause.ToString() == "VEHICLE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.vehicle, Color.red);
                }
                else if (cause.ToString() == "FOOD")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.food, Color.red);
                }
                else if (cause.ToString() == "WATER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.water, Color.red);
                }
                else if (cause.ToString() == "INFECTION")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.infection, Color.red);
                }
                else if (cause.ToString() == "BLEEDING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.bleeding, Color.red);
                }
                else if (cause.ToString() == "LANDMINE") 
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.landmine, Color.red);
                }
                else if (cause.ToString() == "BREATH") 
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.breath, Color.red);
                }
                else if (cause.ToString() == "GRENADE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.grenade, Color.red);
                }
                else if (cause.ToString() == "FREEZING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.freezing, Color.red);
                }
                else if (cause.ToString() == "SENTRY")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.sentry, Color.red);
                }
                else if (cause.ToString() == "CHARGE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.charge, Color.red);
                }
                else if (cause.ToString() == "MISSILE")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.missile, Color.red);
                }
                else if (cause.ToString() == "BONES")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.bones, Color.red);
                }
                else if (cause.ToString() == "SPLASH")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.splash, Color.red);
                }
                else if (cause.ToString() == "ACID")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.acid, Color.red);
                }
                else if (cause.ToString() == "SPIT")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.spit, Color.red);
                }
                else if (cause.ToString() == "BURNING")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.fire, Color.red);
                }
                else if (cause.ToString() == "BURNER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.fire, Color.red);
                }
                else if (cause.ToString() == "BOULDER")
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.boulder, Color.red);
                }

                else if (cause.ToString() == "SUICIDE" && this.Configuration.Instance.suicidemsg)
                {
                    UnturnedChat.Say(player.CharacterName + " " + this.Configuration.Instance.suicide, Color.red);
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
    }

}
