using IAB251_Assignment_2_Project_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class EmployeeTest
    {
        private Employee _employee;
        private Employee _employee2;


        [TestInitialize]
        public void Setup()
        {
            _employee = new Employee("Benjamin", "Mattes", "ben.mattes@gmail.com", "0450603201", "password", "Admin", "myhouse", _employee.joiningTiming());
            _employee2 = new Employee("Phillip", "Huges", "ben.mattes@gmail.com", "040000000000", "secretkey", "CIO", "myhouse", _employee.joiningTiming());
        }

        [TestMethod]
        public void TestSetup()
        {
            Assert.AreEqual("Benjamin", _employee.getFirstName());
            Assert.AreEqual("Mattes", _employee.getLastName());
            Assert.AreEqual("ben.mattes@gmail.com", _employee.getEmail());
            Assert.AreEqual("0450603201", _employee.getPhoneNumber());
            Assert.AreEqual("password", _employee.getPassword());
            Assert.AreEqual("Admin", _employee.getType());
        }

        [TestMethod]
        public void TestValidEmail()
        {
            Assert.IsTrue(_employee.checkValidEmail(_employee.getEmail()), "Employee must have valid email.");
        }

        [TestMethod]
        public void TestValidPhoneNumber()
        {
            Assert.IsTrue(_employee.checkValidPhoneNumber(_employee.getPhoneNumber()), "Employee must have a valid phone number");
        }

        [TestMethod]
        public void TestPhoneNumbersOnly()
        {
            Assert.IsTrue(_employee.checkValidEmail(_employee.getPhoneNumber()), "Phone number must only contain digits");            
        }

        [TestMethod]
        public void TestEmployeeType()
        {
            Assert.IsTrue(_employee.checkVaildEmployeeType(_employee.getType()), "Employee must have a valid Employee Type");
        }

        [TestMethod]
        public void TestDuplicateEmail()
        {
            Assert.IsTrue(_employee.checkDuplicateEmail(_employee.getEmail(), _employee2.getEmail()), "There is already an account associated with this email address");
        }
    }
}
