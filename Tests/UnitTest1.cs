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
            customer = new Customer("tom", "ford", "tom.ford@gmail.com", 123456789);
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
        private UserDAO userDAO;

        [TestInitialize]
        public void Setup()
        {
            customer = new Customer("harry", "mega", "harry.mega@mega.com", 0491006868);
            userDAO = new UserDAO();
            userDAO.createTableUser();
        }
        [TestMethod]
        public void TestDBInsert()
        {
            userDAO.insertNewUser(customer);
            Assert.AreEqual("harry", );
            Assert.AreEqual("mega", );
            Assert.AreEqual("harry.mega@mega.com", );
            Assert.AreEqual(0491006868, );
        }
    }
}