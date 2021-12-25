using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPMini.API.Controllers;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;
using ZPMini.Data.Interface;
using ZPMini.Data.MockRepository;
using ZPMini.Logic.Interface;

namespace ZPMini.Test.Controller
{
    [TestClass]
    public class PatientControllerTest
    {
        private Mock<ITransferLogic> _transferLogic;
        private Mock<IFacilityLogic> _facilityLogic;
        private Mock<IPatientLogic> _patientLogic;
        private PatientController _patientController;
        private IPatientRepository _patientRepository;
        private IHealthFacilityRepository _facilityRepository;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _transferLogic = new Mock<ITransferLogic>();
            _facilityLogic = new Mock<IFacilityLogic>();
            _patientLogic = new Mock<IPatientLogic>();
            _mapper = ControllerTestAssembly.GetAutoMapper();
            _patientRepository = new MockPatientRepository();
            _facilityRepository = new MockHealthFacilityRepository();

            _patientController = new PatientController(
                new Mock<ILogger<PatientController>>().Object,
                _patientLogic.Object,
                _transferLogic.Object,
                _facilityLogic.Object,
                _mapper
                );
        }
    
        [TestMethod]
        [DataRow("Jack", "Vladi", 200, DisplayName = "Post - Valid input")]
        public void Post(string firstName, string lastName, int statusCode)
        {
            // Arrange
            PatientViewModel model = new()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBrith = DateTime.Now,
            };

            // Act
            var result = _patientController.Post(model);

            // Assert
            _patientLogic.Verify(pl => pl.AddPatient(It.IsAny<Patient>()), Times.Once);
            Assert.AreEqual(statusCode, GetStatusCode(result));
        }

        [TestMethod]
        [DataRow("E11C9F0F-6335-433B-BA55-804F2C2890B2", "Isaura", DisplayName = "Valid patient is requested")]
        [DataRow("E11C9F0F-6335-433B-BA55-804F2C2890B3", 400, DisplayName = "Invalid patient is requested")]
        public void Get(string patientIdString, Object assertor)
        {
            // Arrange
            Guid patientId = Guid.Parse(patientIdString);
            _patientLogic.Setup(p => p.GetPatientById(patientId)).Returns(_patientRepository.Get(patientId));

            // Act
            var result = _patientController.Get(patientId);

            // Assert
            if (assertor.GetType() == typeof(string))
                Assert.AreEqual(assertor, result.Value.FirstName);
            else
                Assert.AreEqual(assertor, GetStatusCode(result.Result));
        }


        [TestMethod]
        [DataRow(4, DisplayName = "All - return valid result")]
        public void All(int patientCount)
        {
            // Arrange
            _patientLogic.Setup(p => p.GetAll()).Returns(_patientRepository.GetAll());

            // Act
            IEnumerable<Patient> result = _patientController.All();

            // Assert
            Assert.AreEqual(patientCount, result.Count());
        }


        [DataRow("6B4AAD53-99E7-4511-B797-B40C74A872B3", "E8A360F5-14AE-46F3-88A4-51CB4AFAD12D", 200, DisplayName = "Valid patient assigned to facility")]
        [DataRow("6B4AAD53-99E7-4511-B797-B40C74A8722c", "E8A360F5-14AE-46F3-88A4-51CB4AFAD12D", 400, DisplayName = "Non exsisting patient is assigned to facility")]
        //[DataRow("6B4AAD53-99E7-4511-B797-B40C74A872B3", "E8A360F5-14AE-46F3-88A4-51CB4AFAD12C", DisplayName = "Valid patient is assigned to non-existing facility")]
        [TestMethod]
        public void AssignPatient(string patientIdString, string facilityIdString, int statusCode)
        {
            // Arrange
            Guid facilityId = Guid.Parse(facilityIdString);
            Guid patientId = Guid.Parse(patientIdString);

            PatientAssignmentViewModel model = new()
            {
                FacilityId = facilityId,
                PatientId = patientId,
            };

            _patientLogic.Setup(p => p.GetPatientById(patientId)).Returns(_patientRepository.Get(patientId));

            // Act
            var result = _patientController.AssignPatient(model);

            // Assert
            _facilityLogic.Verify(f => f.AssignPatient(It.IsAny<Patient>(), It.IsAny<Guid>()), Times.Once);
            Assert.AreEqual(statusCode, GetStatusCode(result));
        }

        [TestMethod] 
        public void TransferPatient(int statusCode)
        {
            PatientTransferViewModel model = new()
            {
                PatientId = Guid.NewGuid(),
                FacilityId = Guid.NewGuid()
            };

            // TODO: Configure logic

            var result = _patientController.TransferPatient(model);

            Assert.AreEqual(statusCode, GetStatusCode(result));
        }

        private static int GetStatusCode(ActionResult<Patient> result)
        {
            // TODO: Find a better solution to detect the type of status codes with messages
            // FIXME: Is triggerd the wrong way for AssignPatient
            if(result.GetType().Name == "ActionResult`1")
            {
                return ((ObjectResult)result.Result).StatusCode.GetValueOrDefault();
            }
            return ((StatusCodeResult)result.Result).StatusCode;
        }
    }
}
