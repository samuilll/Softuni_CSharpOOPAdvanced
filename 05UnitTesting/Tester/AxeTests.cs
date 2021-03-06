﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    public class AxeTests
    {
        private const int AxeAtack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAtack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAtack()
        {
  
            this.axe.Attack(this.dummy);

            Assert.AreEqual(0, this.axe.DurabilityPoints, "Durability doesn't change after atack");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {

            this.axe.Attack(this.dummy);

            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }


    }
}
