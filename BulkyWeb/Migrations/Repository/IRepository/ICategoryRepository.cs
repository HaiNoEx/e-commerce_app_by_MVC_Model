using BulkyWeb.Models;

namespace BulkyWeb.Migrations.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category> 
	{
		void Update(Category obj);
		

	}
}
