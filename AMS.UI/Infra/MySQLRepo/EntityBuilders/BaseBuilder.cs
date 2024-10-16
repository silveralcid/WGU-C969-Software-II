using System;

namespace AMS.UI.Infra.MySQLRepo.EntityBuilders
{
    internal class BaseBuilder
    {
        protected string ToString(object value)
        {
            return Convert.ToString(value);
        }

        protected bool ToBoolean(object value)
        {
            return Convert.ToBoolean(value);
        }

        protected DateTime ToDateTime(object value)
        {
            return Convert.ToDateTime(value);
        }

        protected int ToInt(object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
