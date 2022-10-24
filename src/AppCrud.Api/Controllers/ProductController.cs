using AppCrud.Api.DTOs;
using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;
using AppCrud.Business.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Api.Controllers;

[Route("api/produtos")]
public class ProductController : MainController
{
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(INotifier notifier,
                                  IProductRepository productRepository,
                                  IProductService productService,
                                  IMapper mapper) : base(notifier)
    {
        _productRepository = productRepository;
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ProductDTO>> Get(Guid id)
    {
        return _mapper.Map<ProductDTO>(await _productRepository.GetById(id));
    }


    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Add(ProductDTO clientDTO)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        await _productService.Add(_mapper.Map<Product>(clientDTO));

        return CustomResponse(clientDTO);
    }
}
