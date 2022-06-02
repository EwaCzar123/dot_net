using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using dot_net.Models;
using dot_net.Services.CharacterService;
using dot_net.Dtos.Character;

namespace dot_net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService){
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        // [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>>GetList(){
            return Ok(await _characterService.GetCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get(int id){
           return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AddCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<AddCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter){
            return Ok(await _characterService.UpdateCharacter(updateCharacter));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id){
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}