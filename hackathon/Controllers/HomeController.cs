using hackathon.Application;
using hackathon.Application.Entities;
using hackathon.Application.Handler;
using hackathon.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<ActionResult> area2()
        {
            ViewBag.Message = "Your contact page.";

            #region 數據部 - 得到縣市列表資料使用
            var getToken1 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 美利堅合眾國、瑞士聯邦、中華民國
            var CountryID = new string[] { "22531", "6712", "13323" };

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client1.DefaultRequestHeaders.Add("Authorization", getToken1);
            HttpResponseMessage response1 = await client1.GetAsync($"api/v2/AreaList?country_id=13323");
            var result1 = await response1.Content.ReadAsStringAsync();

            if (!response1.IsSuccessStatusCode)
            {
                return null;
            }

            var getAreaListData = JsonHelper.DeserializeObject<ResponseBase<AreaListModel>>(result1).Data;
            #endregion

            #region 數據部 - 取得附近景點
            var getToken2 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 台北市
            var AreaID = getAreaListData.area.Where(w => w.area_id == 13345).Select(s => s.area_id).ToList();

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client2.DefaultRequestHeaders.Add("Authorization", getToken2);
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

        [HttpGet]
        public async Task<JsonResult> CityData()
        {
            #region 數據部 - 得到縣市列表資料使用
            var getToken1 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 美利堅合眾國、瑞士聯邦、中華民國
            var CountryID = new string[] { "22531", "6712", "13323" };

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client1.DefaultRequestHeaders.Add("Authorization", getToken1);
            HttpResponseMessage response1 = await client1.GetAsync($"api/v2/AreaList?country_id=13323");
            var result1 = await response1.Content.ReadAsStringAsync();

            if (!response1.IsSuccessStatusCode)
            {
                return null;
            }

            var getAreaListData = JsonHelper.DeserializeObject<ResponseBase<AreaListModel>>(result1).Data;
            #endregion

            #region 數據部 - 取得附近景點
            var getToken2 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 台北市
            var AreaID = getAreaListData.area.Where(w => w.area_id == 13345).Select(s => s.area_id).ToList();

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client2.DefaultRequestHeaders.Add("Authorization", getToken2);
            HttpResponseMessage response2 = await client2.GetAsync($"api/v2/PoiList?area_id={AreaID.First()}");
            var result2 = await response2.Content.ReadAsStringAsync();

            if (!response2.IsSuccessStatusCode)
            {
                return null;
            }

            var getPoiListModelData = JsonHelper.DeserializeObject<ResponseBase<PoiListModel>>(result2).Data;
            #endregion

            return Json(getPoiListModelData.pois.First().name, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Member_pointAsync()
        {


            #region Tours - 目的地列表
            var getToken = await HackathonHttpClientHandler.GetToken();

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
            var getToken1 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 美利堅合眾國、瑞士聯邦、中華民國
            var CountryID = new string[] { "22531", "6712", "13323" };

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client1.DefaultRequestHeaders.Add("Authorization", getToken1);
            HttpResponseMessage response1 = await client1.GetAsync($"api/v2/AreaList?country_id=13323");
            var result1 = await response1.Content.ReadAsStringAsync();

            if (!response1.IsSuccessStatusCode)
            {
                return null;
            }

            var getAreaListData = JsonHelper.DeserializeObject<ResponseBase<AreaListModel>>(result1).Data;
            #endregion

            #region 數據部 - 取得附近景點
            var getToken2 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 台北市
            var AreaID = getAreaListData.area.Where(w => w.area_id == 13345).Select(s => s.area_id).ToList();

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("https://uds.api.liontravel.com");
            client2.DefaultRequestHeaders.Add("Authorization", getToken2);
            HttpResponseMessage response2 = await client2.GetAsync($"api/v2/PoiList?area_id={AreaID.First()}");
            var result2 = await response2.Content.ReadAsStringAsync();

            if (!response2.IsSuccessStatusCode)
            {
                return null;
            }

            var getPoiListModelData = JsonHelper.DeserializeObject<ResponseBase<PoiListModel>>(result2).Data;
            #endregion

            #region ETKT_22_取得品項明細
            var getToken3 = await HackathonHttpClientHandler.GetToken();

            //動態傳入參數 // 產品編號
            var ETID = "195004";

            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri("https://uetkt.api.liontravel.com");
            client3.DefaultRequestHeaders.Add("Authorization", getToken3);
            HttpResponseMessage response3 = await client3.GetAsync($"/api/V2/GetItemDetails?ETID={ETID}&WebCountryID=&WebCityID=&Lang=");
            var result3 = await response3.Content.ReadAsStringAsync();

            if (!response3.IsSuccessStatusCode)
            {
                return null;
            }

            var getGetItemDetailsModelData = JsonHelper.DeserializeObject<ResponseBase<List<GetItemDetailsModel>>>(result3).Data;
            #endregion

            #region Tours_團體資訊
            var getToken4 = await HackathonHttpClientHandler.GetToken();

            HttpClient client4 = new HttpClient();
            client4.BaseAddress = new Uri("https://utours.api.liontravel.com");
            client4.DefaultRequestHeaders.Add("Authorization", getToken4);
            HttpResponseMessage response4 = await client4.GetAsync($"/api/v2/GroupInfo?GroupID=23EU413-T&WebCode=B2C&IsPreview=false&TourBu=T&Agent&Language=ZH_TW");
            var result4 = await response4.Content.ReadAsStringAsync();

            if (!response4.IsSuccessStatusCode)
            {
                return null;
            }

            var getGetGroupInfoModelData = JsonHelper.DeserializeObject<ResponseBase<GetGroupInfoModel>>(result4).Data;
            #endregion

            #region TKT7_機票搜尋
            var getToken5 = await HackathonHttpClientHandler.GetToken();

            SearchRequestData searchRequestData = new SearchRequestData
            {
                Rtow = 1,
                ClsType = 1,
                Adt = 1,
                Chd = 0,
                Inf = 0,
                PreferAirlines = "",
                SeekLcc = 0,
                Depart1="TPE",
                //Arrive1="",
                //NoTrans=true,
                NonStop = true,
                SeekDestinations = new List<SearchRequestData.SeekDestination>
                {
                    new SearchRequestData.SeekDestination
                    {
                        DepartDate="2023-06-01",
                        DepartCity="TPE",
                        DepartAirport="TPE",
                        DepartCountry= "TW",
                        ArriveCity= "TYO",
                        ArriveAirport= "",
                        ArriveCountry= "JP"
                    },
                    new SearchRequestData.SeekDestination
                    {
                        DepartDate="2023-06-07",
                        DepartCity= "TYO",
                        DepartAirport= "",
                        DepartCountry= "JP",
                        ArriveCity= "TPE",
                        ArriveAirport= "TPE",
                        ArriveCountry= "TW"
                    }
                }
            };

            StringContent content = new StringContent(JsonHelper.SerializeObject(searchRequestData), Encoding.UTF8, "application/json");
            HttpClient client5 = new HttpClient();
            client5.BaseAddress = new Uri("https://utkt.api.liontravel.com");
            client5.DefaultRequestHeaders.Add("Authorization", getToken5);
            HttpResponseMessage response5 = await client5.PostAsync("api/v3/searchinfo", content);
            var result5 = await response5.Content.ReadAsStringAsync();

            if (!response5.IsSuccessStatusCode)
            {
                return null;
            }

            var getSearchInfoModelData = JsonHelper.DeserializeObject<ResponseBase<SearchInfoModel>>(result5).Data;
            #endregion

            return View();
        }
        public ActionResult area3()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}