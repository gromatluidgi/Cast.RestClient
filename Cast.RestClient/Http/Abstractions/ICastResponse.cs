using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Http.Abstractions
{
    public interface ICastResponse<T>
    {
        T? Data { get; set; }
    }
}
