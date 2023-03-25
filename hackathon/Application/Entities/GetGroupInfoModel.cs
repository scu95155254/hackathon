using System;
using System.Collections.Generic;
using System.Linq;

namespace hackathon.Application.Entities
{
    public class GetGroupInfoModel
    {
        /// <summary>
        /// 國家別
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 行程代碼
        /// </summary>
        public string TourID { get; set; }

        /// <summary>
        /// 行程名稱
        /// </summary>
        public string TourName { get; set; }

        /// <summary>
        /// 標準團名ID
        /// </summary>
        public Guid NormGroupID { get; set; }

        /// <summary>
        /// 行程天數
        /// </summary>
        public int TourDays { get; set; }

        /// <summary>
        /// 出發日期
        /// </summary>
        public string GoDate { get; set; }

        /// <summary>
        /// 回程日期
        /// </summary>
        public string BackDate { get; set; }

        /// <summary>
        /// 報名截止日
        /// </summary>
        public string CapturesDate { get; set; }

        /// <summary>
        /// 是否夜未眠
        /// </summary>
        public bool IsSleepless { get; set; }

        /// <summary>
        /// 產品開團狀態：1：報名、2：候補、3：額滿、4：請洽專員、5：關團(包含結團、鎖團、已截止)、6：近期上架、7：取消、99：非線9團
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 產品開團資訊
        /// </summary>
        //public StatusInfoModel StatusInfo { get; set; }

        /// <summary>
        /// 總團位數
        /// </summary>
        public int TotalSeats { get; set; }

        /// <summary>
        /// 可賣位數
        /// </summary>
        public int QuotaSeats { get; set; }

        /// <summary>
        /// 可後補位數
        /// </summary>
        public int SpareSeats { get; set; }

        /// <summary>
        /// 是否為預定
        /// </summary>
        public bool IsBooked { get; set; }

        /// <summary>
        /// 是否為保證出團
        /// </summary>
        public bool IsEnsureGroup { get; set; }

        /// <summary>
        /// 是否為國外(true)、國內(false)
        /// </summary>
        public bool IsForeign { get; set; }

        /// <summary>
        /// 旅遊型態(1:團體、2:團體自由行)
        /// </summary>
        public int TravelType { get; set; }

        /// <summary>
        /// 主題旅遊代碼
        /// </summary>
        public List<string> ThemeID { get; set; }

        /// <summary>
        /// 年齡基準日
        /// </summary>
        public string AgeCalculation { get; set; }

        /// <summary>
        /// 大人最低直售價
        /// </summary>
        public decimal? StraightLowestPrice { get; set; }

        /// <summary>
        /// 大人最低批售價
        /// </summary>
        public decimal? IndustryLowestPrice { get; set; }

        /// <summary>
        /// 大人最低企業價
        /// </summary>
        public decimal? EnterLowestprise { get; set; }

        /// <summary>
        /// 會員限購
        /// </summary>
        public bool? IsVip { get; set; }

        /// <summary>
        /// 會員限購原價
        /// </summary>
        public decimal? VipOrigPrice { get; set; }

        /// <summary>
        /// 目的地代碼(多筆請用逗點區隔)
        /// </summary>
        public string ArriveID { get; set; }

        /// <summary>
        /// 同一天有兩個團
        /// </summary>
        public bool? MutiGroup { get; set; }

        /// <summary>
        /// 團控集團
        /// </summary>
        public string TourBu { get; set; }

        /// <summary>
        /// 有位有繳訂金
        /// </summary>
        public int KKSeats { get; set; }

        /// <summary>
        /// HL 數量
        /// </summary>
        public int HLSeats { get; set; }

        /// <summary>
        /// 已報名
        /// </summary>
        public int HKSeats { get; set; }

        /// <summary>
        /// 保留位數
        /// </summary>
        public int KeepSeats { get; set; }

        /// <summary>
        /// 候補有繳訂金位數
        /// </summary>
        public int OBSeats { get; set; }

        /// <summary>
        /// 標準團名
        /// </summary>
        public string NormGroup { get; set; }

        /// <summary>
        /// 標準團圖片(中圖)
        /// </summary>
        public string NormGroupImgM { get; set; }

        /// <summary>
        /// 團號(後面加「-開團公司」)
        /// </summary>
        public string GroupID { get; set; }

        /// <summary>
        /// 實際人數(含領隊)
        /// </summary>
        public int ActualSeats { get; set; }

        /// <summary>
        /// 候補人數
        /// </summary>
        public int WaitSeats { get; set; }

        /// <summary>
        /// 標準團名等級代碼
        /// </summary>
        public string LevelID { get; set; }

        /// <summary>
        /// 轉需求單網址
        /// </summary>
        public string TargetUrl { get; set; }

        /// <summary>
        /// 是否開啟抵扣碼
        /// </summary>
        public bool UseDiscount { get; set; }

        /// <summary>
        /// 是否為郵輪團
        /// </summary>
        public bool IsCruise { get; set; }

        /// <summary>
        /// 貨幣代碼 (ISO 4217)
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 標籤清單
        /// </summary>
        public List<TagsModel> TagList { get; set; }

        /// <summary>
        /// 旅遊型態清單
        /// </summary>
        public List<TripTypeModel> TripTypeList { get; set; }

        /// <summary>
        /// 出發城市
        /// </summary>
        public List<StartFromCityModel> StartFromCityList { get; set; }

        public class TagsModel
        {
            /// <summary>
            /// 標籤名稱    
            /// </summary>
            public string TagName { get; set; }

            /// <summary>
            /// 標籤排序
            /// </summary>
            public int TagSort { get; set; }
        }

        /// <summary>
        /// 標準團名有的旅遊型態
        /// </summary>
        public class TripTypeModel
        {
            /// <summary>
            /// 內容
            /// </summary>
            public string TypeName { set; get; }
            /// <summary>
            /// 代碼
            /// </summary>
            public string TypeCode { set; get; }
            /// <summary>
            /// 關聯主題代碼
            /// </summary>
            public string RelatedThemeID { set; get; }
        }

        public class StartFromCityModel
        {
            /// <summary>
            /// 城市名稱  
            /// </summary>
            public string CityName { get; set; }

            /// <summary>
            /// 城市代碼
            /// </summary>
            public string CityCode { get; set; }
        }

        /// <summary>
        /// 產品開團資訊
        /// </summary>
        public class StatusInfoModel
        {
            #region - Definitions -
            /// <summary>
            /// 導向類型
            /// </summary>
            public enum EnumType
            {
                /// <summary>
                /// 可報名
                /// </summary>
                Register = 1,

                /// <summary>
                /// 不可報名
                /// </summary>
                NoRegister = 2,

                /// <summary>
                /// 轉移路徑
                /// </summary>
                TransferPath = 3
            }

            /// <summary>
            /// 參數
            /// </summary>
            public class param
            {
                /// <summary>
                /// 參數名
                /// </summary>
                public string Key { get; set; }

                /// <summary>
                /// 參數值
                /// </summary>
                public string Value { get; set; }
            }
            #endregion

            #region - Constructor -
            public StatusInfoModel(int status)
            {
                Status = status;
                _SetParameter();
            }

            public StatusInfoModel(int status, string url)
            {
                Status = status;
                TargetUrl = url;
                _SetParameter();
            }

            public StatusInfoModel(int status, string url, params param[] paramArray)
            {
                Status = status;
                TargetUrl = url;

                if (string.IsNullOrEmpty(url) == false &&
                    paramArray != null &&
                    paramArray.Any())
                {
                    TargetUrl = url + "?" + string.Join("&", paramArray.Select(s => $"{s.Key}={s.Value}"));
                }

                _SetParameter();
            }
            #endregion

            #region - Property -
            /// <summary>
            /// 狀態
            /// </summary>
            public int Status { get; set; }

            /// <summary>
            /// 狀態名稱
            /// </summary>
            public string StatusName { get; set; }

            /// <summary>
            /// 導向類型
            /// </summary>
            public int Type { get; set; }

            /// <summary>
            /// 指定路徑
            /// </summary>
            public string TargetUrl { get; set; }
            #endregion

            #region - 設定參數 -
            /// <summary>
            /// 設定參數
            /// </summary>
            private void _SetParameter()
            {
                _SetType();
                _SetStatusName();
            }
            #endregion

            #region - 設定狀態名稱 -
            /// <summary>
            /// 設定狀態名稱
            /// </summary>
            private void _SetStatusName()
            {
                var statusEnumDictionary = (Enum.GetValues(typeof(StatusEnum)).Cast<StatusEnum>()).ToDictionary(k => (int)k, v => v.GetDesc());

                if (statusEnumDictionary.ContainsKey(Status))
                {
                    StatusName = statusEnumDictionary[Status];
                }
            }
            #endregion

            #region - 設定導向類型 -
            /// <summary>
            /// 設定導向類型
            /// </summary>
            private void _SetType()
            {
                Type = (int)EnumType.NoRegister;

                if (Status == (int)StatusEnum.Register ||
                    Status == (int)StatusEnum.Alternate ||
                    Status == (int)StatusEnum.RecentlyLaunched)
                {
                    Type = (int)EnumType.Register;
                }

                if (string.IsNullOrWhiteSpace(TargetUrl) == false)
                {
                    Type = (int)EnumType.TransferPath;
                }
            }
            #endregion
        }
    }
}