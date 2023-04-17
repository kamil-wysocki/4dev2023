using Developers2023.Common.Options.Base;
using System.ComponentModel.DataAnnotations;

namespace Developers2023.Common.Options
{
    public class UserOption : BaseOption
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
