using OrderManagement.Business.Abstract;
using OrderManagement.DataAccess.Abstract;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.Business.Concrete
{
    public class FeatureManager : GenericManager<Feature>, IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureManager(IRepository<Feature> _repository, IFeatureRepository featureRepository) : base(_repository)
        {
            _featureRepository = featureRepository;
        }
    }
}