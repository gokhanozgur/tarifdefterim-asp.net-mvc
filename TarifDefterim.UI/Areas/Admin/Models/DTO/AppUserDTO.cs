using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class AppUserDTO
    {

        public Guid ID { get; set; }

        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string UserName { get; set; }
        
        public string Email { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public Role Role { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public Status Status { get; set; }

    }
}