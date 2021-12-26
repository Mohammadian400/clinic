using System;

namespace Domain
{
    public class Login
    {
        public int Id { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}
