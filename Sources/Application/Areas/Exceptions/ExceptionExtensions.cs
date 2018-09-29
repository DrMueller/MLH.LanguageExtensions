using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.Exceptions
{
    public static class ExceptionExtensions
    {
        public static Exception GetMostInnerException(this Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }
}