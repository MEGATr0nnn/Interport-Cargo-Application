using IAB251_Assignment_2_Project_Final.Models;

namespace Tests
{
    [TestClass]
    public class CustomerTests
    {
        private Customer _customer;

        [TestInitialize]
        public void Setup()
        {
            _customer = new Customer("tom", "ford", "tom.ford@gmail.com", "123456789", "password", "mycompany");
        }
        [TestMethod]
        public void TestInital()
        {
            Assert.AreEqual("tom", _customer.getFirstName());
            Assert.AreEqual("ford", _customer.getLastName());
            Assert.AreEqual("tom.ford@gmail.com", _customer.getEmail());
            Assert.AreEqual("123456789", _customer.getPhoneNumber());
            Assert.AreEqual("password", _customer.getPassword());
        }
        [TestMethod]
        public void TestGetFirstName()
        {
            _customer.setFirstName("billy");
            Assert.AreEqual("billy", _customer.getFirstName());
        }
        [TestMethod]
        public void TestGetLastName()
        {
            _customer.setLastName("hanks");
            Assert.AreEqual("hanks", _customer.getLastName());
        }
        [TestMethod]
        public void TestGetEmail()
        {
            _customer.setEmail("billy.bob@gmail.com");
            Assert.AreEqual("billy.bob@gmail.com", _customer.getEmail());
        }
    }

    [TestClass]
    public class CustomerDAOTests
    {
        private Customer _customer;
        private Customer _customer2;
        private CustomerDAO _customerDAO;
        private string _email;
        private string _password;
        private PasswordHasher _hash;

        [TestInitialize]
        public void Setup()
        {
            _email = "harry.mega@mega.com";
            _password = "password";
            _customerDAO = new CustomerDAO();
            _customer = new Customer("harry", "mega", _email, "0491006868", _password, "mycompany");
            _customer2 = new Customer("vuyo", "manyepe", "v.Manyepe@gmail.com", "0419226868", "vuyosPword", "mycompany");
            _customerDAO.insertNew(_customer2);
        }

        [TestMethod]
        public void TestCreateTable()
        {
            Assert.IsNotNull(_customerDAO);
        }

        [TestMethod]
        public void TestDBGetFromEmailPword()
        {
            string email = "v.Manyepe@gmail.com";
            string password = "vuyosPword";

            Customer currentUser = _customerDAO.getFromEmailPword(email, password);

            Assert.IsNotNull(currentUser);
            Assert.AreEqual(_customer2.getFirstName(), currentUser.getFirstName());
        }

        [TestMethod]
        public void TestIsExist()
        {
            bool fetch = _customerDAO.isExist(_customer2.getEmail(), _customer2.getPassword());
            Assert.IsTrue(fetch);
        }

        [TestMethod]
        public void TestHashPassword()
        {
            string password = _password;
        }
    }
}