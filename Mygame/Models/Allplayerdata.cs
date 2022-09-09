namespace Mygame.Models
{
    public class Allplayerdata
    {
        public List<entity> Allcars { get; set; }
        public language languageplayer { get; set; } 
        
        public string Playername { get; set; }
        public string Playermap { get; set; }
        public string Playercar { get; set; }

        public int Playcar { get; set; }
    }
}
