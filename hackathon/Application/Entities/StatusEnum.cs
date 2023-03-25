namespace hackathon.Application.Entities
{
    /// <summary>
    /// 產品開團狀態
    /// int 值為開團狀態值
    /// EnumDesc 值為狀態名稱
    /// </summary>
    public enum StatusEnum
    {
        /// <summary>
        /// 報名
        /// </summary>
        [EnumDesc("立即報名")]
        Register = 1,

        /// <summary>
        /// 候補
        /// </summary>
        [EnumDesc("候補")]
        Alternate = 2,

        /// <summary>
        /// 額滿
        /// </summary>
        [EnumDesc("額滿")]
        Full = 3,

        /// <summary>
        /// 請洽專員
        /// </summary>
        [EnumDesc("請洽專員")]
        ContactCommissioner = 4,

        /// <summary>
        /// 關團(包含結團、鎖團、已截止)
        /// </summary>
        [EnumDesc("暫不銷售")]
        CloseGroup = 5,

        /// <summary>
        /// 近期上架
        /// </summary>
        [EnumDesc("預定")]
        RecentlyLaunched = 6,

        /// <summary>
        /// 取消
        /// </summary>
        [EnumDesc("暫不銷售")]
        Cancel = 7,

        /// <summary>
        /// 導向路徑
        /// </summary>
        [EnumDesc("我有意願")]
        TransferPat = 8
    }
}