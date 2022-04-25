using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.SiteEntities.Banners.Edit
{
    public class EditBannerCommand:IBaseCommand
    {
        public EditBannerCommand(string link, IFormFile imageFile, BannerPosition position, long id)
        {
            Link = link;
            ImageFile = imageFile;
            Position = position;
            Id = id;
        }

        public long Id { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
