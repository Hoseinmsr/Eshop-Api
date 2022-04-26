using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand:IBaseCommand
    {
        public EditSliderCommand(long id, string title, string link, IFormFile imageFile)
        {
            Id = id;
            Title = title;
            Link = link;
            ImageFile = imageFile;
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public IFormFile ImageFile { get; private set; }
    }
}
