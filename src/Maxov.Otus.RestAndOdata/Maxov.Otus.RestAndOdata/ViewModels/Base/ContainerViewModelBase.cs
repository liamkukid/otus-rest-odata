using System.Collections.Generic;

namespace Maxov.Otus.RestAndOdata.ViewModels.Base
{
    public abstract class ContainerViewModelBase<T>
    {
        public IReadOnlyList<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}