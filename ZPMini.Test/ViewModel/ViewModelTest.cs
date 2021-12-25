using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZPMini.API.ViewModel;

namespace ZPMini.Test.ViewModel
{
    [TestClass]
    public class ViewModelTest
    {
        [DataRow("hospital 1", "somewhere", 0, DisplayName = "No FacilityName")]
        [DataRow("hospital 1", "", 1, DisplayName = "No FacilityAddress is empty")]
        [DataRow("", "somewhere", 1, DisplayName = "No FacilityName is empty")]
        [DataRow(null, "somewhere", 1, DisplayName = "FacilityName is Null")]
        [DataRow("hospital 1", null, 1, DisplayName = "FacilityAddress is Null")]
        [DataRow(null, null, 2, DisplayName = "Model content is null")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "somewhere", 1, DisplayName = "FacilityName to long")]
        [DataRow("hospital 1", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1, DisplayName = "FacilityAddress to long")]
        [TestMethod]
        public void FacilityViewModelTest(string facilityName, string facilityAddress, int errorCount)
        {
            // Arrange
            FacilityViewModel model = new()
            {
                FacilityName = facilityName,
                FacilityAddress = facilityAddress
            };

            // Act
            var results = ValidateModel(model);

            // Assert
            Assert.AreEqual(errorCount, results.Count);
        }

        [TestMethod]
        public void InformationTransferViewModelTest()
        {

        }

        [TestMethod]
        public void PatientAssignmentViewModelTest()
        {

        }

        [TestMethod]
        public void PatientInformationRequestViewModel()
        {

        }

        [TestMethod]
        public void PatientInformationViewModelTest()
        {

        }

        [TestMethod]
        public void PatientTransferViewModelTest()
        {

        }

        [TestMethod]
        public void PatientViewModelTest()
        {

        }

        private static List<ValidationResult> ValidateModel(Object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
