using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace hackathon.Application.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchInfoModel
    {
        /// <summary>
        /// TransactionKey
        /// </summary>
        public string TransactionKey { get; set; }

        /// <summary>
        /// SearchRequest編碼的key
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// TF專用的key
        /// </summary>
        public string TfRoutingID { get; set; }

        /// <summary>
        /// 價錢和航班資訊
        /// </summary>
        //public List<FlightInfoView> FlightInfos { get; set; }

        /// <summary>
        /// 注意事項
        /// </summary>
        public List<NoticeInfo> NoticeInfo { get; set; }
    }

    public class NoticeInfo
    {
        /// <summary>區域名稱 ("ImportantNotice":重要公告;"Highlight":中間標明紅底的公告)</summary>
        public string NoticeArea { get; set; }
        ///<summary>注意事項項目</summary>
        public int? NoticeNo { get; set; }

        ///<summary>注意事項內容</summary>
        public string Notice { get; set; }

        ///<summary>字樣的連結網址</summary>
        public List<NoticeUrl> NoticeUrl { get; set; }

        ///<summary>強調的字樣</summary>
        public List<string> NoticeHighlight { get; set; }
    }

    public class NoticeUrl
    {
        ///<summary>要變連結的文字</summary>
        public string UrlStr { get; set; }

        ///<summary>連結網址</summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// 價錢和航班資訊
    /// </summary>
    public class FlightInfoView
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int SeqNo { get; set; }

        /// <summary>
        /// 出票航司
        /// </summary>
        public string ValidatingAirline { get; set; }

        /// <summary>
        /// 出票航司(中文)
        /// </summary>
        public string ValidatingAirlineName { get; set; }

        /// <summary>
        /// 是否為廉價航空
        /// </summary>
        public bool IsLcc { get; set; }

        /// <summary>
        /// 航空公司所屬的航空聯盟
        /// SkyTeam：天合聯盟
        /// StarAlliance：星空聯盟
        /// Oneworld：寰宇一家
        /// </summary>
        public string AirLineGroup
        {
            get
            {
                if ("AF,AM,AR,AZ,CI,CZ,DL,GA,KE,KL,KQ,ME,MF,MU,OK,RO,SU,SV,UX,VN".IndexOf(ValidatingAirline) >= 0)
                {
                    return "SkyTeam";
                }
                else if ("AC,AI,AV,A3,BR,CA,CM,ET,JP,LH,LX,LO,MS,NH,NZ,OS,OU,OX,O6,SA,SK,SN,SQ,TG,TK,TP,UA,ZH".IndexOf(ValidatingAirline) >= 0)
                {
                    return "StarAlliance";
                }
                else if ("AA,AY,BA,CX,IB,JJ,JL,LA,LP,LU,MH,PZ,QF,QR,RJ,S7,UL,XL,4C,4D,KA".IndexOf(ValidatingAirline) >= 0)
                {
                    return "Oneworld";
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 價錢資訊，CI和BR的FareFamily會有多組
        /// </summary>
        public List<FareInfoView> FareInfos { get; set; }

        /// <summary>
        /// 飛行資訊 
        /// 行程資訊(單程一個，來回兩個，多行程三個以上)
        /// </summary>
        public List<ItineraryInfoView> ItineraryInfos { get; set; }

        public string ToCompareItineraryString()
        {
            StringBuilder result = new StringBuilder();
            this.ItineraryInfos.ForEach(itineraryInfo => itineraryInfo.SegmentInfos.ForEach(s =>
            {
                StringBuilder temp = new StringBuilder();
                temp.Append(s.DepAirport).Append("-");
                temp.Append(s.DepDateTime).Append("-");
                temp.Append(s.ArrAirport).Append("-");
                temp.Append(s.ArrDateTime).Append("-");
                temp.Append(s.MarketingAirline).Append("-");
                temp.Append(s.OperatingAirline).Append("-");
                temp.Append(s.FlightNo).Append("-");
                result.Append(temp.ToString()).Append(":");
            }));
            return result.ToString();
        }
    }

    /// <summary>
    /// 行程資訊
    /// </summary>
    public class ItineraryInfoView
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int SeqNo { get; set; }
        /// <summary>
        /// 出發地城市
        /// </summary>
        public string DepCity { get; set; }
        /// <summary>
        /// 出發地城市(中文)
        /// </summary>
        public string DepCityName { get; set; }
        /// <summary>
        /// 出發地機場
        /// </summary>
        public string DepAirport { get; set; }
        /// <summary>
        /// 出發地機場(中文)
        /// </summary>
        public string DepAirportName { get; set; }
        /// <summary>
        /// 目的地城市
        /// </summary>
        public string ArrCity { get; set; }
        /// <summary>
        /// 目的地城市(中文)
        /// </summary>
        public string ArrCityName { get; set; }
        /// <summary>
        /// 目的地機場
        /// </summary>
        public string ArrAirport { get; set; }
        /// <summary>
        /// 目的地機場(中文)
        /// </summary>
        public string ArrAirportName { get; set; }
        /// <summary>
        /// 轉機次數
        /// </summary>
        public int Transfer { get; set; }
        /// <summary>
        /// 起飛時間
        /// </summary>
        public DateTime DepDateTime { get; set; }
        /// <summary>
        /// 起飛時間(小時)
        /// </summary>
        public int DepDateTimeHour { get { return DepDateTime.Hour; } }
        /// <summary>
        /// 降落時間
        /// </summary>
        public DateTime ArrDateTime { get; set; }
        /// <summary>
        /// 降落時間(小時)
        /// </summary>
        public int ArrDateTimeHour { get { return ArrDateTime.Hour; } }
        /// <summary>
        /// 起降時間跨日
        /// </summary>
        public int CrossDay { get; set; }
        /// <summary>
        /// 總飛行時間含轉機時間
        /// </summary>
        public string TotalFlyDuration { get; set; }
        /// <summary>
        /// 航段資訊
        /// </summary>
        public List<SegmentInfoView> SegmentInfos { get; set; }
    }

    /// <summary>
    /// 價錢資訊
    /// </summary>
    public class FareInfoView
    {
        /// <summary>
        /// 對應SearchInfo用
        /// </summary>
        public string FlightFareInfoKey { get; set; }
        /// <summary>
        /// 序號
        /// </summary>
        public int SeqNo { get; set; }
        /// <summary>
        /// GDS
        /// </summary>
        public TicketSupplier TicketSupplier { get; set; }
        /// <summary>
        /// 總含稅價
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 總未含稅價
        /// </summary>
        public decimal TotalPriceWithoutTax { get; set; }
        /// <summary>
        /// 成人含稅單價
        /// </summary>
        public decimal AdtPrice { get; set; }
        /// <summary>
        /// 成人未稅單價
        /// </summary>
        public decimal AdtPriceWithoutTax { get; set; }
        /// <summary>
        /// 成人人數
        /// </summary>
        public int AdtCount { get; set; }
        /// <summary>
        /// 成人可預訂座位數
        /// </summary>
        public int AdtAvailSeats { get; set; }
        /// <summary>
        /// 孩童含稅單價
        /// </summary>
        public decimal ChdPrice { get; set; }
        /// <summary>
        /// 孩童未稅單價
        /// </summary>
        public decimal ChdPriceWithoutTax { get; set; }
        /// <summary>
        /// 孩童人數
        /// </summary>
        public int ChdCount { get; set; }
        /// <summary>
        /// 嬰兒含稅單價
        /// </summary>
        public decimal InfPrice { get; set; }
        /// <summary>
        /// 嬰兒未稅單價
        /// </summary>
        public decimal InfPriceWithoutTax { get; set; }
        /// <summary>
        /// 嬰兒人數
        /// </summary>
        public int InfCount { get; set; }
        /// <summary>
        /// 目前只針對CI和BR處理(中文)
        /// </summary>
        public string FareFamilyName { get; set; }
        /// <summary>
        /// 該票價相關退改規定(寫死的)
        /// </summary>
        public FareInfoDesc FareInfoDesc { get; set; }
        /// <summary>
        /// 艙等以及行李資訊
        /// </summary>
        public List<SegmentDetailInfoView> SegmentDetailInfos { get; set; }
        /// <summary>
        /// FareBasis
        /// </summary>
        public string FareBasis { get; set; }
        /// <summary>
        /// 禮物規則序號(新)
        /// </summary>
        public string GiftNo { get; set; }
        /// <summary>
        /// 加價規則資訊 (SERP進來查詢才會顯示)
        /// </summary>
        public SalesRuleView SalesRule { get; set; }
        /// <summary>
        /// pccCode (SERP進來查詢才會顯示)
        /// </summary>
        public string PccCode { get; set; }
        /// <summary>
        /// 其他渠道的售價金額 (SERP,自由行進來查詢才會顯示)
        /// </summary>
        public Dictionary<string, SalesInfoView> SalesInfos { get; set; }

        public string ToCompareString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.TicketSupplier).Append(":");
            result.Append(this.TotalPrice).Append("-");
            result.Append(this.TotalPriceWithoutTax).Append("-");
            result.Append(this.AdtPrice).Append("-");
            result.Append(this.AdtPriceWithoutTax).Append("-");
            result.Append(this.ChdPrice).Append("-");
            result.Append(this.ChdPriceWithoutTax).Append("-");
            result.Append(this.InfPrice).Append("-");
            result.Append(this.InfPriceWithoutTax).Append("-");
            result.Append(this.FareFamilyName).Append("-");

            this.SegmentDetailInfos.ForEach(s =>
            {
                StringBuilder temp = new StringBuilder();
                temp.Append(s.Cabin).Append("-");
                temp.Append(s.BookingClass).Append("-");
                temp.Append(s.AdtBaggageDesc).Append("-");
                temp.Append(s.ReissueDesc).Append("-");
                temp.Append(s.RefundDesc).Append("-");
                result.Append(temp.ToString()).Append(":");
            });
            return result.ToString();
        }
    }

    public enum TicketSupplier
    {
        [Description("AMADEUS")]
        AMADEUS,
        [Description("SABRE")]
        SABRE,
        [Description("TRAVELFUSION")]
        TRAVELFUSION,
        [Description("TRAVELPORT")]
        TRAVELPORT,
        [Description("LION")]
        LION,
        [Description("BOOK51")]
        BOOK51,
        ALL
    }

    /// <summary>
    /// 航段資訊
    /// </summary>
    public class SegmentInfoView
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int SegSeqNo { get; set; }
        /// <summary>
        /// 出發城市
        /// </summary>
        public string DepCity { get; set; }
        /// <summary>
        /// 出發城市(中文)
        /// </summary>
        public string DepCityName { get; set; }
        /// <summary>
        /// 出發機場
        /// </summary>
        public string DepAirport { get; set; }
        /// <summary>
        /// 出發機場(中文)
        /// </summary>
        public string DepAirportName { get; set; }
        /// <summary>
        /// 出發機場航廈
        /// </summary>
        public string DepTerminal { get; set; }
        /// <summary>
        /// 抵達城市
        /// </summary>
        public string ArrCity { get; set; }
        /// <summary>
        /// 抵達城市(中文)
        /// </summary>
        public string ArrCityName { get; set; }
        /// <summary>
        /// 抵達機場
        /// </summary>
        public string ArrAirport { get; set; }
        /// <summary>
        /// 抵達機場(中文)
        /// </summary>
        public string ArrAirportName { get; set; }
        /// <summary>
        /// 抵達機場航廈
        /// </summary>
        public string ArrTerminal { get; set; }
        /// <summary>
        /// 起飛時間
        /// </summary>
        public DateTime DepDateTime { get; set; }
        /// <summary>
        /// 降落時間
        /// </summary>
        public DateTime ArrDateTime { get; set; }
        /// <summary>
        /// 起降時間跨日
        /// </summary>
        public int CrossDay { get; set; }
        /// <summary>
        /// 上一段行程起降時間跨日
        /// </summary>
        public int CrossDayBefore { get; set; }
        /// <summary>
        /// 班號航司
        /// </summary>
        public string MarketingAirline { get; set; }
        /// <summary>
        /// 班號航司(中文)
        /// </summary>
        public string MarketingAirlineName { get; set; }
        /// <summary>
        /// 實際飛行航司
        /// </summary>
        public string OperatingAirline { get; set; }
        /// <summary>
        /// 實際飛行航司(中文)
        /// </summary>
        public string OperatingAirlineName { get; set; }
        /// <summary>
        /// 航班號碼
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 實際飛行航班號碼
        /// </summary>
        public string OperatingFlightNo { get; set; }
        /// <summary>
        /// 飛行時間
        /// </summary>
        public string FlyDuration { get; set; }
        /// <summary>
        /// 機型
        /// </summary>
        public string AirlineEquipment { get; set; }
        /// <summary>
        /// 轉機時間
        /// </summary>
        public string TransferDuration { get; set; }
        /// <summary>
        /// 中停資訊
        /// </summary>
        public StopInfoView StopInfo { get; set; }
        /// <summary>
        /// 停留或轉機 true = 停留 False = 轉機
        /// </summary>
        public bool? IsStopWait { get; set; }
        /// <summary>
        /// 聯營航司備註
        /// </summary>
        public string OperatingAirlineDesc { get; set; }
    }

    /// <summary>
    /// 航段詳細資訊
    /// </summary>
    public class SegmentDetailInfoView
    {
        /// <summary>
        /// 行程序號
        /// </summary>
        public int SeqNo { get; set; }
        /// <summary>
        /// 航段序號
        /// </summary>
        public int SegSeqNo { get; set; }
        /// <summary>
        /// FareBasis
        /// </summary>
        public string FareBasis { get; set; }
        /// <summary>
        /// 艙等
        /// </summary>
        public string Cabin { get; set; }
        /// <summary>
        /// 艙等(中文)
        /// </summary>
        public string CabinName { get; set; }
        /// <summary>
        /// RBD
        /// </summary>
        public string BookingClass { get; set; }
        /// <summary>
        /// 目前只針對CI和BR處理(中文)
        /// </summary>
        public string FareFamilyName { get; set; }
        /// <summary>
        /// TF的SupplierClass套裝方案名稱
        /// </summary>
        public string LccFareType { get; set; }
        /// <summary>
        /// 成人行李說明
        /// </summary>
        public string AdtBaggageDesc { get; set; }
        /// <summary>
        /// 改票罰則說明
        /// </summary>
        public string ReissueDesc { get; set; }
        /// <summary>
        /// 退票罰則說明
        /// </summary>
        public string RefundDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LegId { get; set; }
    }

    /// <summary>
    /// 該票價相關退改規定
    /// </summary>
    public class FareInfoDesc
    {
        /// <summary>
        /// 改票罰則說明(成人)
        /// </summary>
        public string AdtReissueDesc { get; set; }
        /// <summary>
        /// 退票罰則說明(成人)
        /// </summary>
        public string AdtRefundDesc { get; set; }
        /// <summary>
        /// 選位說明(成人)
        /// </summary>
        public string AdtSeatDesc { get; set; }
        /// <summary>
        /// 艙等說明(成人)
        /// </summary>
        public string AdtClsDesc { get; set; }
    }

    /// <summary>
    /// 中停資訊
    /// </summary>
    public class StopInfoView
    {
        /// <summary>
        /// 中停點
        /// </summary>
        public string StopAirport { get; set; }
        /// <summary>
        /// 中停點中文名稱
        /// </summary>
        public string StopAirportName { get; set; }
        /// <summary>
        /// 抵達中停點時間
        /// </summary>
        public DateTime StopArrDateTime { get; set; }
        /// <summary>
        /// 從中停點出發時間
        /// </summary>
        public DateTime StopDepDateTime { get; set; }
        /// <summary>
        /// 中停時間
        /// </summary>
        public string StopDuration { get; set; }
    }

    /// <summary>
    /// 加價規則 (SERP進來查詢才會顯示)
    /// </summary>
    public class SalesRuleView
    {
        /// <summary>
        /// 基礎加價規規則序號 (SERP進來查詢才會顯示)
        /// </summary>
        public int KpSeqNo { get; set; }
        /// <summary>
        /// 進階加價規則序號 (SERP進來查詢才會顯示)
        /// </summary>
        public int SaleSeqNo { get; set; }
        /// <summary>
        /// PUB/NEGO (SERP進來查詢才會顯示)
        /// </summary>
        public FareType FareType { get; set; }
        /// <summary>
        /// 加價comm (SERP進來查詢才會顯示)
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 大人售價 (SERP進來查詢才會顯示)
        /// </summary>
        public decimal AdtAmt { get; set; }
        /// <summary>
        /// 加價公式 (SERP進來查詢才會顯示)
        /// </summary>
        public string Formula { get; set; }
        /// <summary>
        /// 商品編號 (SERP進來查詢才會顯示)
        /// </summary>
        public string ProdNo { get; set; }
        /// <summary>
        /// 未符合的KP規則 (SERP進來查詢才會顯示)
        /// </summary>
        public List<string> RuleKpNotMatch { get; set; }
        /// <summary>
        /// 符合KP規則 (SERP進來查詢才會顯示)
        /// </summary>
        public List<string> RuleKpMatch { get; set; }
        /// <summary>
        /// 未符合渠道加價規則 (SERP進來查詢才會顯示)
        /// </summary>
        public List<string> RuleChannelNotMatck { get; set; }
        /// <summary>
        /// 符合渠道加價規則 (SERP進來查詢才會顯示)
        /// </summary>
        public List<string> RuleChannelMatch { get; set; }
        /// <summary>
        /// 渠道來源 (SERP進來查詢才會顯示)
        /// </summary>
        public string ChannelSource { get; set; }
    }

    public enum FareType
    {
        PUB,
        NEGO
    }

    /// <summary>
    /// 
    /// </summary>
    public class SalesInfoView
    {
        /// <summary>
        /// 大人售價 (SERP進來查詢才會顯示)
        /// </summary>
        public decimal AdtAmt { get; set; }

        /// <summary>
        /// 加價公式 (SERP進來查詢才會顯示)
        /// </summary>
        public string Formula { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FilterItemView
    {
        /// <summary>
        /// 轉機次數
        /// 0 : 表示直飛(含中停)
        /// 數字 N : 表示轉機 N 次
        /// </summary>
        public HashSet<int> StopNum { get; set; }

        /// <summary>
        /// 航空公司
        /// </summary>
        public List<AirlineFilterView> Airline { get; set; }

        /// <summary>
        /// 出發機場
        /// </summary>
        public List<AirPortFilterView> DepAirport { get; set; }

        /// <summary>
        /// 抵達機場
        /// </summary>
        public List<AirPortFilterView> ArrAirport { get; set; }

        /// <summary>
        /// 轉機點
        /// </summary>
        public List<AirPortFilterView> StopAirport { get; set; }

        /// <summary>
        /// 禮品
        /// </summary>
        public List<HaveGfnoFilter> HaveGfno { get; set; }

        /// <summary>
        /// 是否跨日航班
        /// </summary>
        public List<HaveCrossDayFilter> HaveCrossDay { get; set; }

        /// <summary>
        /// 艙等
        /// </summary>
        public List<CabinFilterView> Cabin { get; set; }

        /// <summary>
        /// 價格區間
        /// </summary>
        public List<PriceRangeFilterView> PriceRange { get; set; }

        /// <summary>
        /// 機場起飛時間
        /// </summary>
        public List<AirPortFilteTimeView> AirPortTime { get; set; }

        /// <summary>
        /// 各行段起訖機場
        /// </summary>
        public List<AirportView> AirPort { get; set; }

    }

    public class HaveGfnoFilter
    {
        /// <summary> 是否有禮品 </summary>
        public bool HaveGfno { get; set; }
    }

    public class HaveCrossDayFilter
    {
        /// <summary>是否跨日航班</summary>
        public bool HaveCrossDay { get; set; }
    }

    public class AirlineFilterView
    {
        /// <summary>
        /// 出票航司
        /// </summary>
        public string ValidatingAirline { get; set; }
        /// <summary>
        /// 出票航司(中文)
        /// </summary>
        public string ValidatingAirlineName { get; set; }
        /// <summary>
        /// 航空公司所屬的航空聯盟
        /// SkyTeam：天合聯盟
        /// StarAlliance：星空聯盟
        /// Oneworld：寰宇一家
        /// </summary>
        public string AirLineGroup
        {
            get
            {
                if ("AF,AM,AR,AZ,CI,CZ,DL,GA,KE,KL,KQ,ME,MF,MU,OK,RO,SU,SV,UX,VN".IndexOf(ValidatingAirline) >= 0)
                {
                    return "SkyTeam";
                }
                else if ("AC,AI,AV,A3,BR,CA,CM,ET,JP,LH,LX,LO,MS,NH,NZ,OS,OU,OX,O6,SA,SK,SN,SQ,TG,TK,TP,UA,ZH".IndexOf(ValidatingAirline) >= 0)
                {
                    return "StarAlliance";
                }
                else if ("AA,AY,BA,CX,IB,JJ,JL,LA,LP,LU,MH,PZ,QF,QR,RJ,S7,UL,XL,4C,4D,KA".IndexOf(ValidatingAirline) >= 0)
                {
                    return "Oneworld";
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// 是否為LCC
        /// </summary>
        public bool IsLcc { get; set; }
    }

    public class AirPortFilterView
    {
        /// <summary>
        /// 機場
        /// </summary>
        public string Airport { get; set; }
        /// <summary>
        /// 機場(中文)
        /// </summary>
        public string AirportName { get; set; }
        /// <summary>
        /// 機場城市
        /// </summary>
        public string AirportCity { get; set; }
    }

    public class CabinFilterView
    {
        /// <summary>
        /// 艙等
        /// </summary>
        public string Cabin { get; set; }
        /// <summary>
        /// 艙等(中文)
        /// </summary>
        public string CabinName { get; set; }
    }

    public class PriceRangeFilterView
    {
        /// <summary>
        /// 價格區間代表識別
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 此區間的最高價錢
        /// </summary>
        public string PriceMax { get; set; }

        /// <summary>
        /// 此區間的最低價錢
        /// </summary>
        public string PriceMin { get; set; }
    }

    public class AirPortFilteTimeView
    {
        /// <summary>
        /// 最早起飛時間(小時)
        /// </summary>
        public int DepHourMin { get; set; }
        /// <summary>
        /// 最晚起飛時間(小時)
        /// </summary>
        public int DepHourMax { get; set; }
    }

    public class AirportView
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int SeqNo { get; set; }
        /// <summary>
        /// 出發機場
        /// </summary>
        public List<AirPortFilterView> DepAirport { get; set; }
        /// <summary>
        /// 抵達機場
        /// </summary>
        public List<AirPortFilterView> ArrAirport { get; set; }
        /// <summary>
        /// 轉機機場
        /// </summary>
        public List<AirPortFilterView> StopAirport { get; set; }
    }
}