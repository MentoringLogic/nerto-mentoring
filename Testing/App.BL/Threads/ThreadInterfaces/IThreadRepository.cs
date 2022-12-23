using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.Threads.ThreadInterfaces
{
    public interface IThreadRepository
    {
        public CommentThread GetById(Guid id);
    }
}
