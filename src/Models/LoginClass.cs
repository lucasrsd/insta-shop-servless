// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using System.Collections.Generic;

namespace InstaShop.HastTags.Models.LoginClass
{
    public class Config
    {
        public string csrf_token { get; set; }
        public object viewer { get; set; }
        public object viewerId { get; set; }
    }

    public class Encryption
    {
        public string key_id { get; set; }
        public string public_key { get; set; }
        public string version { get; set; }
    }

    public class Root
    {
        public Config config { get; set; }
        public string country_code { get; set; }
        public string language_code { get; set; }
        public string locale { get; set; }
        public string hostname { get; set; }
        public bool is_whitelisted_crawl_bot { get; set; }
        public string deployment_stage { get; set; }
        public string platform { get; set; }
        public string nonce { get; set; }
        public double mid_pct { get; set; }
        public int cache_schema_version { get; set; }
        public string device_id { get; set; }
        public Encryption encryption { get; set; }
        public bool is_dev { get; set; }
        public object signal_collection_config { get; set; }
        public string rollout_hash { get; set; }
        public string bundle_variant { get; set; }
        public string frontend_env { get; set; }
    }

}