using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Categories.Create
{
    public record CreateCategoryCommand(string Title,string Slug,SeoData SeoData):IBaseCommand;

}
