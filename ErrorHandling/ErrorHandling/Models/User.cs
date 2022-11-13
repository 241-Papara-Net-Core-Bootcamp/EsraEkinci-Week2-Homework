using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorHandling.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id column identity oldu.
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserGender { get; set; }
        public DateTime RegisteredDate { get; set; }    


    }
}
