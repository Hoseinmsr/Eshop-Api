using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Aplication.Products.RemoveImage
{
    public class RemoveImageProductCommandHandler : IBaseCommandHandler<RemoveImageProductCommand>
    {
        
        private readonly IProductRepository _repository;
        private readonly IFileService _fileservice;

        public RemoveImageProductCommandHandler(IProductRepository repository, IFileService fileservice)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(RemoveImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            var imagename = product.RemoveImage(request.ImageId);
            await _repository.Save();
            _fileservice.DeleteFile(Directories.ProductGalleryImage, imagename);
            return OperationResult.Success();
        }
    }
}
