namespace Core.General
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Операция выполнена успешно
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Произошла ошибка при выполнении операции
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Ошибка, возникшая при выполнении операции
        /// </summary>
        public Error Error { get; }

        protected Result(bool isSuccess, string error, string errorLevel = "")
        {
            if (isSuccess && !string.IsNullOrWhiteSpace(error))
                throw new InvalidOperationException("Сообщение об ошибке должно быть пустым, если результат операции успешный.");

            if (!isSuccess && string.IsNullOrWhiteSpace(error))
                throw new InvalidOperationException("Сообщение об ошибке не может быть пустым, если операция не выполнена из-за ошибки.");

            IsSuccess = isSuccess;
            Error = new Error(error, errorLevel);
        }

        /// <summary>
        /// Создаёт результат операции, прерванной из-за ошибки
        /// </summary>
        /// <param name="errorMessage">Описание ошибки</param>
        /// <param name="errorLevel">Уровень ошибки</param>
        public static Result Fail(string errorMessage, string errorLevel = "")
        {
            return new Result(false, errorMessage, errorLevel);
        }

        /// <summary>
        /// Создаёт результат операции с возвратом полезных данных, прерванной из-за ошибки
        /// </summary>
        /// <typeparam name="T">Тип возвращаемых данных</typeparam>
        /// <param name="errorMessage">Описание ошибки</param>
        /// <param name="errorLevel">Уровень ошибки</param>
        public static Result<T> Fail<T>(string errorMessage, string errorLevel = "")
        {
            return new Result<T>(false, errorMessage, errorLevel);
        }

        /// <summary>
        /// Создаёт результат успешного выполнения операции
        /// </summary>
        public static Result Ok()
        {
            return new Result(true, default);
        }

        /// <summary>
        /// Создаёт результат успешного выполнения операции с возвратом полезных данных
        /// </summary>
        /// <typeparam name="T">Тип возвращаемых данных</typeparam>
        /// <param name="data">Возвращаемые данные</param>
        public static Result<T> Ok<T>(T data)
        {
            return new Result<T>(data, true, default);
        }
    }

    /// <summary>
    /// Результат выполнения операции с возвратом полезных данных
    /// </summary>
    /// <typeparam name="T">Тип возвращаемых данных</typeparam>
    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value => IsSuccess ? _value : default;

        internal Result(bool isSuccess, string errorMessage, string errorLevel)
            : base(isSuccess, errorMessage, errorLevel)
        {
        }

        internal Result(T value, bool isSuccess, string errorMessage, string errorLevel = "")
            : this(isSuccess, errorMessage, errorLevel)
        {
            _value = value;
        }
    }

    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Уровень ошибки. Определяет принадлежность ошибки свойству объекта или параметру.
        /// </summary>
        public string Level { get; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string Message { get; }

        public Error(string message, string level = "")
        {
            Message = message;
            Level = level;
        }
    }
}
