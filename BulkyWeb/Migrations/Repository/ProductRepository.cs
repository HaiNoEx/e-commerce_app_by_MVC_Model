﻿using BulkyWeb.Data;
using BulkyWeb.Migrations.Repository.IRepository;
using BulkyWeb.Models;
using System.Linq.Expressions;

namespace BulkyWeb.Migrations.Repository
{
	public class ProductRepository :  Repository<Product>,IProductRepository 
	{
		private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        

		public void Update(Product obj)
		{
			var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
			if(objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.Description = obj.Description;
				objFromDb.CategoryId = obj.CategoryId;
				objFromDb.ISBN = obj.ISBN;
				objFromDb.Price = obj.Price;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Price50 = obj.Price50;
				objFromDb.Price100 = obj.Price100;
				objFromDb.Author = obj.Author;
				objFromDb.ProductImages = obj.ProductImages;
				//if(obj.ImageUrl != null)
				//{
				//	objFromDb.ImageUrl = obj.ImageUrl;
				//}
			}
		}
	}
}
