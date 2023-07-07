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
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("ProjectTests")]
        [AllureSubSuite("API")]
        [SmokeTest]
        public void AddProject()
        {
            var newProject = ProjectBuilder.GetRandomProject();
            var addedProject = HandleProjectAdding(newProject);

            Assert.Multiple(() =>
            {
                Assert.That(newProject.Name, Is.EqualTo(addedProject!.Name));
            });
        }

        [Test, Category("Positive"), Description("Getting of recently added project.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("ProjectTests")]
        [AllureSubSuite("API")]
        [SmokeTest]
        public void GetProject()
        {
            var addedProject = HandleProjectAdding(ProjectBuilder.StandartProject);
            var receivedProject = _projectService.GetProject<Project>(addedProject!.Id);
            Logger.Info("Received object! " + receivedProject);

            Assert.Multiple(() =>
            {
                Assert.That(receivedProject.Name, Is.EqualTo("Standart project."));
            });
        }

        [Test, Category("Negative"), Description("Getting of an unexisted project.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("ProjectTests")]
        [AllureSubSuite("API")]
        [Regression]
        public void GetUnexistedProject()
        {
            var addedProject = HandleProjectAdding(ProjectBuilder.StandartProject);
            try
            {
                _projectService.GetProject(addedProject!.Id + 1000);
                Assert.Fail();
            }
            catch (HttpRequestException ex)
            {
                Logger.Info(ex.Message);
                Assert.Pass();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
                Assert.Fail();
            }
        }

        public Project? HandleProjectAdding(Project project)
        {
            var addedProject = _projectService.AddProject<Project>(project);
            Logger.Info("New object! " + addedProject);

            return addedProject;
        }
    }
}