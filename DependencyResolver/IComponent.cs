using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.DependencyResolver
{
    /// <summary>
    /// Initialization method. Each layer will implement it.
    /// </summary>
    public interface IComponent
    {
        void SetUp(IRegisterComponent registerComponent);
    }
}
