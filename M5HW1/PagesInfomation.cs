namespace M5HW1
{
    using Newtonsoft.Json;

    public class PagesInfomation
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; } 

        public Users[] Data { get; set; }

        public string WritePageInfortamion()
        {
            return $"Page: {Page} | PerPage: {PerPage} | Total: {Total} | TotalPages: {TotalPages}";
        }
    }
}
