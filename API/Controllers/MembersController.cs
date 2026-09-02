using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MembersController(IMemberRepository memberRepository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Member>>> GetMembers()
        {
            return Ok(await memberRepository.GetMembersAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMembersById(string id)
        {
            var member = await memberRepository.GetMemberByIdAsync(id);
            if (member is null) return NotFound();
            return member;
        }

        [HttpGet("{id}/photos")]
        public async Task<ActionResult<IReadOnlyList<Photo>>> GetPhotoForMembersById(string id)
        {
            var photos = await memberRepository.GetPhotoForMemberAsync(id);
            if (photos is null) return NotFound();
            return Ok(photos);
        }
    }
}
