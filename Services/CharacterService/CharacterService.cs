using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dot_net.Dtos.Character;
using dot_net.Models;

namespace dot_net.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new  List <Character>{
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
       {
           _mapper = mapper;
       }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            ServiceResponse.Data =  characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                serviceResponse.Data =  characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            ServiceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            int characterIndex = characters.FindIndex(c => c.Id == updateCharacter.Id);
            Character character = _mapper.Map<Character>(updateCharacter);
            if(characterIndex<0){
                characters.Add(character);
            }
            else{
                characters[characterIndex] = character;
            }
            ServiceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return ServiceResponse;
        }
    }
}