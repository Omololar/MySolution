using API.Entities;

namespace API.Interface
{
    public interface IMemberInterface
    {
        Member GetMemberById(int memberId);

        List<Member> GetAllMember();

        Member AddNewMember(Member member);
        Member UpdateMember(Member member);
        bool DeleteMember(int memberId);
    }
}
