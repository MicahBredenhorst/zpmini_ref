using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZPMini.Logic.Interface;
using Microsoft.Extensions.Logging;
using ZPMini.Data.MockRepository;
using Microsoft.AspNetCore.Mvc;
using ZPMini.API.Controllers;
using ZPMini.Data.Entity;
using System;
using Moq;
using ZPMini.API.ViewModel;

namespace ZPMini.Test.Controller
{
    [TestClass]
    public class FacilityControllerTest
    {
        private Mock<IFacilityLogic> _facilityLogic;
        private MockHealthFacilityRepository _facilityRepository;
        private FacilityController _facilityController;
        
        [TestInitialize]
        public void Setup()
        {
            _facilityLogic = new Mock<IFacilityLogic>();
            _facilityController = new FacilityController(_facilityLogic.Object,
                new Mock<ILogger<FacilityController>>().Object, 
                ControllerTestAssembly.GetAutoMapper());
            _facilityRepository = new MockHealthFacilityRepository();
        }

        [TestMethod]
        [DataRow("E8A360F5-14AE-46F3-88A4-51CB4AFAD12D", "Hospital A", DisplayName = "Default GET of facility")]
        [DataRow("E8A360F5-14AE-46F3-88A4-51CB4AFAD12A", 400, DisplayName = "Default GET of facility, Id not in DB")]
        [DataRow("00000000-0000-0000-0000-000000000000", 400, DisplayName = "Invalid GET of facility, No empty GUID allowed")]
        public void Get(string facilityIdString, Object assertor)
        {
            // Arrange
            Guid facilityId = Guid.Parse(facilityIdString);
            _facilityLogic.Setup(p => p.GetHealthFacility(facilityId)).Returns(_facilityRepository.Get(facilityId));

            // Act
            var result = _facilityController.Get(facilityId);

            // Assert
            if(assertor.GetType() == typeof(string))
                Assert.AreEqual(assertor, result.Value.FacilityName);
            else
                Assert.AreEqual(assertor, GetStatusCode(result));
        }

        [DataRow(200, "Hospital A", "Somewhere")]
        [TestMethod]
        public void Post(int assertor, string facilityName, string facilityAddress)
        {
            // Arrange
            FacilityViewModel model = new()
            {
                FacilityAddress = facilityAddress,
                FacilityName = facilityName
            };

            // Act
            var result = _facilityController.Post(model);

            // Assert
            Assert.AreEqual(assertor, GetStatusCode(result));
        }

        private static int GetStatusCode(ActionResult<HealthFacility> result)
        {
            return ((StatusCodeResult)result.Result).StatusCode;
        }
    }
}
