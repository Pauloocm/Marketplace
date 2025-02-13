﻿namespace ServerlessMarketplace.Platform.Application.RequestResults
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        private Result(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static Result Success() => new(true, null!);
        public static Result Failure(string errorMessage) => new(false, errorMessage);
    }
}
