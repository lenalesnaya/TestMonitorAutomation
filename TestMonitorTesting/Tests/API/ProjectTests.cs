using Allure.Commons;
using Core.BaseEntities.API;
using NUnit.Allure.Attributes;
using SaucedemoTests;
using TestMonitorTesting.Models;
using TestMonitorTesting.Models.Utilities;
using TestMonitorTesting.Services.API;

namespace TestMonitorTesting.Tests.API
{
    [TestFixture]
    internal class ProjectTests : APITest
    {
        private ProjectService _projectService;

        [SetUp]
        public void InitService()
        {
            _projectService = new ProjectService(ApiClient);
        }

        [Test, Category("Positive"), Description("Adding of a project with random values.")]
        [SmokeTest]
        public void AddProject()
        {
            var newProject = new Project()
            {Data = ProjectBuilder.GetRandomProjectData() };

            var addedProject = HandleProjectAdding(newProject);

            Assert.Multiple(() =>
            {
                Assert.That(newProject.Data.Name, Is.EqualTo(addedProject!.Data.Name));
            });
        }

        [Test, Category("Positive"), Description("Getting of recently added project.")]
        [SmokeTest]
        public void GetProject()
        {
            var addedProject = HandleProjectAdding(
                new Project() { Data = ProjectBuilder.StandartProjectData });

            var receivedProject = _projectService.GetProject<Project>(addedProject!.Data.Id);
            Logger.Info("Received object! " + receivedProject);

            Assert.Multiple(() =>
            {
                Assert.That(receivedProject.Data.Name, Is.EqualTo(addedProject.Data.Name));
            });
        }

        [Test, Category("Negative"), Description("Getting of an unexisted project.")]
        [Regression]
        public void GetUnexistedProject()
        {
            var addedProject = HandleProjectAdding(
                new Project() { Data = ProjectBuilder.StandartProjectData });

            var response = _projectService.GetProject(addedProject!.Data.Id * 1000);
            Logger.Info(response.StatusCode);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        public Project? HandleProjectAdding(Project project)
        {
            var addedProject = _projectService.AddProject<Project>(project);
            Logger.Info("New object! " + addedProject);

            return addedProject;
        }
    }
}