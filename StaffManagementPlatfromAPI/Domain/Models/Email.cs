﻿namespace StaffManagementPlatfromAPI.Domain.Models
{
    public class Email
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromAddress { get; set; }
    }

}
