using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExist = 101,
        EmailAlreadyExist = 102,
        UsernameOrPasswordWrong = 103,
        UserNotFound = 104,
        UserCouldNotUpdated = 105,
        UserCouldNotRemoved = 106,
        UserCouldNotFound = 107,
        UserCouldNotInserted = 108
    }
}
