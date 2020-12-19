using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeterCheck.Models
{
    public class Meter
    {
        [PrimaryKey, AutoIncrement]
        public int MeterId { get; set; }            // メーターID
        public int MachineId { get; set; }          // 機種ID
        public int MeterAll { get; set; }           // メーター
        public DateTime Date { get; set; }          // 日付
    }
}
