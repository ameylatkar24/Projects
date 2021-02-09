using AutoMapper;
using Catlog.Management.Api.Buisness.Entities;
using Catlog.Management.Api.Repository.Entities;
namespace Catlog.Management.Api.Buisness.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            /*
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductEntities, Product>();
            });
            var p = new ProductEntities();
            config.AssertConfigurationIsValid();
            IMapper imapper = config.CreateMapper();
            var dest = imapper.Map<ProductEntities, Product>(p);
        */
            CreateMap<Product, ProductEntities>();

        }

    }
}