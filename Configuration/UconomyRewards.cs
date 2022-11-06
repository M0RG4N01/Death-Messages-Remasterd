using System;

namespace RocketMod.Plugins.DeathMessages.Configuration;

[Serializable]
public class UconomyRewards
{
    public decimal Head { get; set; }
    public decimal Body { get; set; }
    public decimal Arm { get; set; }
    public decimal Leg { get; set; }
    public decimal Roadkill { get; set; }

    public UconomyRewards()
    {
    }

    public UconomyRewards(decimal head, decimal body, decimal arm, decimal leg, decimal roadkill)
    {
        Head = head;
        Body = body;
        Arm = arm;
        Leg = leg;
        Roadkill = roadkill;
    }
}