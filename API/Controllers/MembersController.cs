using System.Security.Claims;
using API.DTO;
using API.Entities;
using API.Extensions;
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

        [HttpPut]
        public async Task<ActionResult> UpdateMember(MemberUpdateDto memberUpdateDto)
        {
            var memberId = User.GetMemberId();

            var member = await memberRepository.GetMemberForUpdate(memberId);
            if (member is null) return BadRequest("Cound not get member");

            member.DisplayName = memberUpdateDto.DisplayName ?? member.DisplayName;
            member.Description = memberUpdateDto.Description ?? member.Description;
            member.City = memberUpdateDto.City ?? member.City;
            member.Country = memberUpdateDto.Country ?? member.Country;

            member.User.DisplayName = memberUpdateDto.DisplayName ?? member.User.DisplayName;

            //memberRepository.Update(member);

            if (await memberRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Failed to update member");
        }
    }


}
