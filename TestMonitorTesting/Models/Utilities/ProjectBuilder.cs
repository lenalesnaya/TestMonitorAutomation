using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class ProjectBuilder
    {
        private ProjectData _projectData;

        public ProjectBuilder()
        {
            _projectData = new ProjectData();
        }

        public static ProjectData StandartProjectData =>
            TestDataHelper.GetTestEntity<ProjectData>("StandartProject");

        public static ProjectData GetRandomProjectData() => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " project.",
            Description = FakerHelper.Faker.Lorem.Sentences(),
            StartsAt = FakerHelper.Faker.Date.FutureDateOnly().ToString("yyyy-MM-dd"),
            EndsAt = FakerHelper.Faker.Date.FutureDateOnly().ToString("yyyy-MM-dd"),
            SymbolId = 1
        };

        public ProjectBuilder SetName(string name)
        {
            _projectData.Name = name;

            return this;
        }

        public ProjectBuilder SetSymbolId(int symbolId)
        {
            _projectData.SymbolId = symbolId;

            return this;
        }

        public ProjectBuilder SetDescription(string description)
        {
            _projectData.Description = description;

            return this;
        }

        public ProjectBuilder SetStartsAt(string startsAt)
        {
            _projectData.StartsAt = startsAt;

            return this;
        }

        public ProjectBuilder SetEndsAt(string endsAt)
        {
            _projectData.EndsAt = endsAt;

            return this;
        }

        public ProjectBuilder SetUsesApplications(bool usesApplications)
        {
            _projectData.UsesApplications = usesApplications;

            return this;
        }

        public ProjectBuilder SetUsesRequirements(bool usesRequirements)
        {
            _projectData.UsesRequirements = usesRequirements;

            return this;
        }

        public ProjectBuilder SetUsesRisks(bool usesRisks)
        {
            _projectData.UsesRisks = usesRisks;

            return this;
        }

        public ProjectBuilder SetUsesIssues(bool usesIssues)
        {
            _projectData.UsesIssues = usesIssues;

            return this;
        }

        public ProjectBuilder SetUsesMessages(bool usesMessages)
        {
            _projectData.UsesMessages = usesMessages;

            return this;
        }

        public ProjectBuilder SetCompleted(bool completed)
        {
            _projectData.Completed = completed;

            return this;
        }

        public Project Build()
        {
            return new Project { Data = _projectData };
        }
    }
}