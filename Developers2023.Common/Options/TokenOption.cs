using Developers2023.Common.Options.Base;
using System.ComponentModel.DataAnnotations;

namespace Developers2023.Common.Options
{
    public class TokenOption : BaseOption
    {
        [Required]
        public string Issuer { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required, Range(0, 30, ErrorMessage = "Wartość expires musi być z przedziału <0,30>. Sprawdź plik appsettings.token.json")]
        public int Expires { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string LeftKeySecret { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string RightKeySecret { get; set; }
    }
}
