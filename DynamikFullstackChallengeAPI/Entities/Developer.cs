namespace DynamikFullstackChallengeAPI.Entities
{
    public class Developer
    {
        public int Id { get; set; }

        public required string NickName { get; set; }

        public required string Name { get; set; }

        public required DateTime Birth_Date { get; set; }

        public string? Stack { get; set; }
    }
}
