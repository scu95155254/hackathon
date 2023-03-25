using System;
using System.Linq;

namespace hackathon.Application.Entities
{
    /// <summary>
    /// 產品開團資訊
    /// </summary>
    public class StatusInfo
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
        public StatusInfo(int status)
        {
            Status = status;
            _SetParameter();
        }

        public StatusInfo(int status, string url)
        {
            Status = status;
            TargetUrl = url;
            _SetParameter();
        }

        public StatusInfo(int status, string url, params param[] paramArray)
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