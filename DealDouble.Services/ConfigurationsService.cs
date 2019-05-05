using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class ConfigurationsService
    {
        public List<Configuration> GetConfigurationsByType(int configurationType)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Configurations.Where(x=>x.ConfigurationType == configurationType).ToList();
        }

        public Configuration GetConfigurationByKey(string key)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Configurations.FirstOrDefault(x => x.Key == key);
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(configuration).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public void UpdateConfigurationValue(string key, string value)
        {
            DealDoubleContext context = new DealDoubleContext();

            var configuration = context.Configurations.Find(key);

            configuration.Value = value;

            context.Entry(configuration).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public List<Configuration> SearchConfigurations(int? configurationType, string searchTerm, int? pageNo, int pageSize)
        {
            DealDoubleContext context = new DealDoubleContext();

            var configurations = context.Configurations.AsQueryable();

            if (configurationType.HasValue && configurationType.Value > 0)
            {
                configurations = configurations.Where(x => x.ConfigurationType == configurationType.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                configurations = configurations.Where(x => x.Key.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return configurations.OrderBy(x => x.Key).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetConfigurationsCount(int? configurationType, string searchTerm)
        {
            DealDoubleContext context = new DealDoubleContext();

            var configurations = context.Configurations.AsQueryable();

            if (configurationType.HasValue && configurationType.Value > 0)
            {
                configurations = configurations.Where(x => x.ConfigurationType == configurationType.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                configurations = configurations.Where(x => x.Key.ToLower().Contains(searchTerm.ToLower()));
            }

            return configurations.Count();
        }
    }
}
