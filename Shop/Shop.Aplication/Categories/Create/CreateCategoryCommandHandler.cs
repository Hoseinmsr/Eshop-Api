using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Aplication.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
       private readonly ICategoryRepository _repository;
       private readonly ICategoryDomainService _domainservice;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainservice)
        {
            _repository = repository;
            _domainservice = domainservice;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Title, request.Slug, request.SeoData, _domainservice);
            _repository.Add(category);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}
