using System;

namespace hackathon.Application
{
    public class ExApiTokenResponse
    {
        public string AccessToken { get; set; }
        /// <summary>建立日期</summary>		
        public DateTime CreateDateTime { get; set; }
        /// <summary>到期日期	</summary>	
        public DateTime ExpireDateTime { get; set; }
    }
}