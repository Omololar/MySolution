using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberWebApplication.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime CreationDate { get; set; }
    }
}