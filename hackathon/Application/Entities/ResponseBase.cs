using Newtonsoft.Json;
using System;

namespace hackathon.Application.Entities
{
    public class ResponseBase<T>
    {
        /// <summary>通用data </summary>
        public T Data { get; set; }
        /// <summary>資料描述 </summary>
        public string rDesc { get; set; }
        /// <summary>資料描述代碼 </summary>
        public string rCode { get; set; }
        /// <summary>Token 到期時間 </summary>
        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TokenExpires { get; set; }
    }
}