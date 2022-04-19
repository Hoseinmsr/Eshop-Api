using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Aplication.Comments.ChangeStatus
{
    public class ChangeStatusCommentCommandHandler : IBaseCommandHandler<ChangeStatusCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public ChangeStatusCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ChangeStatusCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.Id);
            if (comment == null)
                return OperationResult.NotFound();
            comment.ChangeStatus(request.Status);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
