namespace HumanResources.Entities
{
    using Newtonsoft.Json;

    public class Role
    {
        [JsonProperty("roleId")]
        public int Id { get; set; }

        [JsonProperty("roleName")]
        public string Name { get; set; }

        [JsonProperty("roleDescription")]
        public string Description { get; set; }
    }
}