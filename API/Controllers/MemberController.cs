using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberInterface _memberInterface;
        public MemberController(IMemberInterface memberInterface)
        {
            _memberInterface = memberInterface;
        }

        [HttpGet]
        public IEnumerable<Member> GetAll()
        {
            var members = _memberInterface.GetAllMember();

            return members;
        }

        [HttpGet("{id}")]
        public Member Get(int id)
        {
            var member = _memberInterface.GetMemberById(id);
            if (member != null) { return member; }
            return null;
        }

        [HttpPost("CreateNewMember")]
        public Member CreateMember(Member member)
        {
            var createnew = _memberInterface.AddNewMember(member);

            return createnew;
        }

        [HttpPut("edit")]
        public Member EditMember(Member member)
        {
            var edit = _memberInterface.UpdateMember(member);
            return edit;
        }

        [HttpDelete("{id}")]
        public bool DeleteMember(int id)
        {
            var delete = _memberInterface.DeleteMember(id);
            return delete;
        }
    }
}
