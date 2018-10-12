using STOService.BindingModels;
using STOService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOService.Interfaces
{
   public interface IServiceService
    {
        List<ServiceViewModel> GetList();
        ServiceViewModel GetElement(int id);
        ServiceBindingModel GetElementBM(int id);
        void AddElement(ServiceBindingModel model);
        void UpdElement(ServiceBindingModel model);
        void DelElement(int id);
        void SendEmail(string mailAddress, string subject, string text);
    }
}
