using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Aplication.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainservice;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();
            category.Edit(request.Title, request.Slug, request.SeoData, _domainservice);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}
