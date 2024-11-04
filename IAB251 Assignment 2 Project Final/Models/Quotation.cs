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
            _quarantineReq = quarantineReq;
            //_natureOfJob = natureOfJob;
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
        public int getCustomerId() { return _customerId; }
        public void setCustomerId(int  customerId) { _customerId = customerId;}




        /// <summary>
        /// Test to determine whether email format is valid
        /// </summary>
        /// <param name="email">The user input for email address</param>
        /// <returns>True if format is correct</returns>
        public bool testValidEmail(string email)
        {
            if (email.Contains('@'))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Test to determine if the country inputted is a valid country
        /// </summary>
        /// <param name="country">The user input for source/destination</param>
        /// <returns>True if input is a country</returns>
        public bool testValidCountry(string country)
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
        public bool testNumberContainers(int numberContainers)
        {
            if (numberContainers > 0)
            {
                return true;
            }
            return false;
        }
    }
}
