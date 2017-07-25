using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Demo.Models;
using System.ComponentModel.DataAnnotations;
using Demo.Models.Domain;

namespace Demo.Tests
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void ValidateCustomer_Customer_NoError()
        {
            // Arrange
            Customer customer = new Customer();
            customer.CustomerID = "aaa";
            customer.CompanyName = "AAA company";

            // Act
            var validationResult = ValidationHelper.ValidateEntity<Customer>(customer);

            // Assert
            Assert.IsFalse(validationResult.HasError);
        }

        [TestMethod]
        public void ValidateCustomer_Customer_CustomerIDRequiredError()
        {
            // Arrange
            Customer customer = new Customer();
            customer.CompanyName = "AAA company";

            // Act
            var validationResult = ValidationHelper.ValidateEntity<Customer>(customer);

            // Assert
            Assert.IsTrue(validationResult.HasError);
            Assert.AreEqual(1, validationResult.Errors.Count);
            Assert.AreEqual("The CustomerID field is required.", validationResult.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateCustomer_Customer_CountryError()
        {
            // Arrange
            Customer customer = new Customer();
            customer.CustomerID = "aaa";
            customer.CompanyName = "AAA company";
            customer.Country = "UK";

            // Act
            var validationResult = ValidationHelper.ValidateEntity<Customer>(customer);

            // Assert
            Assert.IsTrue(validationResult.HasError);
            Assert.AreEqual(1, validationResult.Errors.Count);
            Assert.AreEqual("The field Country is invalid.", validationResult.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateCustomer_Customer_PhoneNumberError()
        {
            // Arrange
            Customer customer = new Customer();
            customer.CustomerID = "aaa";
            customer.CompanyName = "AAA company";
            customer.Phone = "incorrect_phone";

            // Act
            var validationResult = ValidationHelper.ValidateEntity<Customer>(customer);

            // Assert
            Assert.IsTrue(validationResult.HasError);
            Assert.AreEqual(1, validationResult.Errors.Count);
            Assert.AreEqual("The field Phone is invalid.", validationResult.Errors[0].ErrorMessage);
        }
    }

    public class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; private set; }
        public bool HasError
        {
            get { return Errors.Count > 0; }
        }

        public EntityValidationResult(IList<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }
    }


    public class EntityValidator<T> where T : class
    {
        public EntityValidationResult Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject(entity, vc, validationResults, true);

            return new EntityValidationResult(validationResults);
        }
    }

    public class ValidationHelper
    {
        public static EntityValidationResult ValidateEntity<T>(T entity)
            where T : class
        {
            return new EntityValidator<T>().Validate(entity);
        }

    }
}
