﻿namespace ProjectTwo.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int DBCode { get; set; }
        public object Data { get; set; }
    }
}