using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using enums = Rwd.Framework.Enumerations;
namespace Rwd.Framework.Interfaces
{
  
   public interface IValidate
    {
        void Validate(enums.ChangeAction action);
    }
}
