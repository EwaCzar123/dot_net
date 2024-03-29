namespace dot_net.Models
{
    public class Character
    {
        public int Id {get;set;}
        public string Name{get;set;} = "Frodo";
        public int HitPoints{get;set;} 
        public int Strength{get;set;}
        public int Defense{get;set;}
        public int Intelligence{get; set;} = 10;
        public RpgClass Class {get;set;} = RpgClass.Knight; 
        public User User { get; set; }
    }
}