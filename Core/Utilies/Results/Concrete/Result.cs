using System;
using Core.Utilies.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilies.Results.Concrete
{
    public class Result : IResult
    {
        //getter'lar readonly'dir ve readonly'ler constructor'da set edilebilir.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
