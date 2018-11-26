using GamesForFree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesForFree.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal GamePointBalance { get; set; }

        public UserViewModel(User userEntity)
        {
            this.Id = userEntity.Id;
            this.FirstName = userEntity.FirstName;
            this.LastName = userEntity.LastName;
            this.UserName = userEntity.UserName;
            this.Email = userEntity.Email;
            this.GamePointBalance = userEntity.GamePointBalance;
        }
    }
}
