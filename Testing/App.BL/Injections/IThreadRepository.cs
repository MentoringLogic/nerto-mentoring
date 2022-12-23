using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public interface IThreadRepository
    {
        public CommentThread GetById(Guid id);
    }
}
