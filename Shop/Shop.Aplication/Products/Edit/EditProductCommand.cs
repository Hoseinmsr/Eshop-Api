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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Products.Edit
{
    public class EditProductCommand:IBaseCommand
    {
        public EditProductCommand(string title, IFormFile? imageFile, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications, long productId)
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
            ProductId = productId;
        }
        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specifications { get; private set; }
    }
    public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
      private readonly  IProductRepository _repository;
        private readonly IProductDomainService _domainservice;
        private readonly IFileService _fileservice;

        public EditProductCommandHandler(IProductRepository repository, IProductDomainService domainservice, IFileService fileservice)
        {
            _repository = repository;
            _domainservice = domainservice;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product =await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId, request.SecondarySubCategoryId,
                request.SeoData, request.Slug, _domainservice);

            var OldImage = product.ImageName;

            if (request.ImageFile != null)
            {
                var imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImage);
                product.SetProductImageName(imagename);
            }
            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifications);
            await _repository.Save();
            RemoveOldImage(request.ImageFile,OldImage);
            return OperationResult.Success();
        }
        public void RemoveOldImage(IFormFile imagefile,string oldimagename)
        {
            if (imagefile != null)
            {
                _fileservice.DeleteFile(Directories.ProductImage, oldimagename);    
            }
        }
    }
}
