using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Infrastructure.Extensions
{
    public static class DefaultExtensions
    {

        public static bool IsNull<T>(this T obj) => obj == null;

        public static bool IsNotNull<T>(this T obj) => !obj.IsNull();

        public static bool IsLessZero(this int num) => num <= 0;
    }
}
