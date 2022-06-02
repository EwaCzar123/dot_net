// using System.Collections.Generic;

using dot_net.Dtos.Character;
using dot_net.Models;

namespace dot_net.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();
        Task<ServiceResponse<GetCharacterDto>>GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}