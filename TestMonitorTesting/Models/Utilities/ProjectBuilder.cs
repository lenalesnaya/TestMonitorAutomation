using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class ProjectBuilder
    {
        private Project _project;

        public ProjectBuilder()
        {
            _project = new Project();
        }

        public static Project StandartProject =>
            TestDataHelper.GetTestEntity<Project>("StandartProject");

        public static Project GetRandomProject() => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " project.",
            Description = FakerHelper.Faker.Lorem.Sentences(),
            StartsAt = FakerHelper.Faker.Date.FutureDateOnly().ToString(),
            EndsAt = FakerHelper.Faker.Date.FutureDateOnly().ToString()
        };

        public ProjectBuilder SetName(string name)
        {
            _project.Name = name;

            return this;
        }

        public ProjectBuilder SetSymbolId(int symbolId)
        {
            _project.SymbolId = symbolId;

            return this;
        }

        public ProjectBuilder SetDescription(string description)
        {
            _project.Description = description;

            return this;
        }

        public ProjectBuilder SetStartsAt(string startsAt)
        {
            _project.StartsAt = startsAt;

            return this;
        }

        public ProjectBuilder SetEndsAt(string endsAt)
        {
            _project.EndsAt = endsAt;

            return this;
        }

        public ProjectBuilder SetUsesApplications(bool usesApplications)
        {
            _project.UsesApplications = usesApplications;

            return this;
        }

        public ProjectBuilder SetUsesRequirements(bool usesRequirements)
        {
            _project.UsesRequirements = usesRequirements;

            return this;
        }

        public ProjectBuilder SetUsesRisks(bool usesRisks)
        {
            _project.UsesRisks = usesRisks;

            return this;
        }

        public ProjectBuilder SetUsesIssues(bool usesIssues)
        {
            _project.UsesIssues = usesIssues;

            return this;
        }

        public ProjectBuilder SetUsesMessages(bool usesMessages)
        {
            _project.UsesMessages = usesMessages;

            return this;
        }

        public ProjectBuilder SetCompleted(bool completed)
        {
            _project.Completed = completed;

            return this;
        }

        public Project Build()
        {
            return _project;
        }
    }
}