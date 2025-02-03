namespace GameStore.Models.Requests
{
    public class UpdateGameRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}
