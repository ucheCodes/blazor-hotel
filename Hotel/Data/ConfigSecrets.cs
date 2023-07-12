namespace Hotel.Data
{
    public class ConfigSecrets
    {
        private readonly IConfiguration config;
        public ConfigSecrets(IConfiguration _config)
        {
            this.config = _config;
        }

        public string OnGet(string id, string key)
        {
            var section = config.GetSection(id);
            var keyConfig = section.GetValue<string>(key);
            return keyConfig;
        }
    }
}
