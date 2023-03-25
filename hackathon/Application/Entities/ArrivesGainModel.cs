namespace hackathon.Application.Entities
{
    public class ArrivesGainModel
    {
        /// <summary>
        /// 島嶼代碼
        /// </summary>
        public string IslandID { set; get; }
        /// <summary>
        /// 島嶼名稱
        /// </summary>
        public string IslandName { set; get; }
        /// <summary>
        /// 國家代碼
        /// </summary>
        public string CountryCode { set; get; }
        /// <summary>
        /// 國家名稱
        /// </summary>
        public string CountryName { set; get; }
        /// <summary>
        /// 目的地代碼
        /// </summary>
        public string ArriveID { set; get; }
        /// <summary>
        /// 目的地名稱
        /// </summary>
        public string ArriveName { set; get; }
    }
}