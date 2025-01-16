namespace Web_Tabanlı_Final.Data
{
    public class Film
    {
        public int FilmID { get; set; }
        public string FilmAd { get; set; } = string.Empty;
        public string PosterURL { get; set; } = string.Empty;
        public int Yil { get; set; }
        public string Aciklama { get; set; } = string.Empty;
        public ICollection<Yorum>? Yorumlar { get; set; } // Yorumlar ilişkisi

    }
}

