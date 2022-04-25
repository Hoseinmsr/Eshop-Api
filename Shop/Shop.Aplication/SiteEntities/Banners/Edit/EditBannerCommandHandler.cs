using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Aplication.SiteEntities.Banners.Edit
{
    internal class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        private readonly IBannerRepository _repository;
        private readonly IFileService _fileservice;

        public EditBannerCommandHandler(IBannerRepository repository, IFileService fileservice)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetTracking(request.Id);
            if (banner == null)
                return OperationResult.NotFound();
            var imagename = banner.ImageName;
            if (request.ImageFile != null)
                imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            banner.Edit(request.Link, imagename, request.Position);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
