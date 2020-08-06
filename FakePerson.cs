using System;
using System.Text;

namespace Task3
{
    public class TableUser
    {
        public TableUser () 
        {
            FullData = new StringBuilder();
        }
        public string FullName { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }       
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string  SecondaryAddress { get; set; }
        public string  PhoneNumberFormat { get; set; }
        public StringBuilder FullData { get; set; }

        public void FillStr()
        {
            this.FullData.Append(this.FullName)
                        .Append("; " + this.ZipCode)
                        .Append(", " + this.Country)
                        .Append(", " + this.City)
                        .Append(", " + this.StreetName)
                        .Append(", " + this.BuildingNumber)
                        .Append(", " + this.SecondaryAddress)
                        .Append("; " + this.PhoneNumberFormat);
        }

    }
}