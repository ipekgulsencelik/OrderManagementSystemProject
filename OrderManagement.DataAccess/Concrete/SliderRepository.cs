﻿using OrderManagement.DataAccess.Abstract;
using OrderManagement.DataAccess.Context;
using OrderManagement.DataAccess.Repositories;
using OrderManagement.Entity.Entitles;

namespace OrderManagement.DataAccess.Concrete
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(OrderManagementContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            var value = _context.Sliders.Find(id);
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
            var value = _context.Sliders.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Sliders.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}