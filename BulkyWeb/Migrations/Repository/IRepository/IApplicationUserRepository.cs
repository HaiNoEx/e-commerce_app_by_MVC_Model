using BulkyWeb.Models;

namespace BulkyWeb.Migrations.Repository.IRepository
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser> 
	{
		public void Update(ApplicationUser applicationUser);
	}
}
