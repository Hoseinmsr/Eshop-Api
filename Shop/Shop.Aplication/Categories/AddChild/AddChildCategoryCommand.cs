﻿using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParentId,string Title,string Slug,SeoData SeoData):IBaseCommand;
}
