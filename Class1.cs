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
using Steamworks;
using SDG.Unturned;
using Rocket.API.Serialisation;
using Rocket.Unturned.Player;
using fr34kyn01535.Uconomy;
using Rocket.API.Collections;

namespace Remastered.DeathMessages
{
    public class PlayerDeath : RocketPlugin<DMC2>
    {
        public static PlayerDeath Instance;
        public static UnturnedPlayer murderer3;

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {

                };
            }
        }

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("Death Messages Remastered has been loaded!");
            #region Event
            UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerUpdateHealth += UnturnedPlayerEvents_OnPlayerUpdateHealth;

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
            if (Configuration.Instance.ExperienceEnabled)
            {
                Rocket.Core.Logging.Logger.LogWarning("Experience is enabled!");
            }
            else
            {
                Rocket.Core.Logging.Logger.LogError("Experience is disabled!");
            }
            if (Configuration.Instance.ZombieMessagesEnabled)
            {
                Rocket.Core.Logging.Logger.LogWarning("Zombie Death Messages are enabled!");
            }
            else
            {
                Rocket.Core.Logging.Logger.LogError("Zombie Death Messages are disabled!");
            }
            Rocket.Core.Logging.Logger.LogWarning("--");

        }

        private void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            murderer3 = UnturnedPlayer.FromCSteamID(murderer);
            string Part = "???";

            if (Configuration.Instance.ZombieMessagesEnabled && cause.ToString() == "ZOMBIE")
            {
                UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.zombie + " ", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
            }
            else if (Configuration.Instance.ShowDistance = true && cause.ToString() == "GUN")
            {
                if (limb == ELimb.SKULL)
                {
                    UnturnedChat.Say(player.CharacterName + ", " + Configuration.Instance.headshotgun + ", " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "[\u2719" + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "]" + ", " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Head + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a Headshot!", Color.green);
                    }
                }
                else if (limb == ELimb.SPINE)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "[\u2719" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "]" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Body + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a body shot!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_ARM || limb == ELimb.LEFT_ARM || limb == ELimb.LEFT_HAND || limb == ELimb.RIGHT_HAND)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Arm + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting an arm shot!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_LEG || limb == ELimb.LEFT_LEG || limb == ELimb.LEFT_FOOT || limb == ELimb.RIGHT_FOOT)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Leg + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a leg shot!", Color.green);
                    }
                }
                else
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
            }
            else if (cause.ToString() == "GUN")
            {
                if (limb == ELimb.SKULL)
                {
                    UnturnedChat.Say(player.CharacterName + ", " + Configuration.Instance.headshotgun + ", " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Head + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a Headshot!", Color.green);
                    }
                }
                else if (limb == ELimb.SPINE)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Body + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a body shot!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_ARM || limb == ELimb.LEFT_ARM || limb == ELimb.LEFT_HAND || limb == ELimb.RIGHT_HAND)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Arm + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting an arm shot!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_LEG || limb == ELimb.LEFT_LEG || limb == ELimb.LEFT_FOOT || limb == ELimb.RIGHT_FOOT)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Leg + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a leg shot!", Color.green);
                    }
                }
                else
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.gun + ", " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " from " + Math.Round((double)Vector3.Distance(player.Position, murderer3.Position)).ToString() + "m!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
            }
            else if (cause.ToString() == "MELEE")
            {
                if (limb == ELimb.SKULL)
                {
                    UnturnedChat.Say(player.CharacterName + ", " + Configuration.Instance.headchop + ", " + UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString() + " " + "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Head + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a head chop!", Color.yellow);
                    }
                }
                else if (limb == ELimb.SPINE)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.melee + ", " + player.CharacterName + ", " + Configuration.Instance.melee2 + " " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString(), UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Body + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a body kill!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_ARM || limb == ELimb.LEFT_ARM || limb == ELimb.LEFT_HAND || limb == ELimb.RIGHT_HAND)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.melee + ", " + player.CharacterName + ", " + Configuration.Instance.melee2 + " " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString(), UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Arm + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting an arm kill!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_LEG || limb == ELimb.LEFT_LEG || limb == ELimb.LEFT_FOOT || limb == ELimb.RIGHT_FOOT)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.melee + ", " + player.CharacterName + ", " + Configuration.Instance.melee2 + " " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString(), UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Leg + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a leg kill!", Color.green);
                    }
                }
                else
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.melee + ", " + player.CharacterName + ", " + Configuration.Instance.melee2 + " " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).Player.equipment.asset.itemName.ToString(), UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
            }
            else if (cause.ToString() == "PUNCH")
            {
                if (limb == ELimb.SKULL)
                {
                    UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.headpunch + ", " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Head + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a head punch kill!", Color.green);
                    }
                }
                else if (limb == ELimb.SPINE)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.punch + " " + player.CharacterName + ", " + Configuration.Instance.punch2, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Body + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a body punch kill!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_ARM || limb == ELimb.LEFT_ARM || limb == ELimb.LEFT_HAND || limb == ELimb.RIGHT_HAND)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.punch + " " + player.CharacterName + ", " + Configuration.Instance.punch2, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Arm + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting an arm punch kill!", Color.green);
                    }
                }
                else if (limb == ELimb.RIGHT_LEG || limb == ELimb.LEFT_LEG || limb == ELimb.LEFT_FOOT || limb == ELimb.RIGHT_FOOT)
                {
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.punch + " " + player.CharacterName + ", " + Configuration.Instance.punch2, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                    if (Configuration.Instance.UconomyEnabled)
                    {
                        UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Leg + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for getting a leg punch kill!", Color.green);
                    }
                }
                else
                    UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.punch + " " + player.CharacterName + ", " + Configuration.Instance.punch2, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
            }
            else if (cause.ToString() == "SHRED")
            {
                UnturnedChat.Say(player.CharacterName + " " + Configuration.Instance.shred, UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));

            }
            else if (cause.ToString() == "ROADKILL")
            {
                UnturnedChat.Say(UnturnedPlayer.FromCSteamID(murderer).CharacterName + ", " + "HP:" + " " + UnturnedPlayer.FromCSteamID(murderer).Health.ToString() + "%" + ", " + Configuration.Instance.roadkill + " " + player.CharacterName + ", " + Configuration.Instance.usinga + " " + Rocket.Unturned.Player.UnturnedPlayer.FromCSteamID(murderer).CurrentVehicle.asset.vehicleName.ToString() + "!", UnturnedChat.GetColorFromName(Configuration.Instance.messagecolour, Color.red));
                if (Configuration.Instance.UconomyEnabled)
                {
                    UnturnedChat.Say(murderer, "You recieved" + " " + Configuration.Instance.Roadkill + " " + Uconomy.Instance.Configuration.Instance.MoneyName + " " + "for roadkill!", Color.green);
                }
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

            bool suicided = cause.ToString() == "SUICIDE";

            if (limb == ELimb.SKULL && !suicided)
            {
                Part = ("head");
            }
            else if (limb == ELimb.SPINE)
            {
                Part = ("body");
            }
            else if (limb == ELimb.LEFT_ARM || limb == ELimb.RIGHT_ARM || limb == ELimb.LEFT_HAND || limb == ELimb.RIGHT_HAND)
            {
                Part = ("arm");
            }
            else if (limb == ELimb.LEFT_LEG || limb == ELimb.RIGHT_LEG || limb == ELimb.LEFT_FOOT || limb == ELimb.RIGHT_FOOT)
            {
                Part = ("leg");
            }
            if (Configuration.Instance.UconomyEnabled)
            {
                try
                {
                    {
                        {
                            int value = 0;
                            if (Part == "head")
                            {
                                value = Configuration.Instance.Head;
                            }
                            else if (Part == "body")
                            {
                                value = Configuration.Instance.Body;
                            }
                            else if (Part == "arm")
                            {
                                value = Configuration.Instance.Arm;
                            }
                            else if (Part == "leg")
                            {
                                value = Configuration.Instance.Leg;
                            }
                            else if (cause.ToString() == "ROADKILL")
                            {
                                value = Configuration.Instance.Roadkill;
                            }
                            else
                            {
                                Rocket.Core.Logging.Logger.LogWarning("");
                            }
                            Uconomy.Instance.Database.IncreaseBalance(murderer3.CSteamID.ToString(), value);
                        };
                    }
                }
                catch (Exception e)
                {
                    Rocket.Core.Logging.Logger.LogError(e.Message);
                }

            }

            if (Configuration.Instance.ExperienceEnabled)
            {
                try
                {
                    uint num1 = 0u;
                    if (Part == "head")
                    {
                        num1 = Configuration.Instance.ExpHead;
                    }
                    else if (Part == "body")
                    {
                        num1 = Configuration.Instance.ExpBody;
                    }
                    else if (Part == "arm")
                    {
                        num1 = Configuration.Instance.ExpArm;
                    }
                    else if (Part == "leg")
                    {
                        num1 = Configuration.Instance.ExpLeg;
                    }
                    else
                    {
                        num1 = 0;
                    }
                    UnturnedPlayer exp = murderer3;
                    exp.Experience = +num1;
                }
                catch (Exception e)
                {
                    Rocket.Core.Logging.Logger.LogError(e.Message);
                }
            }
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerUpdateHealth -= UnturnedPlayerEvents_OnPlayerUpdateHealth;
        }

        public void UnturnedPlayerEvents_OnPlayerUpdateHealth(UnturnedPlayer player, byte health)
        {
            if (this.Configuration.Instance.healthwarningmsg)
            {
                if (health == 25)
                {
                    UnturnedChat.Say(player, Configuration.Instance.warning1, Color.yellow);
                    UnturnedChat.Say(player, Configuration.Instance.warning2, Color.yellow);
                }
            }
        }
    }
}

