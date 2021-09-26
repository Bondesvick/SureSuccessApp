using System.Collections.Generic;

namespace SureSuccessApp.CreateService.ResponseModels
{
    public class PaginatedItemResponseModel0<TEntity> where TEntity : class
    {
        public PaginatedItemResponseModel0(int pageIndex, int pageSize, long total, IEnumerable<TEntity> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
            Data = data;
        }

        public int PageIndex { get; }

        public int PageSize { get; }

        public long Total { get; }

        public IEnumerable<TEntity> Data { get; }
    }
}