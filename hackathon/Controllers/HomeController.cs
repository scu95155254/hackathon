using hackathon.Application;
using hackathon.Application.Entities;
using hackathon.Application.Handler;
using hackathon.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace hackathon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Member_point()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Lion1()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult area1()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult area2()
        {
            ViewBag.Message = "Your contact page.";
			
			return View();
        }

        public async Task<ActionResult> Member_pointAsync()
        {
            //StringContent content = new StringContent(Data, Encoding.UTF8, "application/json");
            //HttpClient client = httpClientFactory.CreateClient(Constants.InOdataUrl);
            //HttpResponseMessage response = await client.PostAsync("api/V2/MyMessages", content);
            //return await response.Content.ReadAsStringAsync();

            var getToken = await HackathonHttpClientHandler.GetToken();

            #region Tours - 目的地列表

            //動態傳入參數
            var IslandID = new string[] { "1", "3", "9" };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://utours.api.liontravel.com");
            client.DefaultRequestHeaders.Add("Authorization", getToken);
            HttpResponseMessage response = await client.GetAsync($"api/v2/ArrivesGain?Country=TW&IslandID={IslandID.First()}&CultureID=zh_TW&WebCode&CountryCode&ArriveID&TravelType&TourBu");
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var getArrivesGainData = JsonHelper.DeserializeObject<ResponseBase<List<ArrivesGainModel>>>(result).Data;
            #endregion

            #region 數據部 - 得到縣市列表資料使用
            //動態傳入參數 // 美利堅合眾國、瑞士聯邦、中華民國
            var CountryID = new string[] { "22531", "6712", "13323" };

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client1.DefaultRequestHeaders.Add("Authorization", getToken);
            HttpResponseMessage response1 = await client1.GetAsync($"api/v2/AreaList?country_id=13323");
            var result1 = await response1.Content.ReadAsStringAsync();

            if (!response1.IsSuccessStatusCode)
            {
                return null;
            }

            var getAreaListData = JsonHelper.DeserializeObject<ResponseBase<AreaListModel>>(result1).Data;
            #endregion

            #region 數據部 - 取得附近景點
            //動態傳入參數 // 台北市
            var AreaID = getAreaListData.area.Where(w => w.area_id == 13345).Select(s => s.area_id).ToList();

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client2.DefaultRequestHeaders.Add("Authorization", getToken);
            HttpResponseMessage response2 = await client2.GetAsync($"api/v2/PoiList?area_id={AreaID.First()}");
            var result2 = await response2.Content.ReadAsStringAsync();

            if (!response2.IsSuccessStatusCode)
            {
                return null;
            }

            var getPoiListModelData = JsonHelper.DeserializeObject<ResponseBase<PoiListModel>>(result2).Data;
            #endregion

            return View();
        }
    }
}