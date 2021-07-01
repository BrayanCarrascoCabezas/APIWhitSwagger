using APIWhitSwagger.Domain.Entities;
using APIWhitSwagger.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIWithSwagger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;        }

        [HttpPost]
        public void CreateProduct(Product product)
        {
            _productRepository.Insert(product);
            _productRepository.SaveAsync();
        }

        /// <summary>
        /// EsteMetodo obtiene todos los productos de 
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Este método es devuelto cuando la funcion se ejecutacorrectamente</response>
        /// <response code="201">Este método es devuelto cuandoesta mal</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public Product GetProductById(string id)
        {
            var products = _productRepository.GetByID(id);
            return products;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(string id, Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(string id)
        {
            var productFound = _productRepository.GetByID(id);
            _productRepository.Delete(productFound);
            _productRepository.Save();
            return Ok();
        }
    }
}
