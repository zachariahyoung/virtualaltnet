namespace van.Core.DataInterfaces
{
    public interface IUserRepository {
        User GetByUserName(string username);
        
    }
}