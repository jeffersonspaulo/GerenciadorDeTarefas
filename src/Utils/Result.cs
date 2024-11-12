namespace GerenciadorDeTarefas.API.Utils
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }
        public T Data { get; private set; }

        public static Result<T> Success(T data) => new Result<T> { IsSuccess = true, Data = data };
        public static Result<T> Failure(string errorMessage) => new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
    }

    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }

        public static Result Success() => new Result { IsSuccess = true };
        public static Result Failure(string errorMessage) => new Result { IsSuccess = false, ErrorMessage = errorMessage };
    }
}
