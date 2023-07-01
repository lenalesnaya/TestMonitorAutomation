using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class ProjectBuilder
    {
        public static Project StandartProject =>
            TestDataHelper.GetTestEntity<Project>("StandartProject");

        public static Project GetRandomProject() => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " project.",
            Description = FakerHelper.Faker.Lorem.Sentences(),
            StartsAt = FakerHelper.Faker.Date.FutureDateOnly().ToString(),
            EndsAt = FakerHelper.Faker.Date.FutureDateOnly().ToString()
        };
    }
}