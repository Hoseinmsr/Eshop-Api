using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Aplication.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileservice;

        public CreateSliderCommandHandler(ISliderRepository repository, IFileService fileservice)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            if (imagename == null)
                return OperationResult.NotFound();
            var slider = new Slider(request.Title, request.Link, imagename);
            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success(); 
        }
    }
}
