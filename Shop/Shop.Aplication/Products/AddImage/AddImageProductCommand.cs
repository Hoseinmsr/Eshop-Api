using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Products.AddImage
{
    public class AddImageProductCommand:IBaseCommand
    {
        public AddImageProductCommand(IFormFile imageFile, long productId, int sequence)
        {
            ImageFile = imageFile;
            ProductId = productId;
            Sequence = sequence;
        }

        public IFormFile ImageFile { get; private set; }
        public long ProductId { get; private set; }
        public int Sequence { get; private set; }
    }
    
}
