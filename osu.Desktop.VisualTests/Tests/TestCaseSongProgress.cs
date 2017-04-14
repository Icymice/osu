﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.MathUtils;
using osu.Framework.Testing;
using osu.Game.Modes.Objects;
using osu.Game.Screens.Play;

namespace osu.Desktop.VisualTests.Tests
{
    internal class TestCaseSongProgress : TestCase
    {
        public override string Description => @"With fake data";

        private SongProgress progress;

        public override void Reset()
        {
            base.Reset();

            Add(progress = new SongProgress
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
            });

            AddStep("Toggle Bar", progress.ToggleBar);
            AddWaitStep(5);
            //AddStep("Toggle Bar", progress.ToggleVisibility);
            //AddStep("New Values", displayNewValues);

            displayNewValues();
        }

        private void displayNewValues()
        {
            List<HitObject> objects = new List<HitObject>();
            for (double i = 0; i < 2000; i += RNG.NextDouble() * 10 + i / 1000)
                objects.Add(new HitObject { StartTime = i });

            progress.Objects = objects;
            progress.Progress = RNG.NextDouble();
        }
    }
}
