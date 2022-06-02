using AutoMapper;
using dot_net.Models;
using dot_net.Dtos.Character;

namespace dot_net
{
    public class MapperProfile: Profile
    {
        public MapperProfile(){
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
     
    }
}