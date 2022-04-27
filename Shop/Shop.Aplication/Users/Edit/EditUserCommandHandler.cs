using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Aplication._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Aplication.Users.Edit
{
    internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IDomainUserService _service;
        private readonly IFileService _fileservice;
        public EditUserCommandHandler(IUserRepository repository, IDomainUserService service, IFileService fileservice)
        {
            _repository = repository;
            _service = service;
            _fileservice = fileservice;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _repository.GetTracking(request.UserId);
            var oldavatar = user.AvatarName; 
            if (user == null)
                return OperationResult.NotFound();
            user.Edit(request.Name, request.Family, request.Email, request.Phonenumber, request.Gender, _service);
            if (request.Avatar != null)
            {
                var imagename = await _fileservice.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
                user.SetAvatar(imagename);
            }
            DeleteOldAvatar(request.Avatar, oldavatar);
            await _repository.Save();
            return OperationResult.Success();
        }
        public void DeleteOldAvatar(IFormFile? avatarfile,string oldimage)
        {
            if(avatarfile == null || oldimage == "avata.png")
            {
                return;
            }
            _fileservice.DeleteFile(Directories.UserAvatars, oldimage);
        }
    }
}
