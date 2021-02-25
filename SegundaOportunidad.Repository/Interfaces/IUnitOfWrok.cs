using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Interfaces
{
    public interface IUnitOfWrok
    {
        Task<bool> Commit();
        Task<bool> RollBack();
    }
}
