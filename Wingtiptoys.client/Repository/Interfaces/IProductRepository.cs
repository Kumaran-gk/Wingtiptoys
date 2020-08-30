using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wingtiptoys.DB.Models;

namespace Wingtiptoys.client.Repository
{
    public interface IProductRepository
    {
        //Query Methods
        IEnumerable<Products> GetAll();
        IEnumerable<Products> GetProductsBySearch(string strQuery);
        Products GetProduct(int productID);

        //CUD Methods
        // TO DO
        int CreateProduct(Products product);
        void DeleteProduct(Products product);
    }
}
