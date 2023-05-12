using HardwareStoreWeb.Pages;

namespace HardwareStoreWeb.Utilities
{
	public class Pagination<T>
	{
		public int PageNumber { get; private set; }
		public int PageSize { get; private set; }
		public int TotalPages { get; private set; }
		public int TotalCount { get; private set; }

		public int StartAt => (PageNumber - 1) * PageSize + 1;
		public int EndAt => PageNumber == TotalPages ? TotalCount : PageNumber * PageSize;

		public IList<T> Items { get; private set; }

		public bool HasPreviousPage => PageNumber > 1;
		public bool HasNextPage => PageNumber < TotalPages;

		public Pagination(IList<T> items, int pageNumber, int pageSize)
		{
			PageSize = pageSize < 1 ? 1 : pageSize;
			TotalCount = items.Count;
			TotalPages = (int)Math.Ceiling(items.Count / (double)PageSize);
			PageNumber = pageNumber < 1 ? 1 : pageNumber > TotalPages ? TotalPages : pageNumber;

			Items = items.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
		}

		public List<int> GetRange()
		{
			var startPage = PageNumber - 2;
			var endPage = PageNumber + 2;

			if (startPage < 1)
			{
				endPage += 1 - startPage;
				startPage = 1;
			}

			if (endPage > TotalPages)
			{
				endPage = TotalPages;

				if (endPage - 4 > 0)
				{
					startPage = endPage - 4;
				}
				else
				{
					startPage = 1;
				}
			}

			return Enumerable.Range(startPage, endPage - startPage + 1).ToList();
		}
	}
}
