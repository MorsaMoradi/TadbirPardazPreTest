using System;
using System.Collections.Generic;
using System.Text;

namespace TadbirPardazPreTest.ServiceContract.Base
{
    public interface IEntityMapper<TDomain, TDoaminDto>
    {
        TDoaminDto MappTo(TDomain domain);
        TDomain CreateFrom(TDoaminDto doaminDto);
    }
}
