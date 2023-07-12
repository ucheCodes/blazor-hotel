namespace AppModels
{
    public class Food
    {
        public string Name { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Desc { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}