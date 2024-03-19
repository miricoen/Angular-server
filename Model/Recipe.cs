namespace RecipeServer.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int PreparationTime { get; set; }
        public int Level { get; set; }
        public DateTime DateAdded { get; set; }
        public List<string> Products { get; set; }
        public List<string> Instructions { get; set; }

        public int UserId { get; set; }
        public string Image { get; set; }

    }
}
