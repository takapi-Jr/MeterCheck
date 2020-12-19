using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeterCheck.Models
{
    public class PrizeReplace
    {
        [PrimaryKey, AutoIncrement]
        public int ReplaceId { get; set; }              // 入れ替えID
        public int MachineId { get; set; }              // 機種ID
        public string PrizeName { get; set; }           // プライズ名
        public DateTime StartDate { get; set; }         // 開始日時        
        public int PricePerTime { get; set; }           // 1回あたりの価格
        public string Memo { get; set; }                // メモ
    }
}
