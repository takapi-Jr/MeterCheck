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
        public int LastTimeMeter { get; set; }              // 直近チェック時のメーター
        public string LastTimeDiff { get; set; }            // 前回チェック時から今日までの差分
        public DateTime LastTimeDate { get; set; }          // 直近のチェック日時
        public int DisplayOrder { get; set; }               // 表示順序
    }
}
