using STOService.BindingModels;
using STOService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOService.Interfaces
{
   public interface IDeliveryService
    {
        List<DeliveryViewModel> GetList();
        DeliveryViewModel GetElement(int id);
        int AddElement(DeliveryBindingModel model);
        void UpdElement(DeliveryBindingModel model);
        void DelElement(int id);

        void SendEmail(string mailAddress, string subject, string text);
    }
}
