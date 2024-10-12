namespace Tests
{
    [TestClass]
    public class CustomerTests
    {
        private Customer customer;

        [TestInitialize]
        public void Setup()
        {
            customer = new Customer("tom", "ford", "tom.ford@gmail.com", 123345679);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}