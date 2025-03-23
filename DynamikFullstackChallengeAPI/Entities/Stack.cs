using System.ComponentModel.DataAnnotations;

namespace DynamikFullstackChallengeAPI.Entities
{
    public class Stack
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
    }
}
