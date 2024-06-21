using BulkyWeb.Models;

namespace BulkyWeb.Migrations.Repository.IRepository
{
	public interface IShoppingCartRepository : IRepository<ShoppingCart> 
	{
		void Update(ShoppingCart obj);
		

	}
}
