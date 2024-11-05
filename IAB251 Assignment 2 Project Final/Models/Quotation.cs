namespace IAB251_Assignment_2_Project_Final.Models
{
    /// <summary>
    /// This class creates an instance of Quotation
    /// </summary>
    public class Quotation
    {
        //quotation fields
        private int _id;
        private string _customerInformation;
        private string _source;
        private string _destination;
        private int _numOfContainers;
        private int _sizeOfContainers;
        private string _natureOfPackage;
        private bool _importExport;
        private bool _packing;
        private string _quarantineReq;
        private bool _fumigation;
        private bool _crane;
        private int _customerId;
        private string _status;

        //cost fields
        private int _wharffBookingFee;
        private int _craneFee;
        private int _fumigationFee;
        private int _LCLDeliveryDepot;
        private int _tailgateInspection;
        private int _storageFee;
        private int _facilityFee;
        private int _wharfInspection;
        private int _GST;

        /// <summary>
        /// Quotation class constructior. Used to instantise the Quotation Object
        /// </summary>
        /// <param name="customerInformation">The </param>
        /// <param name="source">The source of the quotation.</param>
        /// <param name="destination">The desired destination.</param>
        /// <param name="numOfContainers">Number of containers that need to be shipped.</param>
        /// <param name="natureOfPackage">Whats in the package (ie auto parts).</param>
        /// <param name="natureOfJob">The details of the job (ie import/export, fumigation, packing/unpacking and quarantine requirements).</param>
        public Quotation(string customerInformation, string source, string destination, int numOfContainers, int sizeOfContainers, string natureOfPackage, bool importExport, bool packing, string quarantineReq, bool fumigation, bool crane, string status)
        {
            _customerInformation = customerInformation;
            _source = source;
            _destination = destination;
            _numOfContainers = numOfContainers;
            _sizeOfContainers = sizeOfContainers;
            _natureOfPackage = natureOfPackage;
            _importExport = importExport;
            _packing = packing;
            _quarantineReq = quarantineReq;
            _fumigation = fumigation;
            _crane = crane;
            _status = status;
        }

        //methods
        public void calculateCharges(int sizeOfContainer)
        {
            if (sizeOfContainer == 20)
            {

            }

            else
            {

            }
        }



        //Getters and setters
        public int getId() { return _id; }
        public void setId(int id) { _id = id; }

        public string getCustomerInformation() { return _customerInformation; }
        public void setCustomerInformation(string customerInformation) { _customerInformation = customerInformation; }

        public string getSource() { return _source; }
        public void setSource(string source) { _source = source; }

        public string getDestination() { return _destination; }
        public void setDestination(string destination) { _destination = destination; }

        public int getNumOfContainers() { return _numOfContainers; }
        public void setNumOfContainers(int numOfOContainers) { _numOfContainers = numOfOContainers; }

        public string getNatureOfPackage() { return _natureOfPackage; }
        public void setNatureOfPackage(string natureOfPackage) { _natureOfPackage = natureOfPackage; }

        public bool getImport() { return _importExport; }
        public void setImport(bool importExport) { _importExport = importExport; }

        public bool getPacking() { return _packing; }
        public void setPacking(bool packing) { _packing = packing; }

        public string getQuarantineRequirements() { return _quarantineReq; }
        public void setQuarantineRequirements(string quarantineReq) { _quarantineReq = quarantineReq; }

        public int getsizeOfContainers() { return _sizeOfContainers; }
        public void setContainerSize(int size) { _sizeOfContainers = size; }

        public bool getFumigation() { return _fumigation; }
        public void setFumigation(bool fumigation) { _fumigation = fumigation; }

        public bool getCrane() { return _crane; }
        public void setCrane(bool crane) { _crane = crane; }

        public string getStatus() { return _status; }
        public void setStatus(string status) { _status = status; }

        public int getCustomerId() { return _customerId; }
        public void setCustomerId(int  customerId) { _customerId = customerId;}



    }
}
