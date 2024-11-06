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
            _quotation = new Quotation("Billy", "Morocco", "Spain", 3, 20, "Rare Vehicle", true, true, false, true, true, "Pending");
        }

        [TestMethod]
        public void testValidCountrySource()
        {
            Assert.IsTrue(_quotation.checkValidCountry(_quotation.getSource()), "Source country is not valid");
        }


        [TestMethod]
        public void testValidCountryDestination()
        {
            Assert.IsTrue(_quotation.checkValidCountry(_quotation.getDestination()), "Destination country is not valid");
        }

        [TestMethod]
        public void testValidContainers()
        {
            Assert.IsTrue(_quotation.checkNumberContainers(_quotation.getNumOfContainers()), "Containers must be of a whole number");
        }
    }

    [TestClass]
    public class QuotationDAOTests
    {
        private Quotation _quotation;
        private Customer _customer;
        private QuotationDAO _quotationDAO;
        private string status = "Pending";

        [TestInitialize]
        public void Setup()
        {
            _quotation = new Quotation("Billy", "Morocco", "Spain", 3, 20, "Rare Vehicle", true, true, false, true, true, "Pending");
            _quotationDAO = new QuotationDAO();
            _customer = new Customer("harry", "mega", "harry.mega@mega.com", "0491006868", "password", "mycompany");
            _quotationDAO.insertNew(_quotation, _customer);
        }

        [TestMethod]
        public void TestUpdate()
        {
            _quotation.setCustomerInformation("Bob");
            _quotationDAO.update(_quotation, _quotation.getCustomerId());
            Quotation fetched = _quotationDAO.getSpecificQuotation(_quotation.getId());
            Assert.AreEqual("Bob", fetched.getCustomerInformation());
        }

        [TestMethod]
        public void TestValidEmail()
        {
            Assert.IsTrue(_quotation.checkValidEmail(_customer.getEmail()));

        }

        [TestMethod]
        public void TestGetSpecific()
        {
            Quotation fetched = _quotationDAO.getSpecificQuotation(_quotation.getId());
            Assert.AreEqual(_quotation.getId(), fetched.getId());
        }

        [TestMethod]
        public void TestGetFromStatus()
        {
            List<Quotation> fetched = _quotationDAO.getStatusQuotation(status);
            Assert.AreEqual(1, fetched.Count());
        }

        [TestMethod]
        public void TestGetAll()
        {
            List<Quotation> fetched = _quotationDAO.getAllQuotations();
            Assert.AreEqual(1, fetched.Count());
        }
    }
}
