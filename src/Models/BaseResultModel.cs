using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace InstaShop.HastTags.Models
{
    public class NullObjectResult { }
    public class BaseResultModel<T>
    {
        public BaseResultModel<T> OkResult(T data) =>
            new BaseResultModel<T>(data);
        public BaseResultModel<NullObjectResult> ErrorResult(int httpStatus, string stringResult) =>
            new BaseResultModel<NullObjectResult>(httpStatus, stringResult);

        public BaseResultModel(T data)
        {
            this.Sucess = true;
            this.Data = data;
        }

        public BaseResultModel(int httpStatus, string stringResult)
        {
            this.Sucess = false;
            this.HttpStatus = httpStatus;
            this.StringResult = stringResult;
        }

        public bool Sucess { get; set; }
        public T Data { get; set; }
        public int HttpStatus { get; set; }
        public string StringResult { get; set; }
        public Dictionary<string, string> Cookies { get; set; }
    }
}
