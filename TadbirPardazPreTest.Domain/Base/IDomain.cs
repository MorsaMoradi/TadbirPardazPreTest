using System;
using System.Collections.Generic;
using System.Text;

namespace TadbirPardazPreTest.Domain.Base
{
    public interface IDomain<TIdentifier>
    {
        TIdentifier Id { get; }
    }
}
