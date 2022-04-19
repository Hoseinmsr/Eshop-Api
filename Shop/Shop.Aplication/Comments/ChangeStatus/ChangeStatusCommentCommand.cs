using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Comments.ChangeStatus
{
    public record ChangeStatusCommentCommand(long Id,CommentStatus Status):IBaseCommand;
}
