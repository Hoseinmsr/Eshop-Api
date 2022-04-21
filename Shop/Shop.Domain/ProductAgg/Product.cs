using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class Product:AggregateRoot
    {
        private Product()
        {

        }
        public Product(string title, string imageName, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, SeoData seoData,string slug, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guard(title, slug,  description, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long   CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }


        public void Edit(string title, string description, long categoryId,
        long subCategoryId, long secondarySubCategoryId, SeoData seoData,string slug, IProductDomainService domainService)
        {
            Guard(title, slug,  description, domainService);
            Title = title;
            
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void SetProductImageName(string imagename)
        {
            NullOrEmptyDomainDataException.CheckString(imagename, nameof(imagename));
            ImageName = imagename;
        }
        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }
        public void RemoveImage(long productid)
        {
            var image = Images.FirstOrDefault(f => f.Id == productid);
            if (image == null)
                return;
            Images.Remove(image);
        }
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(f => f.ProductId = Id);
            Specifications = specifications;
        }
        public void Guard(string title,string slug, string description,IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.SlugExist(slug.ToSlug()))
                    throw new SlugIsDuplicateException();
        }
    }
}
