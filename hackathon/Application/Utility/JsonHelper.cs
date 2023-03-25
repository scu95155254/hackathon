using System;
using System.Text.Json;

namespace hackathon.Application.Utility
{
    public class JsonHelper
    {
        public static string SerializeObject(object obj)
        {
            try
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null, // 物件命名依照原本命名輸出
                };
                return JsonSerializer.Serialize(obj, jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static T DeserializeObject<T>(string strJson, T anonymousTypeObject = null) where T : class
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strJson)) return null;

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true //忽略大小寫
                };
                return JsonSerializer.Deserialize<T>(strJson, options);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}