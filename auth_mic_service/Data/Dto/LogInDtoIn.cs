using auth_mic_service.Extensions;
using System.ComponentModel.DataAnnotations;

namespace auth_mic_service.Data.Dto
{
    public class LogInDtoIn
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        public override string ToString()
        {
            return $"{Username} - {(Password.IsNullOrEmpty() ? "NULL" : "HIDDEN")}";
        }
    }
}
