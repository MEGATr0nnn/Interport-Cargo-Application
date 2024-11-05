using IAB251_Assignment_2_Project_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class QuotationTest
    {
        private Quotation _quotation;

        [TestInitialize]
        public void Setup()
        {
            _quotation = new Quotation("Billy, billy@gmail.com", "Morocco", "Spain", 3, "Rare Vehicle, 4995 x 1951mm", true, true, "no quarantine");
        }

        /// <summary>
        /// Method testing whether the email is of a valid format
        /// </summary>
        [TestMethod]
        public void testValidEmail()
        {
            Assert.IsTrue(_quotation.checkValidEmail(_quotation.getCustomerInformation()), "Email must have @ symbol");
        }

        /// <summary>
        /// Method testing whether the source is a valid country
        /// </summary>
        [TestMethod]
        public void testValidCountrySource()
        {
            Assert.IsTrue(_quotation.checkValidCountry(_quotation.getSource()), "Source country is not valid");
        }


        /// <summary>
        /// Method testing whether the destination is a valid country
        /// </summary>
        [TestMethod]
        public void testValidCountryDestination()
        {
            Assert.IsTrue(_quotation.checkValidCountry(_quotation.getDestination()), "Destination country is not valid");
        }

        /// <summary>
        /// Method testing whether the number of containers is valid (Greater than 0)
        /// </summary>
        [TestMethod]
        public void testValidContainers()
        {
            Assert.IsTrue(_quotation.checkNumberContainers(_quotation.getNumOfContainers()), "Containers must be of a whole number");
        }
    }
}
