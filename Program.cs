// See https://aka.ms/new-console-template for more information
using ExcelDataReader;
using HomeHealthUnited;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text;
using System.IO.Enumeration;

const string filepath = "J:\\My_Documents\\Jeremy\\Projects\\C#\\HomeHealthUnited\\";
string filename = "TRISTATE SPREADSHEET BLANK. ADAMLA REG COLL 92624_fixed.xlsx";

string fileDate = DateTime.Now.ToShortDateString();
List<Account> data = new List<Account>();
Dictionary<string, Consumer> consumers = new Dictionary<string, Consumer>();
List<Output> outputData = new List<Output>();
string fullpath = filepath + filename;
using (var stream = File.Open(fullpath, FileMode.Open, FileAccess.Read))
{
    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    using (var reader = ExcelReaderFactory.CreateReader(stream))
    {
        var itemsInLine = reader.FieldCount;
        reader.Read();
        do
        {
            while (reader.Read())
            {
                string lname = reader.GetString(0);
                if (lname == null) { continue; }
                string fname = reader.GetString(1);
                string ssn = "";
                if (reader.GetValue(2) != null) { ssn = reader.GetValue(2).ToString(); }
                DateTime dob = new DateTime(1900, 1, 1);
                if (reader.GetValue(3) != null) { dob = reader.GetDateTime(3); }
                string spouseln = reader.GetString(4);
                string spousefn = reader.GetString(5);
                string spousessn = reader.GetString(6);
                string spousedob = reader.GetString(7);
                string address1 = reader.GetString(8);
                string city = reader.GetString(9);
                string state = reader.GetString(10);
                string zipcode = "";
                if (reader.GetValue(11) != null) { zipcode = reader.GetValue(11).ToString(); }
                string homePhone = "";
                if (reader.GetValue(12) != null) { homePhone = reader.GetValue(12).ToString(); }
                string employer = reader.GetString(13);
                string workphone = "";
                if (reader.GetValue(14) != null) { workphone = reader.GetValue(14).ToString(); }
                string spouseemployer = reader.GetString(15);
                string spouseworkphone = "";
                if (reader.GetValue(16) != null) { spouseworkphone = reader.GetValue(16).ToString(); }
                string minorchildname = reader.GetString(17);
                string discriptionofservice = reader.GetString(18);
                double orignialBalance = 0;
                if (reader.GetValue(19) != null) { orignialBalance = reader.GetDouble(19); }
                double amountDue = 0;
                if (reader.GetValue(20) != null) { amountDue = reader.GetDouble(20); }
                DateTime lastDateOfService = new DateTime(1900, 1, 1);
                if (reader.GetValue(21) != null) { lastDateOfService = reader.GetDateTime(21); }
                DateTime delinquencyDate = new DateTime(1900,1,1);
                if (reader.GetValue(22) != null) { delinquencyDate = reader.GetDateTime(22); }
                DateTime itemizationDate = new DateTime(1900, 1, 1);
                if (reader.GetValue(23) != null) { itemizationDate = reader.GetDateTime(23); }
                string accountNumber = "";
                if (reader.GetValue(24) != null) { accountNumber = reader.GetValue(24).ToString(); }
                string additionalinformation = reader.GetString(25);

                Account placeHolder = new Account(lname, fname, ssn, dob, spouseln, spousefn, spousessn, spousedob, address1, 
                                                  "", city, state, zipcode, homePhone, employer, workphone, spouseemployer, 
                                                  spouseworkphone, minorchildname, discriptionofservice, orignialBalance, amountDue, 
                                                  lastDateOfService, delinquencyDate, itemizationDate, accountNumber, 
                                                  additionalinformation);
                data.Add(placeHolder);

                string dictKey = fname + "_" + lname;
                if (consumers.ContainsKey(dictKey)) 
                { 
                    consumers[dictKey].addAccount(amountDue); 
                } 
                else
                {
                    consumers.Add( dictKey, new Consumer() );
                    consumers[dictKey].addAccount(amountDue);
                }
                //for (int i=0; i<itemsInLine; i++)
                //{
                //    string itemValue;
                //    if(reader.GetValue(i) == null)
                //    {
                //        itemValue = "";
                //    }
                //    else
                //    {
                //        itemValue = reader.GetValue(i).ToString();
                //    }

                //    Console.WriteLine(itemValue);
                //}

                //reader.GetDouble(0);
                //Console.WriteLine(consumers[dictKey].ACCOUNTS.ToString()+" "+ consumers[dictKey].TOTALBALANCE.ToString());
                //foreach(KeyValuePair<string, Consumer> pair in consumers )
                //{
                //    Console.WriteLine(pair.Key, consumers[pair.Key].ACCOUNTS, "Is this the end?");
                //}
            
            }
        } while(reader.NextResult());

        //var result = reader.AsDataSet();
    }
}
foreach(Account account in data)
{
    string noticeCode = "VAL1";
    double ConsumerTotal = consumers[account.fullName].TOTALBALANCE;
    if(account.statecode == "NV") { noticeCode = ""; }
    else if (consumers[account.fullName].TOTALBALANCE > 10)
    {
        if (consumers[account.fullName].ACCOUNTS > 1) { noticeCode = "VAL2"; }
    }
    else { noticeCode = ""; }
    outputData.Add(account.CreateOutput(noticeCode));

}
string fileHeader = "ACCT\tCLA#\tLN\tFN\tSSN\tDOB\tAD1\tADATA:AS4\tCTY\tADATA:AS6\tST\tADATA:AS7\tZIP\tADATA:AS8\tHPH\tHPHX\tPATIENT\tADATA:AC10\tNOTES\tBAL:PRIN\tADATA:AC13\tDOD\tLAD\tNOTES\tCRED#\tFNTC\tITEMSRC\tITEMBAL\tITEMDATE\n";
StringBuilder stringBuilder = new StringBuilder();
stringBuilder.Append(fileHeader);
foreach(Output output in outputData)
{
    //string returnvalue = 
    stringBuilder.Append(output.outputTheOutput());
    stringBuilder.Append("\n");

}


string outputFilePath = @"J:\My_Documents\Jeremy\Projects\C#\HomeHealthUnited\";
string outputFileName = $"HOM11_{fileDate.Replace("/","")}.txt";
string path = $"{outputFilePath}{outputFileName}";
File.WriteAllText(path, stringBuilder.ToString());
Console.WriteLine("Hello, World!");