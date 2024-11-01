namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// Quotation class, this class is designed around instantising the object Quotation
    /// </summary>
    public class Quotation
    {
        private int _id;
        private string _customerInformation;
        private string _source;
        private string _destination;
        private int _numOfContainers;
        private string _natureOfPackage;
        private string _natureOfJob;
        private int _customerId;

        /// <summary>
        /// Quotation class constructior. Used to instantise the Quotation Object
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="numOfContainers"></param>
        /// <param name="natureOfPackage"></param>
        /// <param name="natureOfJob"></param>
        public Quotation(string customerInformation, string source, string destination, int numOfContainers, string natureOfPackage, string natureOfJob)
        {
            _customerInformation = customerInformation;
            _source = source;
            _destination = destination;
            _numOfContainers = numOfContainers;
            _natureOfPackage = natureOfPackage;
            _natureOfJob = natureOfJob;
        }

        public int getId() { return _id; }
        public void setId(int id) { _id = id; }

        public string getCustomerInformation() { return _customerInformation;}
        public void setCustomerInformation(string customerInformation) { _customerInformation = customerInformation; }

        public string getSource() { return _source; }
        public void setSource(string source) { _source = source; }

        public string getDestination() { return _destination;}
        public void setDestination(string destination) { _destination = destination; }

        public int getNumOfContainers() { return _numOfContainers;}
        public void setNumOfContainers(int numOfOContainers) { _numOfContainers = numOfOContainers; }

        public string getNatureOfPackage() {  return _natureOfPackage; }
        public void setNatureOfPackage(string natureOfPackage) { _natureOfPackage= natureOfPackage; }

        public string getNatureOfJob() {  return _natureOfJob; }
        public void setNatureOfJob(string natureOfJob) { _natureOfJob= natureOfJob; }

        public int getCustomerId() { return _customerId; }
        public void setCustomerId(int  customerId) { _customerId = customerId;}
    }
}
