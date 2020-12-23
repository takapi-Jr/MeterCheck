using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MeterCheck.Models
{
    public class Machine
    {
        [PrimaryKey, AutoIncrement]
        public int MachineId { get; set; }                  // 機種ID
        public string MachineName { get; set; }             // 機種名
        public string ControlId { get; set; }               // 管理番号(各店舗で任意の番号)
        public string CurrentPrizeName { get; set; }        // 現在のプライズ名
        public int LastTimeMeter100 { get; set; }           // 直近チェック時のメーター(100円玉)
        public int LastTimeMeter500 { get; set; }           // 直近チェック時のメーター(500円玉)
        public string LastTimeDiff100 { get; set; }         // 前回チェック時から今日までの差分(100円玉)
        public string LastTimeDiff500 { get; set; }         // 前回チェック時から今日までの差分(500円玉)
        public DateTime LastTimeDate { get; set; }          // 直近のチェック日時
        public int DisplayOrder { get; set; }               // リスト内表示順序
    }
}
