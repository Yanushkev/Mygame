namespace Mygame.Models
{
    public class entity
    {
        public string TypeEntity { get; }
        public int HealthEntity { get; }
        public int SpeedEntity { get; }

        public entity(string nameType, int health, int speed)
        {
            TypeEntity = nameType;
            HealthEntity = health;
            SpeedEntity = speed;
        }
    }
}
