using AutoMapper;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using UniLogLibFramework.Library;

namespace POS.Repository.Entities.Services
{
    
    public partial interface IDateReportService
    {
        Task<bool> CreateReportAsync(DateReportViewModel model);
        
    }


    public partial  class DateReportService
    {
        //private static readonly LogMonitor _log = new LogMonitor();
        public async Task<bool> CreateReportAsync(DateReportViewModel model)
        {
            try
            {
                Mapper.CreateMap<DateReportViewModel, DateReport>();
                await  this.CreateAsync(Mapper.Map<DateReportViewModel, DateReport>(model));
                return true;
            }
            catch (Exception ex)
            {
                //_log.SendLogError(ex);
            }
            return false;
        }
    }
}
