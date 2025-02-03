namespace GameStore.Models.Requests
{
    public class AddGameRequest
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Developers { get; set; }
    }
}
