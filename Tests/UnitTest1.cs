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
            customer = new Customer("tom", "ford", "tom.ford@gmail.com", "123456789", "password");
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
        private Customer customer2;
        private CustomerDAO customerDAO;

        [TestInitialize]
        public void Setup()
        {
            ConnectionControler controler = new ConnectionControler();
            customer = new Customer("harry", "mega", "harry.mega@mega.com", "0491006868", "password");
            customerDAO = new CustomerDAO();
            customerDAO.createTable();
            customer2 = new Customer("vuyo", "manyepe", "v.Manyepe@gmail.com", "0419226868", "vuyosPword");
            customerDAO.insertNew(customer2);
        }

        [TestMethod]
        public void TestCreateTable()
        {
            customerDAO.createTable();
            Assert.IsNotNull(customerDAO);
        }

        [TestMethod]
        public void TestDBGetFromEmailPword()
        {
            string email = "v.Manyepe@gmail.com";
            string password = "vuyosPword";

            Customer currentUser = customerDAO.getFromEmailPword(email, password);

            Assert.IsNotNull(currentUser);
            Assert.AreEqual(customer2.getFirstName(), currentUser.getFirstName());
        }

        [TestMethod]
        public void TestIsExist()
        {
            //customerDAO.isExist()
        }
    }
}