using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Aplication.Products.Create
{
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
