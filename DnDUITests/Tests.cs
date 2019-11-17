﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DnDUITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void MainMenuHasCorrectButtons()
        {
            Assert.IsNotEmpty(app.Query(c => c.Marked("Characters")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Maps")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Games")));
        }

        [Test]
        public void CharacterDisplaysAbilityScores()
        {
            app.Tap(c => c.Marked("Characters"));
            Assert.IsEmpty(app.Query(
                c => c.Marked("AbilityScoreView")
                    .Child().Text("")
            ));
        }

        [Test]
        public void CharacterDisplaysSkills()
        {
            app.Tap(c => c.Marked("Characters"));
            Assert.IsEmpty(app.Query(
                c => c.Marked("SkillView")
                    .Child().Text("")
            ));
        }

        [Test]
        public void CharacterDisplaysTraits()
        {
            app.Tap(c => c.Marked("Characters"));
            app.Tap(c => c.Marked("Traits"));

            Assert.IsNotEmpty(app.Query(
                c => c.All().Marked("TraitsView")
            ));

            Assert.IsEmpty(app.Query(
                c => c.All().Marked("TraitsView")
                .Child().Text("")
            ));
        }
    }
}