﻿namespace Web_Tabanlı_Final.Models
{
    public class User
    {
        public int Id { get; set; }
        public string KullanıcıAdı { get; set; } = string.Empty;
        public string Sıfre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

