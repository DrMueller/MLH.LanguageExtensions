using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults
{
    public class FunctionResult
    {
        public FunctionResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }

        public static FunctionResult CreateFailure()
        {
            return new FunctionResult(false);
        }

        public static FunctionResult<T> CreateFailure<T>()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new FunctionResult<T>(false, default);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public static FunctionResult<T> CreateFromDefault<T>(T value)
        {
            // Careful, default doesn't work, it has to be default(T)
            return Equals(value, default(T)) ? CreateFailure<T>() : CreateSuccess(value);
        }

        public static FunctionResult CreateSuccess()
        {
            return new FunctionResult(true);
        }

        public static FunctionResult<T> CreateSuccess<T>(T value)
        {
            return new FunctionResult<T>(true, value);
        }
    }

    [SuppressMessage(
        "Microsoft.Usage",
        "SA1402:FileMayOnlyContainASingleType",
        Justification = "It makes sense to keep these Classes together")]
    public class FunctionResult<T> : FunctionResult
    {
        public FunctionResult(bool isSuccess, T value)
            : base(isSuccess)
        {
            Value = value;
        }

        public T Value { get; }
    }
}