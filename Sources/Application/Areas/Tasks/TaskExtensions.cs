using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmu.Mlh.LanguageExtensions.Areas.Tasks
{
    public static class TaskExtensions
    {
        public static async Task<IReadOnlyCollection<TResult>> SelectAsync<T, TResult>(
            this Task<IReadOnlyCollection<T>> task,
            Func<T, TResult> selector)
        {
#pragma warning disable VSTHRD003 // Avoid awaiting foreign Tasks
            var data = await task;
#pragma warning restore VSTHRD003 // Avoid awaiting foreign Tasks

            return data
                .Select(selector)
                .ToList();
        }
    }
}