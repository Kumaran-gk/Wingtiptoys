using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wingtiptoys.DB.Models;

namespace Wingtiptoys.client.Repository
{
    public class ProductRepository : IProductRepository, IDisposable
    {

        private WingtiptoysContext context = null;
        private bool disposed = false;

        protected DbSet<Products> dbProductsSet = null;

        // Parameterized Constructor
        public ProductRepository(WingtiptoysContext context)
        {
            this.context = context;
            this.dbProductsSet = context.Set<Products>();
        }

        public ProductRepository() : this(new WingtiptoysContext())
        {
        }

        // Dispose False will clean up native resources
        // Dispose True will clear up both managed and native resources.

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Placeholder : To dispose the created respositories, for standard Practise
                    context.Dispose();
                }
            }
        }

        // Get all the Product
        // Keeping this pretty and adding the filter on the client to filter the Product whcih endswith CAR
        public IEnumerable<Products> GetAll()
        {
            return this.dbProductsSet;
        }

        // Search the Product with the search string
        public IEnumerable<Products> GetProductsBySearch(string strQuery)
        {
            //throw new NotImplementedException();
            var productObj = this.dbProductsSet.Where(p => (p.ProductName.ToUpper().Contains(strQuery.ToUpper()) || p.Description.ToUpper().Contains(strQuery.ToUpper())));
            return productObj;
        }

        // To Get the Product BY ID
        public Products GetProduct(int productID)
        {
            var productObj = this.dbProductsSet.Where(p => (p.ProductId == productID)).FirstOrDefault();
            return productObj;
        }

        public int CreateProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
