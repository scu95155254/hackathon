using System;

namespace hackathon.Application
{
    public class ExApiResponse<T>
    {
        ///<summary>回傳該api 的資料<summary>
        public T Data { set; get; }
        ///<summary>錯誤說明<summary>
        public string rDesc { set; get; }
        ///<summary>錯誤代碼，請參閱：ExAPI rCode表<summary>
        public string rCode { set; get; }
        ///<summary>Access Token 到期時間，每次成功呼叫會自動延長<summary>
        public DateTime TokenExpires { set; get; }

        /// <summary> 串連前中後操作 </summary>
        public string TraceId { set; get; }

        // <summary> 延續Token使用 </summary>
        public string Token { set; get; }
    }
}