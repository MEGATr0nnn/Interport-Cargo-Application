namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This class creates an instance of Quotation
    /// </summary>
    public class Quotation
    {
        //fields
        private int _id;
        private string _customerInformation;
        private string _source;
        private string _destination;
        private int _numOfContainers;
        private string _natureOfPackage;
        private bool _import;
        private bool _packing;
        private string _quarantineReq;
        private int _customerId;

        /// <summary>
        /// Quotation class constructior. Used to instantise the Quotation Object
        /// </summary>
        /// <param name="customerInformation">The </param>
        /// <param name="source">The source of the quotation.</param>
        /// <param name="destination">The desired destination.</param>
        /// <param name="numOfContainers">Number of containers that need to be shipped.</param>
        /// <param name="natureOfPackage">Whats in the package (ie auto parts).</param>
        /// <param name="import">Is the quotation for importing or exporting (True = Importing).</param>
        /// <param name="packing">Is the quotation for packing or unpacking (True = Packing).</param>
        /// <param name="quarantineReq">Any necessary quarantine requirements for the package.</param>

        public Quotation(string customerInformation, string source, string destination, int numOfContainers, string natureOfPackage, bool import, bool packing, string quarantineReq)
        {
            _customerInformation = customerInformation;
            _source = source;
            _destination = destination;
            _numOfContainers = numOfContainers;
            _natureOfPackage = natureOfPackage;
            _import = import;
            _packing = packing;
            _import = import;
            _packing = packing;
            _quarantineReq = quarantineReq;
        }

        //Getters and setters
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

        public bool getImport() { return _import; }
        public void setImport(bool import) { _import = import; }

        public bool getPacking() { return _packing; }
        public void setPacking(bool packing) { _packing = packing; }

        public string getQuarantineRequirements() { return _quarantineReq; }
        public void setQuarantineRequirements(string quarantineReq) { _quarantineReq = quarantineReq; }


        //public string getNatureOfJob() {  return _natureOfJob; }
        //public void setNatureOfJob(string natureOfJob) { _natureOfJob= natureOfJob; }

        public int getCustomerId() { return _customerId; }
        public void setCustomerId(int  customerId) { _customerId = customerId;}
    }
}
