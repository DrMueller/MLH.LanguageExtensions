using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults
{
    public static class FunctionResult
    {
        public static FunctionResult<T> CreateFailure<T>()
        {
            return new FunctionResult<T>(false, default);
        }

        public static FunctionResult<T> CreateSuccess<T>(T value)
        {
            return new FunctionResult<T>(true, value);
        }
    }

    [SuppressMessage("Microsoft.Usage", "SA1402:FileMayOnlyContainASingleType", Justification =
        "It makes sense to keep these Classes together")]
    public class FunctionResult<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }

        public FunctionResult(bool isSuccess, T value)
        {
            IsSuccess = isSuccess;
            Value = value;
        }
    }
}