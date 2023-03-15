using API.Data;
using API.Entities;
using API.Interface;

namespace API.Repository
{
    public class MemberRepository : IMemberInterface
    {
        private readonly APIContext _context;
        public MemberRepository(APIContext context)
        {
            _context = context;
        }

        public Member AddNewMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
            return member;
        }

        public bool DeleteMember(int memberId)
        {
            var isExist = _context.Members.Where(p => p.MemberId == memberId).Any();
            if (isExist)
            {
                _context.Remove(isExist);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Member> GetAllMember()
        {
            var members = _context.Members.ToList();
            if (members.Count > 0)
            {

                return members;
            }
            //throw new Exception("Members not found");
            return null;
        }

        public Member GetMemberById(int memberId)
        {
           var member = _context.Members.Where(p=>p.MemberId == memberId).FirstOrDefault();
            if (member == null)
            {
                throw new Exception($"member with id {memberId} not found");
            }
            return member;
           
        }

        public Member UpdateMember(Member member)
        {
         var isexist = _context.Members.Where(p=>p.MemberId==member.MemberId).FirstOrDefault();
            if (isexist != null)
            {
                isexist.MemberName= member.MemberName;
                isexist.Gender= member.Gender;

                return isexist;
            }
            throw new Exception("Member does not exist");
        }
    }
}
