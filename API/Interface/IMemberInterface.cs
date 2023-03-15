using API.Entities;

namespace API.Interface
{
    public interface IMemberInterface
    {
        Member GetMemberById(int memberId);

        List<Member> GetAllMember();
    }
}
