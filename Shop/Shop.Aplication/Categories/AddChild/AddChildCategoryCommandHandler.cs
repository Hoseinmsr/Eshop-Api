using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Aplication.Categories.AddChild
{
    public partial class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainservice;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }
        public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult.NotFound();
            category.AddChild(request.Title, request.Slug, request.SeoData, _domainservice);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
