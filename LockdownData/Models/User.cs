using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace LockdownBusinessLogic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}