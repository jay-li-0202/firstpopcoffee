﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain.Model;
using FluentAssertions;
using RoastPlanning.Application;
using RoastPlanning.Domain.Model;
using Xunit.Abstractions;

namespace RoastPlanning.Tests.Scenarios.Choosing_roast_days_for_roast_schedule {

    public class When_choosing_roast_days_for_roast_schedule_using_event_store : SpecificationNoMocks<RoastSchedule, ChooseRoastDaysForRoastSchedule> {

        private readonly Guid Id = Guid.NewGuid();

        protected override IEnumerable<Event> Given() {
            yield return PrepareEvent.Set(new RoastScheduleCreatedEvent(Id)).ToVersion(1);
        }

        protected override ChooseRoastDaysForRoastSchedule When() {
            var roastDays = new[] {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday
            };
            return new ChooseRoastDaysForRoastSchedule(Id, roastDays, 1);
        }

        protected override ICommandHandler<ChooseRoastDaysForRoastSchedule> CommandHandler() {
            return new ChooseRoastDaysForRoastScheduleCommandHandler(Repository);
        }

        [Then(Skip = "Not working yet")]
        public void Then_days_for_roast_schedule_are_chosen() {
            PublishedEvents.Last().Should().BeOfType<RoastScheduleRoastDaysChosenEvent>();
        }
    }
}