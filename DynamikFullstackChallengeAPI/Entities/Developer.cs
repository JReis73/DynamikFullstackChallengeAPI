using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace DynamikFullstackChallengeAPI.Entities
{
    public class Developer
    {
        public int Id { get; set; }

        public required string NickName { get; set; }

        public required string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public required DateTime Birth_Date { get; set; }

        public List<Stack>? Stacks { get; set; }
    }
}
