using BulkyWeb.Data;
using BulkyWeb.Migrations.Repository.IRepository;
using BulkyWeb.Models;
using System.Linq.Expressions;

namespace BulkyWeb.Migrations.Repository
{
	public class ProductImageRepository :  Repository<ProductImage>,IProductImageRepository 
	{
        private ApplicationDbContext _db;

        public ProductImageRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }


        public void Update(ProductImage obj)
        {
            _db.ProductImages.Update(obj);
        }
    }
}
