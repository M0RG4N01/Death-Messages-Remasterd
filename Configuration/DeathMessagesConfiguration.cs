using System;
using Rocket.API;

namespace RocketMod.Plugins.DeathMessages.Configuration;

[Serializable]
public class DeathMessagesConfiguration : IRocketPluginConfiguration
{
    public bool UconomyRewardsEnabled { get; set; }
    public bool ExperienceRewardsEnabled { get; set; }
    public bool HealthWarningMessages { get; set; }
    public bool SuicideMessages { get; set; }
    public bool ZombieMessages { get; set; }
    public string MessageColour { get; set; }
    public UconomyRewards UconomyRewards { get; set; }
    public ExperienceRewards ExperienceRewards { get; set; }

    public DeathMessagesConfiguration()
    {
        UconomyRewardsEnabled = true;
        ExperienceRewardsEnabled = true;
        HealthWarningMessages = true;
        SuicideMessages = true;
        ZombieMessages = true;
        MessageColour = "";
        UconomyRewards = new UconomyRewards();
        ExperienceRewards = new ExperienceRewards();
    }

    public void LoadDefaults()
    {
        UconomyRewardsEnabled = true;
        ExperienceRewardsEnabled = true;
        HealthWarningMessages = true;
        SuicideMessages = true;
        ZombieMessages = true;
        MessageColour = "yellow";
        UconomyRewards = new UconomyRewards(30, 15, 5, 5, 10);
        ExperienceRewards = new ExperienceRewards(50, 25, 30, 30, 40);
    }
}