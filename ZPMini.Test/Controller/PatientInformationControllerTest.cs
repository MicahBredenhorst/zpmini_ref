using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPMini.API.Controllers;
using ZPMini.Logic.Interface;

namespace ZPMini.Test.Controller
{
    [TestClass]
    public class PatientInformationControllerTest
    {

        private Mock<IInformationOwnershipLogic> _informationOwnershipLogic;
        private Mock<IPatientInformationLogic> _patientInformationLogic;
        private Mock<IFacilityLogic> _facilityLogic;
        private PatientInformationController _patientInformationController;

        [TestInitialize]
        public void Setup()
        {
            _informationOwnershipLogic = new Mock<IInformationOwnershipLogic>();
            _patientInformationLogic = new Mock<IPatientInformationLogic>();
            _facilityLogic = new Mock<IFacilityLogic>();
            _patientInformationController = new PatientInformationController(
                new Mock<ILogger<PatientInformationController>>().Object,
                _informationOwnershipLogic.Object,
                _facilityLogic.Object,
                _patientInformationLogic.Object,
                ControllerTestAssembly.GetAutoMapper()
                ); 
        }

        public void Get()
        {

        }

        public void Post()
        {

        }

        public void All()
        {

        }

        public void GetRequest()
        {

        }

        public void InformationRequest()
        { 

        }

        public void AllRequests()
        {

        }

        public void Accept()
        {

        }
    }
}
