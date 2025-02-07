﻿using OrderManagement.Business.Abstract;
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

        public void TDontShowOnHome(int id)
        {
            _featureRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _featureRepository.ShowOnHome(id);
        }

        public void TChangeStatus(int id)
        {
            _featureRepository.ChangeStatus(id);
        }

        public List<Feature> TGetLast3Features()
        {
            return _featureRepository.GetLast3Features();
        }
    }
}