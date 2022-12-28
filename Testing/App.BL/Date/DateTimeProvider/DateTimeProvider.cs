using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BL.Comments;
using App.BL.Date.DateTimeProvider.DateTimeProviderInterface;

namespace App.BL.Date.DateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}
