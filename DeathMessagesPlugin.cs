using System;
using fr34kyn01535.Uconomy;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Remastered.DeathMessages
{
    public class DeathMessagesPlugin : RocketPlugin<DeathMessagesConfiguration>
    {
        public static DeathMessagesPlugin Instance;

        public override TranslationList DefaultTranslations => new TranslationList
        {
            {"WARNING_LOW_HEALTH", "WARNING: You are about to die!"},
            {"WARNING_LOW_HEALTH2", "We recommend you to patch yourself up!"},

            /* 0 - Victim's name
             * 1 - Killer's name
             * 2 - Killer's health
             * 3 - Killer's vehicle name
             * 4 - Killer's weapon name
             * 5 - Distance between players
             */
            {"DEATH_BLEEDING", "{0} bled to death!"},
            {"DEATH_BONES", "{0} fell to their death!"},
            {"DEATH_FREEZING", "{0} froze to death!"},
            {"DEATH_BURNING", "{0} ignored any fire safety advice!"},
            {"DEATH_FOOD", "{0} starved to death!"},
            {"DEATH_WATER", "{0} dehydrated to death!"},
            {"DEATH_GUN", "{1} [\u2719 {2}] shot and killed {0} using a {4}! [{5}m away]"},
            {"DEATH_GUN_SKULL", "{0} was shot in the head by {1} [\u2719 {2}] using a {4}. [{5}m away]"},
            {"DEATH_MELEE", "{1} [\u2719 {2}] brutally beat {0} to death using a {4}!"},
            {"DEATH_MELEE_SKULL", "{0} was slashed in the head by {1} [\u2719 {2}] using a {4}!"},
            {"DEATH_ZOMBIE", "{0} has been mauled by a zombie!"},
            {"DEATH_ANIMAL", "{0} got demolished when an animal attacked them."},
            {"DEATH_SUICIDE", "{0} killed themselves!"},
            {"DEATH_KILL", "Someone or something decided {0} shouldn't live anymore."},
            {"DEATH_INFECTION", "{0} became a zombie!"},
            {"DEATH_PUNCH", "{1} [\u2719 {2}] punched {0} to death!"},
            {"DEATH_PUNCH_SKULL", "{0} was punched in the head by {1} [\u2719 {2}]!"},
            {"DEATH_BREATH", "{0} thought they could stop breathing but not die, instead they died."},
            {"DEATH_ROADKILL", "{1} [\u2719 {2}], ran over {0}, using a {3}!"},
            {"DEATH_VEHICLE", "{0} has died due to an explosion of a vehicle!"},
            {"DEATH_GRENADE", "{0} was obliterated by being too close to a grenade!"},
            {"DEATH_SHRED", "{0} was shredded to bits!"},
            {"DEATH_LANDMINE", "{0} didn't watch his step and blew up!"},
            {"DEATH_ARENA", "{0} was killed by the arena."},
            {"DEATH_MISSILE", "{0} was annihilated by a missile!"},
            {"DEATH_CHARGE", "{0} was obliterated by a breaching charge!"},
            {"DEATH_SPLASH", "{0} was killed by a weak nearby explosion!"},
            {"DEATH_SENTRY", "{0} entered enemy territory and was shot down by a turret!"},
            {"DEATH_ACID", "{0} was melted alive!"},
            {"DEATH_BOULDER", "{0} was crushed by a boulder!"},
            {"DEATH_BURNING", "{0} gave a hug to a zombie in flames!"},
            {"DEATH_SPIT", "{0} died of shame from spits!"},
            {"DEATH_SPARK", "{0} was shocked to his death!"},

            /* 0 - Money Symbol
             * 1 - Money Reward
             * 2 - Money Name
             */
            {"ROADKILL_REWARD", "You received {0}{1} {2} for roadkill!"},
            {"PUNCH_SKULL_REWARD", "You received {0}{1} {2} for getting a head punch kill!"},
            {"PUNCH_SPINE_REWARD", "You received {0}{1} {2} for getting a torso punch kill!"},
            {"PUNCH_ARM_REWARD", "You received {0}{1} {2} for getting an arm punch kill!"},
            {"PUNCH_LEG_REWARD", "You received {0}{1} {2} for getting a leg punch kill!"},
            {"MELEE_SKULL_REWARD", "You received {0}{1} {2} for getting a head melee kill!"},
            {"MELEE_SPINE_REWARD", "You received {0}{1} {2} for getting a torso melee kill!"},
            {"MELEE_ARM_REWARD", "You received {0}{1} {2} for getting an arm melee kill!"},
            {"MELEE_LEG_REWARD", "You received {0}{1} {2} for getting a leg melee kill!"},
            {"GUN_SKULL_REWARD", "You received {0}{1} {2} for getting a headshot kill!"},
            {"GUN_SPINE_REWARD", "You received {0}{1} {2} for getting a torso shot kill!"},
            {"GUN_ARM_REWARD", "You received {0}{1} {2} for getting an arm shot kill!"},
            {"GUN_LEG_REWARD", "You received {0}{1} {2} for getting a leg shot kill!"}
        };

        protected override void Load()
        {
            Instance = this;

            UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerUpdateHealth += UnturnedPlayerEvents_OnPlayerUpdateHealth;

            #region Configuration Checking

            Logger.LogWarning("--");

            Logger.LogWarning(Configuration.Instance.SuicideMessages
                ? "Suicide messages are enabled!"
                : "Suicide messages are disabled!");

            Logger.LogWarning(Configuration.Instance.HealthWarningMessages
                ? "Health warning messages are enabled!"
                : "Health warning messages are disabled!");

            Logger.LogWarning(Configuration.Instance.ExperienceRewardsEnabled
                ? "Experience is enabled!"
                : "Experience is disabled!");

            Logger.LogWarning(Configuration.Instance.ZombieMessages
                ? "Zombie Death Messages are enabled!"
                : "Zombie Death Messages are disabled!");

            Logger.LogWarning("--");

            #endregion

            Logger.Log("Death Messages Remastered has been loaded!");
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
            UnturnedPlayerEvents.OnPlayerUpdateHealth -= UnturnedPlayerEvents_OnPlayerUpdateHealth;

            Instance = null;

            Logger.Log("Death Messages Remastered has been unloaded!");
        }

        public void UnturnedPlayerEvents_OnPlayerUpdateHealth(UnturnedPlayer player, byte health)
        {
            if (!Configuration.Instance.HealthWarningMessages || health != 25) return;

            UnturnedChat.Say(player, Translate("WARNING_LOW_HEALTH"), Color.yellow);
            UnturnedChat.Say(player, Translate("WARNING_LOW_HEALTH2"), Color.yellow);
        }

        private void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb,
            CSteamID murdererId)
        {
            var murderer = UnturnedPlayer.FromCSteamID(murdererId);
            var moneyName = "N/A";
            var moneySymbol = "N/A";
            var limbWord = "";
            var moneyReward = 0;
            var experienceReward = 0u;

            switch (limb)
            {
                case ELimb.SKULL:
                    moneyReward = Configuration.Instance.UconomyRewards.Head;
                    experienceReward = Configuration.Instance.ExperienceRewards.Head;
                    limbWord = "SKULL";
                    break;
                case ELimb.SPINE:
                    moneyReward = Configuration.Instance.UconomyRewards.Body;
                    experienceReward = Configuration.Instance.ExperienceRewards.Body;
                    limbWord = "SPINE";
                    break;
                case ELimb.RIGHT_ARM:
                case ELimb.LEFT_ARM:
                case ELimb.LEFT_HAND:
                case ELimb.RIGHT_HAND:
                    moneyReward = Configuration.Instance.UconomyRewards.Arm;
                    experienceReward = Configuration.Instance.ExperienceRewards.Arm;
                    limbWord = "ARM";
                    break;
                case ELimb.RIGHT_LEG:
                case ELimb.LEFT_LEG:
                case ELimb.LEFT_FOOT:
                case ELimb.RIGHT_FOOT:
                    moneyReward = Configuration.Instance.UconomyRewards.Leg;
                    experienceReward = Configuration.Instance.ExperienceRewards.Leg;
                    limbWord = "LEG";
                    break;
                default:
                    if (cause == EDeathCause.ROADKILL)
                    {
                        moneyReward = Configuration.Instance.UconomyRewards.Roadkill;
                        experienceReward = Configuration.Instance.ExperienceRewards.Roadkill;
                    }

                    break;
            }

            if (!Configuration.Instance.ExperienceRewardsEnabled) experienceReward = 0;

            if (Configuration.Instance.UconomyRewardsEnabled)
            {
                if (!IsDependencyLoaded("Uconomy") || Uconomy.Instance == null ||
                    Uconomy.Instance.Configuration.Instance == null || Uconomy.Instance.Database == null)
                {
                    Logger.Log(
                        "Uconomy is set to enabled, but it doesn't seem to be currently loaded at all, if even correctly. Please verify it.");
                    moneyReward = 0;
                }
                else
                {
                    moneyName = Uconomy.Instance.Configuration.Instance.MoneyName;
                    moneySymbol = Uconomy.Instance.Configuration.Instance.MoneySymbol;
                }
            }
            else
            {
                moneyReward = 0;
            }

            if (cause == EDeathCause.SUICIDE && Configuration.Instance.SuicideMessages ||
                cause == EDeathCause.ZOMBIE && Configuration.Instance.ZombieMessages)
            {
                UnturnedChat.Say(Translate($"DEATH_{cause}", player?.CharacterName ?? "Someone"),
                    UnturnedChat.GetColorFromName(Configuration.Instance.Messagecolour, Color.red));
            }
            else if(murderer != null)
            {
                UnturnedChat.Say(
                    Translate(
                        $"DEATH_{cause}{((cause == EDeathCause.PUNCH || cause == EDeathCause.MELEE || cause == EDeathCause.GUN) && limb == ELimb.SKULL ? $"_{limb}" : "")}",
                        player?.CharacterName ?? "Someone", murderer?.CharacterName ?? "Anonymous",
                        murderer?.Health ?? 0, murderer?.CurrentVehicle?.asset?.vehicleName ?? "N/A",
                        murderer?.Player?.equipment?.asset?.itemName ?? "N/A",
                        Math.Round(Vector3.Distance(player?.Position ?? Vector3.zero,
                            murderer?.Position ?? Vector3.zero))),
                    UnturnedChat.GetColorFromName(Configuration.Instance.Messagecolour, Color.red));

                if (murderer != null)
                {
                    if (moneyReward != 0)
                        UnturnedChat.Say(murderer,
                            Translate(
                                cause == EDeathCause.PUNCH || cause == EDeathCause.MELEE || cause == EDeathCause.GUN
                                    ? $"{cause}_{limbWord}_REWARD"
                                    : $"{cause}_REWARD",
                                moneySymbol, moneyReward, moneyName), Color.green);
                    if (experienceReward != 0)
                        UnturnedChat.Say(murderer,
                            Translate(
                                cause == EDeathCause.PUNCH || cause == EDeathCause.MELEE || cause == EDeathCause.GUN
                                    ? $"{cause}_{limbWord}_REWARD"
                                    : $"{cause}_REWARD",
                                "", experienceReward, "EXP"), Color.green);
                }
            }

            if (murderer == null) return;

            if (moneyReward != 0)
                try
                {
                    Uconomy.Instance.Database?.IncreaseBalance(murdererId.ToString(), moneyReward);
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    Logger.ExternalLog(e, ConsoleColor.Red);
                }

            if (experienceReward == 0) return;

            try
            {
                murderer.Experience += experienceReward;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                Logger.ExternalLog(e, ConsoleColor.Red);
            }
        }
    }
}