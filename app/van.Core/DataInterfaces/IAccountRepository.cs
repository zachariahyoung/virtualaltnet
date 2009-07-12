namespace van.Core.DataInterfaces {

   public interface IAccountRepository {
       Account GetRoleForUser(int userId);
    }
}
