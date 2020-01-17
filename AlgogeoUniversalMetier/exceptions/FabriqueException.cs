using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoMetier.exceptions
{
    class FabriqueException : Exception
    {
        public FabriqueException(String message) : base(message)
        {

        }
    }
}