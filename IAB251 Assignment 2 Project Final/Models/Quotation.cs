using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System;

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

        public List<string> Countries = new List<string> {
            "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", 
            "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia",
            "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia",
            "Cameroon", "Canada", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo (Congo-Brazzaville)",
            "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czechia (Czech Republic)", "Denmark", "Djibouti", "Dominica", "Dominican Republic",
            "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini (Swaziland)", "Ethiopia", "Fiji",
            "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea",
            "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland",
            "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea (North)", "Korea (South)", "Kuwait",
            "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar",
            "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova",
            "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand",
            "Nicaragua", "Niger", "Nigeria", "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Palestine State", "Panama", "Papua New Guinea",
            "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia",
            "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone",
            "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden",
            "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia",
            "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan",
            "Vanuatu", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe"};

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
        /// <param name="import">Is the quotation for importing or exporting (True = Importing).</param>
        /// <param name="packing">Is the quotation for packing or unpacking (True = Packing).</param>
        /// <param name="quarantineReq">Any necessary quarantine requirements for the package.</param>

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

        /// <summary>
        /// Calculates if a discount is applicable
        /// </summary>
        /// <returns></returns>
        public double calculateDiscount()
        {
            if (getNumOfContainers() > 5 && (getQuarantineRequirements() || getFumigation()))
            {
                return 0.975;
            }
            if (getNumOfContainers() > 5 && (getQuarantineRequirements() && getFumigation()))
            {
                return 0.95;
            }
            if (getNumOfContainers() > 10 && (getQuarantineRequirements() && getFumigation()))
            {
                return 0.9;
            }
            return 0;
        }

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
                    return calculate(60, 80, 220, 400, 120, 240, 70, 60, 1.1, discount);
                }
                else if (getFumigation()) //if one
                {
                    return calculate(60, 0, 220, 400, 120, 240, 70, 60, 1.1, discount);
                }
                else if (getCrane()) //if one
                {
                    return calculate(60, 80, 0, 400, 120, 240, 70, 60, 1.1, discount);
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
                    return calculate(70, 120, 280, 500, 160, 300, 100, 90, 1.1, discount);
                }
                else if (getFumigation()) //if one
                {
                    return calculate(70, 0, 280, 500, 160, 300, 100, 90, 1.1, discount);
                }
                else if (getCrane()) //if one
                {
                    return calculate(70, 120, 0, 500, 160, 300, 100, 90, 1.1, discount);
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

        public bool checkValidEmail(string email)
        {
            if (email.Contains('@'))
            {
                return true;
            }
            return false;
        }

        public bool checkValidCountry(string country)
        {
            foreach (string c in Countries)
            {
                if (country.Equals(c))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Test to determine the number of containers is valid
        /// </summary>
        /// <param name="numberContainers">The number of containers to ship</param>
        /// <returns>True is input is greater than 0</returns>
        public bool checkNumberContainers(int numberContainers)
        {
            if (numberContainers > 0)
            {
                return true;
            }
            return false;
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

        public int getCustomerId() { return _customerId; }
        public void setCustomerId(int  customerId) { _customerId = customerId;}

        public string getStatus() { return _status; }
        public void setStatus(string status) { _status = status; }

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
