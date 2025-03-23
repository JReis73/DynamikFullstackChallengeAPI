using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DynamikFullstackChallengeAPI.Entities
{
    public class Developer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public required string NickName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        //DateOnly
        public required DateOnly Birth_Date { get; set; }

        public List<Stack>? Stacks { get; set; }
    }
}
