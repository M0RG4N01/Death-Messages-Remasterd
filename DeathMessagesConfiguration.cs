using Rocket.API;

namespace Remastered.DeathMessages
{
    public class DeathMessagesConfiguration : IRocketPluginConfiguration
    {
        public bool UconomyRewardsEnabled;
        public bool ExperienceRewardsEnabled;
        public bool HealthWarningMessages;
        public bool SuicideMessages;
        public bool ZombieMessages;
        public string Messagecolour;
        public UconomyRewards UconomyRewards;
        public ExperienceRewards ExperienceRewards;

        public void LoadDefaults()
        {
            UconomyRewardsEnabled = true;
            ExperienceRewardsEnabled = true;
            HealthWarningMessages = true;
            SuicideMessages = true;
            ZombieMessages = true;
            Messagecolour = "yellow";
            UconomyRewards = new UconomyRewards(30, 15, 5, 5, 10);
            ExperienceRewards = new ExperienceRewards(50, 25, 30, 30, 40);
        }
    }
}