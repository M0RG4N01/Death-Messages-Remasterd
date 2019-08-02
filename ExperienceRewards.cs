namespace Remastered.DeathMessages
{
    public class ExperienceRewards
    {
        public uint Head;
        public uint Body;
        public uint Arm;
        public uint Leg;
        public uint Roadkill;

        public ExperienceRewards()
        {
        }

        public ExperienceRewards(uint head, uint body, uint arm, uint leg, uint roadkill)
        {
            Head = head;
            Body = body;
            Arm = arm;
            Leg = leg;
            Roadkill = roadkill;
        }
    }
}