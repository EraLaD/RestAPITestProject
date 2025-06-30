using System.Text.Json.Serialization;

namespace RestAPITestProject.apiresponses
{

    public class APIResponseObject
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public DataInfoApiResponse? data { get; set; }
        public string? createdAt { get; set; }
        public string? message { get; set; }
    }

    public class DataInfoApiResponse
    {
        public string? color { get; set; }
        public string? capacity { get; set; }
        public int? capacityGB { get; set; }
        public float? price { get; set; }
        public string? generation { get; set; }
        public int? year { get; set; }
        public string? CPUmodel { get; set; }
        public string? Harddisksize { get; set; }
        public string? StrapColour { get; set; }
        public string? CaseSize { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public string? Capacity { get; set; }
        public float? Screensize { get; set; }
        public string? Generation { get; set; }
        public string? Price { get; set; }
        
    }

}
