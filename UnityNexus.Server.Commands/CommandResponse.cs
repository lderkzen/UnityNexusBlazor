using System.Linq;

namespace UnityNexus.Server.Commands
{
    public class CommandResponse<T>
    {
        public Error[]? Errors { get; }

        public T? Value { get; }

        private CommandResponse(IEnumerable<Error> errors)
        {
            Errors = errors.ToArray();
            Value = default;
        }

        private CommandResponse(T value)
        {
            Errors = null;
            Value = value;
        }

        public static CommandResponse<T> Fail(params Error[] errors) => new(errors);

        public static CommandResponse<T> Fail(IEnumerable<Error> errors) => new(errors);

        public static CommandResponse<T> Succeed(T value) => new(value);
    }
}
