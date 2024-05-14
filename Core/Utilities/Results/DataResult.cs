using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Utilities.Results
{
	public class DataResult<T> : Result, IDataResult<T>
	{
		public DataResult(T data,bool isSucess) : base(isSucess)
		{
			Data= data;
		}

		public DataResult(T data,string message, bool isSucess) : base(message, isSucess)
		{
			Data = data;
		}
		
		public T Data { get; }
	}
}
