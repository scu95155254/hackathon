using System.Collections.Generic;

namespace hackathon.Application.Entities
{
    public class PoiListModel
    {
        public List<Pois> pois { get; set; }

        public class Pois
        {
            public int aid { get; set; }
            public string name { get; set; }
            public string pinyin { get; set; }
            public string tel { get; set; }
            public string address { get; set; }
            public int area_id { get; set; }
            public string region { get; set; }
            public string town { get; set; }
            public string opentime { get; set; }
            public string picture { get; set; }
            public string picdescribe { get; set; }
            public float? px { get; set; }
            public float? py { get; set; }
            public int? class1 { get; set; }
            public int? class2 { get; set; }
            public int? class3 { get; set; }
            public int? weights { get; set; }
        }
    }
}