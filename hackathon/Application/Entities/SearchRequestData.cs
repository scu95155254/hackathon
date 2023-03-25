using System;
using System.Collections.Generic;

namespace hackathon.Application.Entities
{
    public class SearchRequestData
    {
        /// <summary>
        /// 搜尋的航段類型
        /// 0=單程
        /// 1=來回
        /// 2=進出點不同
        /// 3=多行程
        /// </summary>
        public int Rtow { get; set; }
        /// <summary>
        /// 艙等型態
        /// 0=不限
        /// 1=經濟
        /// 2=豪華經濟
        /// 3=商務
        /// 4=豪華商務
        /// 5=頭等
        /// 6=豪華頭等
        /// </summary>
        public int ClsType { get; set; }
        /// <summary>
        /// 大人人數
        /// </summary>
        public int Adt { get; set; }
        /// <summary>
        /// 小孩人數
        /// </summary>
        public int Chd { get; set; }
        /// <summary>
        /// 嬰兒人數
        /// </summary>
        public int Inf { get; set; }
        /// <summary>
        /// 只要直飛(不轉機)
        /// 建議:false
        /// </summary>
        public bool NonStop { get; set; }
        /// <summary>
        /// 搜尋的航段行程
        /// </summary>
        public List<SeekDestination> SeekDestinations { get; set; }
        /// <summary>
        /// 指定航空公司代碼
        /// </summary>
        public string PreferAirlines { get; set; }
        /// <summary>
        /// 票編專案號碼
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 0: 不限 1: 只查TF 2: 排除查詢TF
        /// </summary>
        public int SeekLcc { get; set; }
        /// <summary>
        /// B2B供應商代碼
        /// </summary>
        public string AgentCode { get; set; }

        /// <summary>
        /// 查詢單位
        /// </summary>
        public string Prof { get; set; }

        /// <summary>
        /// 檢查所有行程KP
        /// </summary>
        public bool CheckAllKp { get; set; }

        public string Depart1 { get; set; }

        public class SeekDestination
        {
            /// <summary>
            /// 出發地機場代碼
            /// </summary>
            public string DepartAirport { get; set; }
            /// <summary>
            /// 出發地城市代碼
            /// </summary>
            public string DepartCity { get; set; }
            /// <summary>
            /// 出發地國家代碼
            /// </summary>
            public string DepartCountry { get; set; }
            /// <summary>
            /// 出發地國家代碼
            /// </summary>
            public string DepartLine { get; set; }
            /// <summary>
            /// 目的地機場代碼
            /// </summary>
            public string ArriveAirport { get; set; }
            /// <summary>
            /// 目的地城市代碼
            /// </summary>
            public string ArriveCity { get; set; }
            /// <summary>
            /// 目的地國家代碼
            /// </summary>
            public string ArriveCountry { get; set; }
            /// <summary>
            /// 目的地線別代碼
            /// </summary>
            public string ArriveLine { get; set; }
            /// <summary>
            /// 出發日期(yyyyMMdd)
            /// </summary>
            public string DepartDate { get; set; }

            /// <summary>每個飛行航段的資料</summary>
            public List<FlightSegInclude> FlightSegInclude { get; set; }
        }

        public class FlightSegInclude
        {
            /// <summary>出發時間日期(yyyy-MM-dd HH:mm:ss)</summary>
            public DateTime DepartDate { get; set; }
            /// <summary>抵達時間日期(yyyy-MM-dd HH:mm:ss)</summary>
            public DateTime ArriveDate { get; set; }
            /// <summary>出發機場代碼</summary>
            public string DepartAirport { get; set; }
            /// <summary>抵達機場代碼</summary>
            public string ArriveAirport { get; set; }
            /// <summary>航班號碼</summary>
            public string FlightNo { get; set; }
            /// <summary>銷售航空公司</summary>
            public string MarketingAirline { get; set; }
            /// <summary>實際飛行航空公司</summary>
            public string OperatingAirline { get; set; }
            /// <summary>訂位艙等</summary>
            public string ClsBooking { get; set; }
        }
    }
}