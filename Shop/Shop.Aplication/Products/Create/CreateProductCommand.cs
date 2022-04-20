using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Aplication._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Products.Create
{
    public class CreateProductCommand:IBaseCommand
    {
        public CreateProductCommand(string title, IFormFile imageFile, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }

        public string Title { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string,string> Specifications { get; private set; }
    }
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainservice;
        private readonly IProductRepository _repository;
        private readonly IFileService _fileservice;

        public CreateProductCommandHandler(IProductDomainService domainservice, IProductRepository repository, IFileService fileservice)
        {
            _domainservice = domainservice;
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImage);
            var product = new Product(request.Title, imagename, request.Description,
                request.CategoryId, request.SubCategoryId, request.SecondarySubCategoryId
                , request.SeoData, request.Slug, _domainservice);
            _repository.Add(product);
            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
