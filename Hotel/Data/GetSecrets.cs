namespace Hotel.Data
{
    public class GetSecrets
    {
        private readonly IConfiguration config;
        public GetSecrets(IConfiguration _config)
        {
            this.config = _config;
        }
        public string OnGet(string id, string key)//Gpt modified
        {
            var section = config.GetSection(id);
            var keyConfig = section.GetValue<string>(key);
            return keyConfig;
        }
        //public string OnGet(string id,string key)
        //{
        //    var apiKey = config.GetSection(id)[key];
        //    var keyConfig = config.GetSection(id).GetValue<string>(key);
        //    return keyConfig;
        //}
    }
}
