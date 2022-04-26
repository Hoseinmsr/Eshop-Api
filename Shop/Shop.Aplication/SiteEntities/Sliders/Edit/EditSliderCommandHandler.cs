using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Aplication._Utilities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Aplication.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileservice;

        public EditSliderCommandHandler(ISliderRepository repository, IFileService fileservice)
        {
            _repository = repository;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider =await _repository.GetTracking(request.Id);
            if (slider == null)
                return OperationResult.NotFound();
            var imagename = slider.ImageName;
            if (request.ImageFile != null)
                imagename =await _fileservice.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            slider.Edit(request.Title, request.Link, imagename);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
