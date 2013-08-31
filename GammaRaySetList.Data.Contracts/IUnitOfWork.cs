using GammaRaySetlist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaRaySetList.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();

        IRepository<Band> Bands { get; }
        IRepository<Song> Songs { get; }
    }
}
