using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using GammaRaySetlist.Model;

namespace GammaRaySetList.Data
{
    public class GammaRayDatabaseInitializer : DropCreateDatabaseAlways<GammaRayContext>
    {
        protected override void Seed(GammaRayContext context)
        {
            var bands = CreateBands().ToArray();
            Array.ForEach(bands, t => context.Bands.Add(t));

            context.SaveChanges();
        }

        private List<Band> CreateBands()
        {
            var bands = new List<Band> {
                new Band {
                    Name = "Gamma Ray",
                    Songs = new List<Song> {
                        new Song {
                            Name = "Rebellion in Dreamland",
                            Listened = true
                        },
                        new Song {
                            Name = "Time to Break Free",
                            Listened = true
                        }
                    }
                },

                new Band {
                    Name = "Helloween"
                }
            };

            return bands;
        }
    }
}
