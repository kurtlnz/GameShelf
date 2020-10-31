using System.Collections.Generic;
using System.Linq;

namespace GameShelf.Repository
{
    public class Result
    {
        public bool IsSuccess => Errors != null && !Errors.Any();
        public bool HasWarnings => Warnings != null && Warnings.Any();
        public List<string> Errors { get; set; }
        public List<string> Warnings { get; set; }

        public Result()
        {
            Errors = new List<string>();
            Warnings = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
        }

        public void AddWarning(string warning)
        {
            Warnings.Add(warning);
        }

        public void AddWarnings(IEnumerable<string> warnings)
        {
            Warnings.AddRange(warnings);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        public Result()
        {

        }

        public Result(T value)
        {
            Value = value;
        }

        public Result(T value, List<string> errors)
        {
            Value = value;
            Errors = errors;
        }
    }
}