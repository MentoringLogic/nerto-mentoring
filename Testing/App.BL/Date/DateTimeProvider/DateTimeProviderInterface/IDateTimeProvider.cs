using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Date.DateTimeProvider.DateTimeProviderInterface
{
    public interface IDateTimeProvider
    {
        public DateTime GetNow();
    }
}
