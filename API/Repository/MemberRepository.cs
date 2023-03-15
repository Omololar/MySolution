using API.Entities;
using API.Interface;

namespace API.Repository
{
    public class MemberRepository : IMemberInterface
    {
        public List<Member> GetAllMember()
        {
            return new List<Member>()
            {
                new Member() {MemberId=100, MemberName="Leye", Gender="Male"},
                 new Member() {MemberId=102,MemberName="Peter", Gender="Male"},
                  new Member() {MemberId=103, MemberName="Temi", Gender="Female"},
            };
        }

        public Member GetMemberById(int memberId)
        {
            return new Member() { MemberId = 103, MemberName = "Temi", Gender = "Female" };
           
        }
    }
}
