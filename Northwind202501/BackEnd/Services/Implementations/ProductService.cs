﻿using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProductService : IProductService

    {
        IUnidadDeTrabajo _Unidad;
        public ProductService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        ProductDTO Convertir(Product product)
        {
            var supplier = _Unidad.SupplierDAL.Get((int)product.SupplierId);


            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
                SupplierName = supplier.CompanyName
            };
        }

        Product Convertir(ProductDTO product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }



        public ProductDTO Add(ProductDTO product)
        {
            try
            {
                _Unidad.ProductDAL.Add(Convertir(product));

                _Unidad.Complete();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {

            Product product = new Product { ProductId = id };
            _Unidad.ProductDAL.Remove(product);
            _Unidad.Complete();
          
        }

        public ProductDTO GetById(int id)
        {
            var product = _Unidad.ProductDAL.Get(id);
            
            return Convertir(product);
        }

        public List<ProductDTO> GetProducts()
        {
            var products = _Unidad.ProductDAL.GetAll();
            List<ProductDTO> productsList = new List<ProductDTO>();
            foreach (var product in products)
            {

                productsList.Add(Convertir(product));
            }
            return productsList;
        }

        public ProductDTO Update(ProductDTO product)
        {
            try
            {
                _Unidad.ProductDAL.Update(Convertir(product));

                _Unidad.Complete();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
