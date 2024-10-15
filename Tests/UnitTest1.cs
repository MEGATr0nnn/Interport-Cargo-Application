using EFB225_Assignment_2___Enterprise_Solution.Database_Model;
using IAB251_Assignment_2_Project_Final.Models;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Customer customer;

        [TestInitialize]
        public void Setup()
        {
            customer = new Customer("tom", "ford", "tom.ford@gmail.com", 123456789, "password");
        }
        [TestMethod]
        public void TestInital()
        {
            Assert.AreEqual("tom", customer.getFirstName());
            Assert.AreEqual("ford", customer.getLastName());
            Assert.AreEqual("tom.ford@gmail.com", customer.getEmail());
            Assert.AreEqual(123456789, customer.getPhoneNumber());
            Assert.AreEqual("password", customer.getPassword());
        }
        [TestMethod]
        public void TestFirstName()
        {
            customer.setFirstName("billy");
            Assert.AreEqual("billy", customer.getFirstName());
        }
        [TestMethod]
        public void TestLastName()
        {
            customer.setLastName("hanks");
            Assert.AreEqual("hanks", customer.getLastName());
        }
        [TestMethod]
        public void TestEmail()
        {
            customer.setEmail("billy.bob@gmail.com");
            Assert.AreEqual("billy.bob@gmail.com", customer.getEmail());
        }
    }

    [TestClass]
    public class UnitTest2
    {
        private Customer customer;
        private CustomerDAO customerDAO;

        [TestInitialize]
        public void Setup()
        {
            customer = new Customer("harry", "mega", "harry.mega@mega.com", 0491006868, "password");
            customerDAO = new CustomerDAO();
            customerDAO.createTable();
        }
        [TestMethod]
        public void TestCreateTable()
        {
            customerDAO.createTable();
        }
        [TestMethod]
        public void TestDBInsert()
        {
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customerDAO);
            customerDAO.insertNew(customer);

            List<Customer> list = customerDAO.get(customer);
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count);
        }
    }
}