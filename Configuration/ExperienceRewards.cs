using System;

namespace RocketMod.Plugins.DeathMessages.Configuration;

[Serializable]
public class ExperienceRewards
{
    public uint Head { get; set; }
    public uint Body { get; set; }
    public uint Arm { get; set; }
    public uint Leg { get; set; }
    public uint Roadkill { get; set; }

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