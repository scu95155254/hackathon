using System;
using System.Collections.Generic;

namespace hackathon.Application.Entities
{
    public class GetItemDetailsModel
    {
        /// <summary>
        /// 產品編碼
        /// </summary>
        public string ETID { get; set; }
        /// <summary>
        /// 牌價幣別
        /// </summary>
        public string BrandCurr { get; set; }
        /// <summary>
        /// 品項序號
        /// </summary>
        public int ItemSeq { get; set; }
        /// <summary>
        /// 牌價
        /// </summary>
        public decimal BrandPrice { get; set; }
        /// <summary>
        /// 售價幣別
        /// </summary>
        public string SaleCurr { get; set; }
        /// <summary>
        /// 最低訂購量
        /// </summary>
        public int LowQty { get; set; }
        /// <summary>
        /// 顯示順序
        /// </summary>
        public int ShowSeq { get; set; }
        /// <summary>
        /// 品項名稱
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 可訂購數量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 扣量狀態
        /// 0：可訂購
        /// 1：下單不扣數量
        /// </summary>
        public bool DeductStatus { get; set; }
        /// <summary>
        /// 供貨狀態
        /// 0：正常
        /// 1：前台顯示補貨中
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 售價
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 售價(同業)
        /// </summary>
        public decimal Price_B { get; set; }
        /// <summary>
        /// 需其他產品資訊代碼
        /// EX ↓ 
        /// 2：歐鐵
        /// 4：租車
        /// 5：水舞間
        /// A, B, C：潛水
        /// </summary>
        //public string ProductInfo { get; set; }
        /// <summary>
        /// 是否需旅客資料
        /// 0：不需要
        /// 1：需要
        /// </summary>
        //public bool IsCustomer { get; set; }
        /// <summary>
        /// 旅客資料格式
        /// </summary>
        //public string CustomerType { get; set; }
        /// <summary>
        /// 是否需護照號碼
        /// 0：不需要護照號碼
        /// 1：需要護照號碼
        /// </summary>
        //public bool IsPassport { get; set; }
        /// <summary>
        /// 是否需台胞證號碼
        /// 0：不需要台胞證號碼
        /// 1：需要台胞證號碼
        /// </summary>
        //public bool IsMTPs { get; set; }
        /// <summary>
        /// 需預計使用日
        /// </summary>
        //public bool IsUseDate { get; set; }
        /// <summary>
        /// 設定使用日期起
        /// </summary>
        //public DateTime? StartDate { get; set; }
        /// <summary>
        /// 設定使用日期迄
        /// </summary>
        //public DateTime? EndDate { get; set; }
        /// <summary>
        /// 設定可使用週期
        /// </summary>
        //public string UseWeek { get; set; }
        /// <summary>
        /// 票券種類與使用方法
        /// ""： 預設值，代表前台不顯示任何文字
        /// 1：實體直接用
        /// 2：實體需兌換
        /// 3：電子不印直接用
        /// 4：電子不印需兌換
        /// 5：電子要印直接用
        /// 6：電子要印需兌換
        /// </summary>
        //public string Instructions { get; set; }
        /// <summary>
        /// 自動展延天數
        /// </summary>
        //public short? AutoExtendDay { get; set; }
        /// <summary>
        /// 上架日期
        /// </summary>
        //public DateTime LaunchDate { get; set; }
        /// <summary>
        /// 設定使用不包含日期
        /// </summary>
        //public List<NotIncludeDateElement> NotIncludeDate { get; set; }
        /// <summary>
        /// 使用單品
        /// </summary>
        public List<OnlyProductElement> OnlyProduct { get; set; }
        /// <summary>
        /// 票種
        /// </summary>
        public TicketTypeElement TicketType { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public FormatElement Format { get; set; }
        /// <summary>
        /// 表演場次20160802,每次只回傳後3個月
        /// </summary>
        //public List<ShowElement> Show { get; set; }
        /// <summary>
        /// 場次
        /// </summary>
        public string Session { get; set; }
        /// <summary>
        /// 備註事項
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 數量倍數
        /// </summary>
        public int Mutiple { get; set; }
        /// <summary>
        /// 是否可以取消訂單
        /// 0：不可以取消
        /// 1：可以取消
        /// 2：需要協議取消
        /// null：未設定
        /// </summary>
        public int? IsModifyOrder { get; set; }

        public GetItemDetailsModel()
        {
            OnlyProduct = new List<OnlyProductElement>();
            TicketType = new TicketTypeElement();
            Format = new FormatElement();
            //NotIncludeDate = new List<NotIncludeDateElement>();
            //Show = new List<ShowElement>();
        }

        public class OnlyProductElement
        {
            /// <summary>
            /// 單品編碼
            /// </summary>
            public string OnlyID { get; set; }
        }

        public class TicketTypeElement
        {
            /// <summary>
            /// 票種名稱
            /// </summary>
            public string TicketName { get; set; }
            /// <summary>
            /// 票種uuid
            /// </summary>
            public Guid TicketUuid { get; set; }
        }

        public class FormatElement
        {
            /// <summary>
            /// 規格ID(GDS Type Uuid 或自建方案分類編碼)
            /// </summary>
            public string FormatID { get; set; }
            /// <summary>
            /// 規格名稱
            /// </summary>
            public string FormatName { get; set; }
            /// <summary>
            /// 場次集合json字串
            /// </summary>
            public string Sessions { get; set; }
        }
    }
}