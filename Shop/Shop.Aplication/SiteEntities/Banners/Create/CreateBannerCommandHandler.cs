using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Aplication.SiteEntities.Banners.Create
{
    internal class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
    {
        private readonly IBannerRepository _repository;
        private readonly IFileService _fileservice;

        public CreateBannerCommandHandler(IBannerRepository repository, IFileService fileservice)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            var banner = new Banner(request.Link, imagename, request.Position);

            _repository.Add(banner);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
