using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HospitalAPI.BusinessLayer;
using HospitalAPI.BusinessLayer.DTO;
using HospitalAPI.Controllers;
using Moq;
using System.Globalization;
using System.Web.Http;
using System.Net;
using System.Web.Http.Routing;
using System.Web.Http.Results;

namespace HospitalAPI.Tests
{
    #region Unit Tests with Moq -- Patients controller
    [TestClass]
    public class PatientsTests
    {
        [TestMethod]
        public void GetAllPatients_Returns_AllPatients()
        {
            // Arrange
            var businessServiceMock = new Mock<IBusinessService>();

            businessServiceMock.Setup(service => service.GetAllPatients()).Returns(PatientTestData());

            var controller = new PatientsController(businessServiceMock.Object);

            // Act
            var actionResult = controller.Get();

            // Assert
            var negResult = actionResult as OkNegotiatedContentResult<List<PatientEntity>>;

            Assert.IsNotNull(negResult);
            Assert.AreEqual(3, negResult.Content.Count);
            Assert.AreEqual(1, negResult.Content[0].Id);
            Assert.AreEqual("FirstName1", negResult.Content[0].FirstName);
            Assert.AreEqual("LastName1", negResult.Content[0].LastName);
        }

        [TestMethod]
        public void GetPatientById_ValidID_Returns_Patient()
        {
            // Arrange
            int id = 2;
            var businessServiceMock = new Mock<IBusinessService>();
            businessServiceMock.Setup(service => service.GetPatientById(id)).Returns(PatientTestData()[1]);

            var controller = new PatientsController(businessServiceMock.Object);

            // Act
            var actionResult = controller.Get(id);

            // Assert
            var negResult = actionResult as OkNegotiatedContentResult<PatientEntity>;

            Assert.IsNotNull(negResult);
            Assert.IsNotNull(negResult.Content);
            Assert.AreEqual(id, negResult.Content.Id);
            Assert.AreEqual("FirstName2", negResult.Content.FirstName);
            Assert.AreEqual("LastName2", negResult.Content.LastName);
        }

        [TestMethod]
        public void GetPatientById_InvalidID_Returns_HttpStatusCode_NotFound()
        {
            // Arrange
            var businessServiceMock = new Mock<IBusinessService>();
            businessServiceMock.Setup(service => service.GetPatientById(10)).Returns((PatientEntity)null);
            
            var controller = new PatientsController(businessServiceMock.Object);

            // Act
            var actionResult = controller.Get(10);

            // Assert
            var negResult = actionResult as NotFoundResult;
            Assert.IsNotNull(negResult);
        }

        private List<PatientEntity> PatientTestData()
        {
            var testPatients = new List<PatientEntity>();
            testPatients.Add(new PatientEntity { Id = 1, FirstName = "FirstName1", LastName = "LastName1", ConditionTypeId = 1, ConditionTypeName = "Condition1", TopographyId = 1, TopographyName = "Topography1", RegistrationDatetime = DateTime.Now.Date });
            testPatients.Add(new PatientEntity { Id = 2, FirstName = "FirstName2", LastName = "LastName2", ConditionTypeId = 2, ConditionTypeName = "Condition2", TopographyId = 2, TopographyName = "Topography2", RegistrationDatetime = DateTime.Now.Date });
            testPatients.Add(new PatientEntity { Id = 3, FirstName = "FirstName3", LastName = "LastName3", ConditionTypeId = 3, ConditionTypeName = "Condition3", TopographyId = 3, TopographyName = "Topography3", RegistrationDatetime = DateTime.Now.Date });
            return testPatients;
        }
        #endregion

    }
}
