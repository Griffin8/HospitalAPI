using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.DependencyResolver;
using HospitalAPI.DataAccessLayer;
using System.ComponentModel.Composition;

namespace HospitalAPI.BusinessLayer
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IBusinessService, BusinessService>();
        }
    }
}
