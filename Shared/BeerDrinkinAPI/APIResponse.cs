using System;

namespace BeerDrinkin.API
{
    public class APIResponse<T>
    {
        public APIResponse(T result, Exception error)
        {
            Result = result;
            Error = error;
        }

        public T Result { get; private set; }
        public Exception Error { get; }

        public bool HasError => Error != null;

        public string ErrorMessage => (HasError) ? Error.Message : string.Empty;
    }
}