namespace M5HW1
{
    using Newtonsoft.Json;
    public class Customer
    {
        public string Name { get; set; }

        public string Job { get; set; }

        public int? Id { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTime? CreateDate { get; set; }

    }
}
