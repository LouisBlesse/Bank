using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Bank
{
    
    public class Exchangerate
    {
        public HttpClient client { get; set; }

        public Exchangerate()
        {
            client = new HttpClient();
        }
        
        public async Task<string> Connect(string currencyInitial, string currencyToConvert, int amount)
        {
            string res =
                await client.GetStringAsync(
                    "https://v6.exchangerate-api.com/v6/21408f48185cf792dba37191/pair/" + currencyInitial +  "/"+currencyToConvert + "/"+amount.ToString()
                    );
            return res;
        }
        
        
        public async Task<string> ConnectGetAllCurency()
        {
            string res =
                await client.GetStringAsync(
                    "https://v6.exchangerate-api.com/v6/21408f48185cf792dba37191/codes");
            return res;
        }
        
        public class RootRoot
        {
            public string result { get; set; }
            public string documentation { get; set; }
            public string terms_of_use { get; set; }
            public List<List<string>> supported_codes { get; set; }
        }

        public Root transfert (string json){
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json); 
            return myDeserializedClass;
        }
        
        public RootRoot transfertCurrency (string json){
            RootRoot myDeserializedClass = JsonConvert.DeserializeObject<RootRoot>(json); 
            return myDeserializedClass;
        }
        
        public class Root
        {
            public string result { get; set; }
            public string documentation { get; set; }
            public string terms_of_use { get; set; }
            public int time_last_update_unix { get; set; }
            public string time_last_update_utc { get; set; }
            public int time_next_update_unix { get; set; }
            public string time_next_update_utc { get; set; }
            public string base_code { get; set; }
            public string target_code { get; set; }
            public double conversion_rate { get; set; }
            public int conversion_result { get; set; }
        }
 

    }
}