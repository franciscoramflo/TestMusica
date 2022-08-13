using System;

namespace Musica.Utils
{
    public enum ResultCode
    {
        Success,
        Error
    }
    public class ReturnInfo
    {
        public ReturnInfo()
        {
            Result = ResultCode.Success;
            Message = "";
        }
        public ResultCode Result { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

        public Exception Exception { get; set; }
    }
}
