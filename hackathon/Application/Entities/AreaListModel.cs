using System.Collections.Generic;

namespace hackathon.Application.Entities
{
    public class AreaListModel
    {
        public List<Areas> area { get; set; }

        public class Areas
        {
            public int area_id { get; set; }
            public string area_name { get; set; }
            public string area_isocode { get; set; }
        }
    }
}