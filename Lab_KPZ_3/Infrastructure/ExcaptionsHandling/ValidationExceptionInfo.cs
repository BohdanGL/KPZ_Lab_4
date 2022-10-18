using System.Collections.Generic;

namespace Lab_KPZ_3.Infrastructure.ExcaptionsHandling
{
    public class ValidationExceptionInfo : ExceptionInfo
    {
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
