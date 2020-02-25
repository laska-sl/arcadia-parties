using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcadiaParties.Data.Data
{
    public interface ISeed
    {
        Task SeedData(DataContext context);
    }
}
