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
    }
}
