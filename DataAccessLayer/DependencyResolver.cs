using System.Collections.Generic;
using HospitalAPI.DependencyResolver;
using System.ComponentModel.Composition;

namespace HospitalAPI.DataAccessLayer
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterTypeWithControlledLifeTime<IDataAccessService, DataAccessService>();
        }
    }
}
