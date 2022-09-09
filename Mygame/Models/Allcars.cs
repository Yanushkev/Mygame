namespace Mygame.Models
{
    public class Allcars
    {
        public List<entity> Allcar { get; }

        public Allcars(string field)
        {
            Allcar = new List<entity>();
            Allcar.Add(new entity("Zaz", 4, 40));
            Allcar.Add(new entity("vepr", 5, 30));
            Allcar.Add(new entity("Lada 2106", 3, 60));
            Allcar.Add(new entity("fiat", 2, 80));
            Allcar.Add(new entity("lamborghini", 1, 100));
        }
    }
}
