using DAL.Models;

namespace DAL.Controller
{
    public class DataController
    {
        public void Get()
        {
            Repository<ApplicationUser> repository = new Repository<ApplicationUser>();
            repository.Get(x => x.CustomUserId.Equals(0));
        }
    }
}
