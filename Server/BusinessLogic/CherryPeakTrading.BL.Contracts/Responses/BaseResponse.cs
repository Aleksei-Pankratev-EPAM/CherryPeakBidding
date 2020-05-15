﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CherryPeakTrading.BL.Contracts.Responses
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
