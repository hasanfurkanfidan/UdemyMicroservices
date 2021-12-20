﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UdemyMicroservices.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public List<string> Errors { get; set; }
        /// <summary>
        /// Data dönülen durumlar için gerçekleştirilmiştir
        /// </summary>
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>
            {
                Errors = new List<string> { error },
                IsSuccessful = false,
                StatusCode = statusCode
            };
        }
    }
}