using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeterCheck.Models
{
    public class Meter
    {
        [PrimaryKey, AutoIncrement]
        public int MeterId { get; set; }                    // メーターID
        public int MachineId { get; set; }                  // 機種ID
        public int Meter100 { get; set; }                   // メーター(100円玉)
        public int Meter500 { get; set; }                   // メーター(500円玉)
        public DateTime Date { get; set; }                  // 日付
    }
}
