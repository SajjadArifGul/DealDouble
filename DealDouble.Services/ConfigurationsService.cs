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
        public List<Configuration> GetSlidersConfigurations()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Configurations.Where(x=>x.ConfigurationType == (int)ConfigurationType.HomeSliders).ToList();
        }
    }
}
