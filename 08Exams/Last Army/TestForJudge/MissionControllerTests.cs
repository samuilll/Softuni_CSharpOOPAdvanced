﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MissionControllerTests
    {
    private MissionController controller;
    [SetUp]
    public void CreateInstance()
    {
        IArmy army = new Army();
        IWareHouse warehouse = new WareHouse();
        this.controller = new MissionController(army, warehouse);
    }
    [Test]
    public void TestForSuccessulMessage()
    {
        IMission mission = new MissionFactory().CreateMission("Easy", 0);

        string message = controller.PerformMission(mission);

        Assert.That(message.Contains($"Mission completed - {mission.Name}"));
    }
    [Test]
    public void TestForFailedMessage()
    {
        IMission mission = new MissionFactory().CreateMission("Hard", 300);

        for (int i = 0; i < 4; i++)
        {
            controller.PerformMission(mission);
        }
        string message = controller.PerformMission(mission);

        Assert.That(message.Contains($"Mission declined - {mission.Name}"));
    }
    [Test]
    public void TestForOnHoldMessage()
    {
        IMission mission = new MissionFactory().CreateMission("Hard", 300);

        string message = controller.PerformMission(mission);

        Assert.That(message.Contains($"Mission on hold - {mission.Name}"));
    }
}

