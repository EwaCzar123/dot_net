using dot_net.Models;
namespace dot_net.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name{get;set;} = "Frodo";
        public int HitPoints{get;set;} 
        public int Strength{get;set;}
        public int Defense{get;set;}
        public int Intelligence{get; set;} = 10;
        public RpgClass Class {get;set;} = RpgClass.Knight; 
    }
}