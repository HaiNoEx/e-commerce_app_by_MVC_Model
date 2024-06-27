using BulkyWeb.Models;

namespace BulkyWeb.Migrations.Repository.IRepository
{
	public interface IProductImageRepository : IRepository<ProductImage> 
	{
		void Update(ProductImage obj);
		

	}
}
