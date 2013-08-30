using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GammaRaySetlist.Model
{
    public class Song : Entity
    {
        public string Name { get; set; }
        public bool Listened { get; set; }

        public virtual Band Band { get; set; }
    }
}
