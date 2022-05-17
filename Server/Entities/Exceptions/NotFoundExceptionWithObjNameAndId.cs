using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class NotFoundExceptionWithObjNameAndId : NotFoundException
    {
        public NotFoundExceptionWithObjNameAndId(string ObjectName, int Id)
            : base($"The {ObjectName} with Id: {Id} Not Found")
        {

        }
    }
}
