using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Aplication.Products.AddImage
{
    public class AddImageProductCommandHandler : IBaseCommandHandler<AddImageProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileservice;

        public AddImageProductCommandHandler(IProductRepository repository, IFileService fileservice)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            var imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);
            var productimage = new ProductImage(imagename, request.Sequence);
            product.AddImage(productimage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
