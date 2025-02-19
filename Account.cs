using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHealthUnited
{
    public class Account
    {
        private string LastName;
        private string FirstName;
        private string FullName;
        private string SocSecNum;
        private DateTime DateOfBirth;
        private string SpouseLastName;
        private string SpouseFirstName;
        private string SpouseSocNum;
        private string SpouseDateOfBirth;
        private string Address1;
        private string Address2;
        private string City;
        private string StateCode;
        private string ZipCode;
        private string PhoneNumber;
        private string EmployerName;
        private string WorkPhone;
        private string SpouseEmployer;
        private string SpouseWorkPhone;
        private string MinorChildName;
        private string DescriptOfService;
        private double OrginialBalance;
        private double AmountDue;
        private DateTime LastDateOfService;
        private DateTime DelinquencyDate;
        private DateTime ItemizationDate;
        private string AccountNumber;
        private string AdditionalInformation;

        public Account(string lastName, string firstName, string socSecNum, DateTime dateOfBirth, string spouseLastName, string spouseFirstName, string spouseSocNum, string spouseDateOfBirth, string address1, string address2, string city, string stateCode, string zipCode, string phoneNumber, string employerName, string workPhone, string spouseEmployer, string spouseWorkPhone, string minorChildName, string descriptOfService, double orginialBalance, double amountDue, DateTime lastDateOfService, DateTime delinquencyDate, DateTime itemizationDate, string accountNumber, string additionalInformation)
        {
            LastName = lastName;
            FirstName = firstName;
            FullName = firstName + "_" + lastName;
            SocSecNum = socSecNum;
            DateOfBirth = dateOfBirth;
            SpouseLastName = spouseLastName;
            SpouseFirstName = spouseFirstName;
            SpouseSocNum = spouseSocNum;
            SpouseDateOfBirth = spouseDateOfBirth;
            Address1 = address1;
            Address2 = address2;
            City = city;
            StateCode = stateCode;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            EmployerName = employerName;
            WorkPhone = workPhone;
            SpouseEmployer = spouseEmployer;
            SpouseWorkPhone = spouseWorkPhone;
            MinorChildName = minorChildName;
            DescriptOfService = descriptOfService;
            OrginialBalance = orginialBalance;
            AmountDue = amountDue;
            LastDateOfService = lastDateOfService;
            DelinquencyDate = delinquencyDate;
            ItemizationDate = itemizationDate;
            AccountNumber = accountNumber;
            AdditionalInformation = additionalInformation;
        }

        public string fullName{get => FullName;}
        public string statecode { get => StateCode;}

        public Output CreateOutput(string noticeCode)
        {
            string phoneext = "";
            string patientName = this.FirstName + " " + this.LastName;
            if (this.MinorChildName != "") {patientName = this.MinorChildName;}
            if(PhoneNumber != "") { phoneext = "CELC"; }
            Output outputstring = new Output(this.AccountNumber, this.AccountNumber,this.LastName,this.FirstName,this.SocSecNum,this.DateOfBirth.ToString("MM/dd/yyyy"), this.Address1, this.Address1,
                                            this.City, this.City,this.StateCode, this.StateCode, this.ZipCode, this.ZipCode, this.PhoneNumber, phoneext, patientName, patientName,
                                            "",this.AmountDue.ToString(), this.OrginialBalance.ToString(), this.DelinquencyDate.ToString("MM/dd/yyyy"), this.LastDateOfService.ToString("MM/dd/yyyy"), "", "HOM11", noticeCode, "T",this.OrginialBalance.ToString(),
                                            this.ItemizationDate.ToString("MM/dd/yyyy"));
            return outputstring;
        }

    }
}
