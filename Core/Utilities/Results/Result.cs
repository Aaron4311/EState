using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
	public class Result : IResult
	{

        public Result(bool isSucess)
        {
            IsSuccess = isSucess;
        }
        public Result(string message, bool isSucess) : this(isSucess) 
        {
            Message = message;
        }

        public string Message { get; }

		public bool IsSuccess { get; }
	}
}
