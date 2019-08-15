using CRM.Util.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Util
{
    public static class EnumHelper
    {
        public static string RolesToString(RoleEnum roleEnum)
        {
            switch (roleEnum)
            {
                case RoleEnum.ADMIN:
                    return "Admin";
                case RoleEnum.EMPLOYEE:
                    return "Employee";
                default:
                    return "";
            }
        }
    }
}
