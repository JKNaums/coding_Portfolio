using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHealthUnited
{
    public class Output
    {
        private string accountNumber;
        private string clientAccountNumber;
        private string lastName;
        private string firstName;
        private string socialSecurityNumber;
        private string dateOfBirth;
        private string address1Line;
        private string address1Window;
        private string cityLine;
        private string cityWindow;
        private string stateLine;
        private string stateWindow;
        private string zipCodeLine;
        private string zipCodeWindow;
        private string homePhoneNumber;
        private string homePhoneExtention;
        private string patientName;
        private string patientNameWindow;
        private string notes1;
        private string accountBalance;
        private string originalBalance;
        private string delinquencyDate;
        private string lastActivityDate;
        private string notes2;
        private string clientNumber;
        private string firstNoticeCode;
        private string itemizationSource;
        private string itemizationBalance;
        private string itemizationDate;

        public Output(string accountNumber, string clientAccountNumber, string lastName, string firstName, string socialSecurityNumber, string dateOfBirth, string address1Line, string address1Window, string cityLine, string cityWindow, string stateLine, string stateWindow, string zipCodeLine, string zipCodeWindow, string homePhoneNumber, string homePhoneExtention, string patientName, string patientNameWindow, string notes1, string accountBalance, string originalBalance, string delinquencyDate, string lastActivityDate, string notes2, string clientNumber, string firstNoticeCode, string itemizationSource, string itemizationBalance, string itemizationDate)
        {
            this.accountNumber = accountNumber;
            this.clientAccountNumber = clientAccountNumber;
            this.lastName = lastName;
            this.firstName = firstName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.dateOfBirth = dateOfBirth;
            this.address1Line = address1Line;
            this.address1Window = address1Window;
            this.cityLine = cityLine;
            this.cityWindow = cityWindow;
            this.stateLine = stateLine;
            this.stateWindow = stateWindow;
            this.zipCodeLine = zipCodeLine;
            this.zipCodeWindow = zipCodeWindow;
            this.homePhoneNumber = homePhoneNumber;
            this.homePhoneExtention = homePhoneExtention;
            this.patientName = patientName;
            this.patientNameWindow = patientNameWindow;
            this.notes1 = notes1;
            this.accountBalance = accountBalance;
            this.originalBalance = originalBalance;
            this.delinquencyDate = delinquencyDate;
            this.lastActivityDate = lastActivityDate;
            this.notes2 = notes2;
            this.clientNumber = clientNumber;
            this.firstNoticeCode = firstNoticeCode;
            this.itemizationSource = itemizationSource;
            this.itemizationBalance = itemizationBalance;
            this.itemizationDate = itemizationDate;
        }
        public string outputTheOutput()
        {
            return $"{accountNumber}\t{accountNumber}\t{lastName}\t{firstName}\t{socialSecurityNumber}\t{dateOfBirth}\t{address1Line}\t{address1Window}\t{cityLine}\t{cityWindow}\t" +
                $"{stateLine}\t{stateWindow}\t{zipCodeLine}\t{zipCodeWindow}\t{homePhoneNumber}\t{homePhoneExtention}\t{patientName}\t{patientNameWindow}\t{notes1}\t{accountBalance}\t" +
                $"{delinquencyDate}\t{delinquencyDate}\t{lastActivityDate}\t{notes2}\t{clientNumber}\t{firstNoticeCode}\t{itemizationSource}\t{itemizationBalance}\t{itemizationDate}";
        }
    }
}
