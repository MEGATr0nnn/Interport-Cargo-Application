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
        private int _sizeOfContainers; //new dropdown box only two sizes 20ft 40ft
        private string _natureOfPackage;
        private bool _importExport;
        private bool _packing;
        private bool _quarantineReq;
        private bool _fumigation; //new radio
        private bool _crane; //new radio
        private int _customerId;
        private string _status; //new automatically assign to pending when initally created in quotation request

        //pending is autoassigned - pending 
        //status = check
        //if status = check{
        //display pill box}


        //cost fields
        private int _wharfBookingFee;
        private int _craneFee;
        private int _fumigationFee;
        private int _LCLDeliveryDepot;
        private int _tailgateInspection;
        private int _storageFee;
        private int _facilityFee;
        private int _wharfInspection;
        private double _GST;
        private double _total;

        /// <summary>
        /// Quotation class constructior. Used to instantise the Quotation Object
        /// </summary>
        /// <param name="customerInformation">The </param>
        /// <param name="source">The source of the quotation.</param>
        /// <param name="destination">The desired destination.</param>
        /// <param name="numOfContainers">Number of containers that need to be shipped.</param>
        /// <param name="natureOfPackage">Whats in the package (ie auto parts).</param>
        /// <param name="natureOfJob">The details of the job (ie import/export, fumigation, packing/unpacking and quarantine requirements).</param>
        public Quotation(string customerInformation, string source, string destination, int numOfContainers, int sizeOfContainers, string natureOfPackage, bool importExport, bool packing, bool quarantineReq, bool fumigation, bool crane, string status)
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



        public double calculateDiscount()
        {
            if (getNumOfContainers() > 5 && (getQuarantineRequirements() ||  getFumigation()))
            {
                return 0.025;
            }
            if (getNumOfContainers() > 5 && (getQuarantineRequirements() && getFumigation()))
            {
                return 0.05;
            }
            if (getNumOfContainers() > 10 && (getQuarantineRequirements() && getFumigation()))
            {
                return 0.1;
            }
            return 0;
        }
        //methods
        /// <summary>
        /// Automatically alculates the charges via the corresponding fees and container sizes. This was made in a rush and could be better optimised with a dictonary
        /// or a class that has the fee structure and initalises a switch case based on if _crane ? craneFee : 0;
        /// </summary>
        /// <param name="sizeOfContainer">The size of the container</param>
        /// <returns>A double</returns>
        public double calculateCharges(int sizeOfContainer, double discount)
        {
            if (sizeOfContainer == 20)
            {
                if (getFumigation() && getCrane()) //if both
                {
                    return calculate(60, 80, 220, 400, 120, 240, 70, 60, 0.1, discount);
                }
                else if (getFumigation()) //if one
                {
                    return calculate(60, 0, 220, 400, 120, 240, 70, 60, 0.1, discount);
                }
                else if (getCrane()) //if one
                {
                    return calculate(60, 80, 0, 400, 120, 240, 70, 60, 0.1, discount);
                }
                else //if none
                {
                    return 0;
                }
            }
            else 
            {
                if (getFumigation() && getCrane()) //if both
                {
                    return calculate(70, 120, 280, 500, 160, 300, 100, 90, 0.1, discount);
                }
                else if (getFumigation()) //if one
                {
                    return calculate(70, 0, 280, 500, 160, 300, 100, 90, 0.1, discount);
                }
                else if (getCrane()) //if one
                {
                    return calculate(70, 120, 0, 500, 160, 300, 100, 90, 0.1, discount);
                }
                else //if none
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Rudimentary method made in a rush that both sets and calculates the values
        /// </summary>
        /// <param name="wharfFee">Wharf Fee</param>
        /// <param name="craneFee">Crane Fee</param>
        /// <param name="fumigationFee">Fumigation Fee</param>
        /// <param name="LCL">LCL Fee</param>
        /// <param name="tailgateFee">Tailgate Fee</param>
        /// <param name="storageFee">Storage Fee</param>
        /// <param name="facilityFee">Facility Fee</param>
        /// <param name="wharfInspection">Wharf Inspection Fee</param>
        /// <param name="GST">GST</param>
        /// <returns>A double, Total</returns>
        public double calculate(int wharfFee, int craneFee, int fumigationFee, int LCL, int tailgateFee, int storageFee, int facilityFee, int wharfInspection, double GST, double discount)
        {
            
            setWharfFee(wharfFee);
            setCraneFee(craneFee);
            setFumigationFee(fumigationFee);
            setLCLFee(LCL);
            setTailgateFee(tailgateFee);
            setStorageFee(storageFee);
            setFacilityFee(facilityFee);
            setWharfInspectionFee(wharfInspection);
            setGST(GST);
            double subtotal = (getWharfFee() + getCraneFee() + getFumigationFee() + getLCLFee() 
                + getTailgateFee() + getStorageFee() + getFacilityFee() + getWharfInspectionFee());
            if (discount != 0)
            {
                setTotal((subtotal * discount) * getGST());
            }
            else setTotal(subtotal * getGST());
            return getTotal();
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

        public bool getQuarantineRequirements() { return _quarantineReq; }
        public void setQuarantineRequirements(bool quarantineReq) { _quarantineReq = quarantineReq; }

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

        //cost getters and setters
        public int getWharfFee() { return _wharfBookingFee; }
        public void setWharfFee(int fee) { _wharfBookingFee = fee; }

        public int getCraneFee() { return _craneFee; }
        public void setCraneFee(int fee) { _craneFee = fee;}

        public int getFumigationFee() { return _fumigationFee; }
        public void setFumigationFee(int fee) { _fumigationFee = fee; }

        public int getLCLFee() { return _LCLDeliveryDepot; }
        public void setLCLFee(int fee) { _LCLDeliveryDepot = fee; }

        public int getTailgateFee() { return _tailgateInspection; }
        public void setTailgateFee(int fee) { _tailgateInspection = fee;}

        public int getStorageFee() { return _storageFee; }
        public void setStorageFee(int fee) { _storageFee = fee;}

        public int getFacilityFee() { return _facilityFee; }
        public void setFacilityFee(int fee) { _facilityFee = fee;}

        public int getWharfInspectionFee() { return _wharfInspection; }
        public void setWharfInspectionFee(int fee) { _wharfInspection = fee;}

        public double getGST() { return _GST; }
        public void setGST(double gst) { _GST = gst; }

        public double getTotal() { return _total; }
        public void setTotal(double total) { _total = total; }


    }
}
