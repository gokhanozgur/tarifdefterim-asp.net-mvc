using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{

    public enum Role
    {
        [Display(Name = "Belirtilmiyor")]
        None =0,
        [Display(Name = "Üye")]
        Member =1,
        [Display(Name = "Yönetici")]
        Admin =3,
        [Display(Name = "Aşçı")]
        Cook =10
    }

    public class AppUser:CoreEntity
    {        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public Role Role { get; set; }


        public virtual List<Meal> Meals { get; set; }

        public virtual List<RecipeLike> RecipeLikes { get; set; }

        public virtual List<DinnerTableLike> DinnerTableLikes { get; set; }

        public virtual List<FavoriteMeal> FavoriteMeals { get; set; }

        public virtual List<FavoriteDinnerTable> FavoriteDinnerTables { get; set; }

        public virtual List<DinnerTable> DinnerTables { get; set; }

        public virtual List<Comment> Comments { get; set; }


    }
}
