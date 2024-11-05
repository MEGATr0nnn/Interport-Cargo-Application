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
        private Employee _employeeDuplicate;


        [TestInitialize]
        public void Setup()
        {
            _employee = new Employee("Benjamin", "Mattes", "ben.mattes@gmail.com", "0450603201", "password", "Admin");
            _employeeDuplicate = new Employee("Phillip", "Huges", "ben.mattes@gmail.com", "040000000000", "secretkey", "CIO");
        }
        //MAYBE ALSO TEST FOR NULL VALUES

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

        /// <summary>
        /// Test to determine if email is valid
        /// </summary>
        [TestMethod]
        public void TestEmail()
        {
            Assert.IsTrue(_employee.checkValidEmail(_employee.getEmail()), "Employee must have valid email.");
        }

        /// <summary>
        /// Test to determine if phone number is correct format
        /// </summary>
        [TestMethod]
        public void TestPhoneNumber()
        {
            Assert.IsTrue(_employee.checkValidNumber(_employee.getPhoneNumber()), "Employee must have a valid phone number");
        }

        //****** LOGIC FOR THIS DOESNT WORK YET ********
        /// <summary>
        /// Test to determine if phone number contains digits only
        /// </summary>
        [TestMethod]
        public void TestPhoneNumbersOnly()
        {
            Assert.IsTrue(_employee.checkValidEmail(_employee.getPhoneNumber()), "Phone number must only contain digits");            
        }

        /// <summary>
        /// Test to determine if employee type is correct from given list
        /// </summary>
        [TestMethod]
        public void TestEmployeeType()
        {
            Assert.IsTrue(_employee.checkVaildEmployeeType(_employee.getType()), "Employee must have a valid Employee Type");
        }

        /// <summary>
        /// Test to determine if there is an existing account associated with email
        /// </summary>
        [TestMethod]
        public void TestDuplicateEmail()
        {
            Assert.IsTrue(_employee.checkDuplicateEmail(_employee.getEmail(), _employeeDuplicate.getEmail()), "There is already an account associated with this email address");
        }
    }
}
