namespace Web_Tabanlı_Final.Data
{
    public class Yorum
    {
        public int YorumID { get; set; }
        public string KullanıcıAdı { get; set; } = string.Empty; // Yorum yapan kullanıcı adı
        public string Metin { get; set; } = string.Empty; // Yorumun içeriği
        public int FilmID { get; set; } // Hangi filme ait olduğu
        public Film? Film { get; set; } // Navigation property
    }
}

