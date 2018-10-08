using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exception
{
    class DeleteException : ApplicationException
    {
        public DeleteException(String message) : base(message) { }
    }
    class ModifyException : ApplicationException
    {
        public ModifyException(String message) : base(message) { }
    }
}
