using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Almanac.Service.Model
{
    public class Event : TableEntity
    {
        public string Celebration { get; set; }
        public string DressCode { get; set; }
        public string Material { get; set; }
        public string Theme { get; set; }
        public string TypeOfActivity { get; set; }

        public int DaysRemaining => EventDate.Subtract(DateTime.Today).Days;
        public DateTime EventDate =>
            new DateTime(DateTime.Now.Year, Convert.ToDateTime(PartitionKey + " 01, 1900").Month,
                Convert.ToInt32(RowKey)).Date;

        public override string ToString()
        {
            return $"Celebration : {Celebration} on Date : {EventDate}";
        }

       
    }
}
