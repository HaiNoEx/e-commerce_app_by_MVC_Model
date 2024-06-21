using BulkyWeb.Models;

namespace BulkyWeb.Migrations.Repository.IRepository
{
	public interface IProductRepository : IRepository<Product> 
	{
		void Update(Product obj);
		

	}
}
