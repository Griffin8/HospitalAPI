using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HospitalAPI.BusinessLayer;
using HospitalAPI.BusinessLayer.DTO;
using HospitalAPI.Controllers;
using HospitalAPI.Models;
using Moq;
using System.Web.Http.Routing;
using System.Web.Http.Results;

namespace HospitalAPI.Tests
{
    #region Unit Tests with Moq -- Patients controller
    [TestClass]
    public class PatientRegistrationTests
    {
        [TestMethod]
        public void PostPatientRegistration_ValidRequest_Returns_HttpStatusCode_Created()
        {
            // Arrange
            var businessServiceMock = new Mock<IBusinessService>();
            businessServiceMock.Setup(service => service.RegisterPatient(PatientRegistrationInfoEntityTestData())).Returns(1);

            var controller = new PatientRegistrationController(businessServiceMock.Object);

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.

            string locationUrl = "http://location/";
            var mockUrlHelper = new Mock<UrlHelper>();

            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act
            var actionResult = controller.Post(PatientRegistrationInfoTestData());

            // Assert
            var negResult = actionResult as CreatedNegotiatedContentResult<String>;
            Assert.IsNotNull(negResult);
            Assert.IsNotNull(negResult.Content);
            Assert.AreEqual(negResult.Content, "Patient is regiested");
            Assert.AreEqual(negResult.Location, locationUrl);   
        }
        #endregion

        private PatientRegistrationInfo PatientRegistrationInfoTestData()
        {
            return new PatientRegistrationInfo
            {
                FirstName = "FirstName1",
                LastName = "lastName1",
                DoctorId = 1,
                ConditionTypeId = 2,
                TopographyId = 3,
                TreatmentRoomId = 4,
                ConsultationDate = DateTime.Now.Date.AddDays(1)
            };
        }

        private PatientRegistrationInfoEntity PatientRegistrationInfoEntityTestData()
        {
            return new PatientRegistrationInfoEntity
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                DoctorId = 1,
                ConditionTypeId = 2,
                TopographyId = 3,
                TreatmentRoomId = 4,
                ConsultationDate = DateTime.Now.Date.AddDays(1)
            };
        }
    }
}
