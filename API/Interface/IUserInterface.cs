using API.Entities;

namespace API.Interface
{
    public interface IUserInterface
    {
        //getalluser
        Task<List<User>> GetAllUsers();
        //getsingleuser
        //adduser
        //edituser
        //deleteuser
    }
}
