﻿using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(OrderManagementContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            var value = _context.Features.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _context.Update(value);
            _context.SaveChanges();
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Features.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<Feature> GetLast3Features()
        {
            return _context.Features.Where(x => x.IsShown && x.Status ).OrderByDescending(x => x.FeatureID).Take(3).ToList();
        }


        public void ShowOnHome(int id)
        {
            var value = _context.Features.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}