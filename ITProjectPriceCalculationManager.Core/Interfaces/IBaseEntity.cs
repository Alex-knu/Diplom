using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITProjectPriceCalculationManager.Core.Interfaces
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}