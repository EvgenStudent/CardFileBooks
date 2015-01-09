using System;
using System.Collections.Generic;
using System.Linq;
using Core.DB;
using Web.Server.Constants;
using Web.Server.Helpers;
using Web.Server.Models;

namespace Web.Server.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<Book> Filters(this IEnumerable<Book> books, IEnumerable<FilterParameters> parameters, out int total)
		{
			if (parameters.Any())
				foreach (var filterParameter in parameters)
					if (filterParameter.FilterField == NameOfHelper<Book>.Property(x => x.Authors))
					{
						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorEq)
							books = books.Where(x => x.Authors.Any(y => y.FullName == filterParameter.FilterValue));

						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorContains)
							books = books.Where(x => x.Authors.Any(y => y.FullName.Contains(filterParameter.FilterValue)));

						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorStartsWith)
							books = books.Where(x => x.Authors.Any(y => y.FullName.StartsWith(filterParameter.FilterValue)));
					}
					else if (filterParameter.FilterField == NameOfHelper<Book>.Property(x => x.Genres))
					{
						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorEq)
							books = books.Where(x => x.Genres.Any(y => y.GenreName == filterParameter.FilterValue));

						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorContains)
							books = books.Where(x => x.Genres.Any(y => y.GenreName.Contains(filterParameter.FilterValue)));

						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorStartsWith)
							books = books.Where(x => x.Genres.Any(y => y.GenreName.StartsWith(filterParameter.FilterValue)));
					}
					else
					{
						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorEq)
							books = books.Where(x => x.GetType().GetProperty(filterParameter.FilterField).GetValue(x, null).ToString() == filterParameter.FilterValue);

						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorContains)
							books = books.Where(x => x.GetType().GetProperty(filterParameter.FilterField).GetValue(x, null).ToString().Contains(filterParameter.FilterValue));

						if (filterParameter.FilterOperator == UrlConstants.FilterOperatorStartsWith)
							books = books.Where(x => x.GetType().GetProperty(filterParameter.FilterField).GetValue(x, null).ToString().StartsWith(filterParameter.FilterValue));

						try
						{
							if (filterParameter.FilterOperator == UrlConstants.FilterOperatorGte)
								books = books.Where(x => int.Parse(x.GetType().GetProperty(filterParameter.FilterField).GetValue(x, null).ToString()) >= int.Parse(filterParameter.FilterValue));

							if (filterParameter.FilterOperator == UrlConstants.FilterOperatorLte)
								books = books.Where(x => int.Parse(x.GetType().GetProperty(filterParameter.FilterField).GetValue(x, null).ToString()) <= int.Parse(filterParameter.FilterValue));
						}
						catch (FormatException)
						{
						}
					}
			total = books.Count();

			return books;
		}


		public static IEnumerable<Book> Sort(this IEnumerable<Book> books, SortParameters parameters)
		{
			if (parameters.SortIsUsed)
				if (parameters.SortField == NameOfHelper<Book>.Property(x => x.Authors))
				{
					if (parameters.SortDir == UrlConstants.SortDirAsc)
						books = books.OrderBy(x => x.Authors.First().FullName);
					if (parameters.SortDir == UrlConstants.SortDirDesc)
						books = books.OrderByDescending(x => x.Authors.First().FullName);
				}
				else if (parameters.SortField == NameOfHelper<Book>.Property(x => x.Genres))
				{
					if (parameters.SortDir == UrlConstants.SortDirAsc)
						books = books.OrderBy(x => x.Genres.First().GenreName);
					if (parameters.SortDir == UrlConstants.SortDirDesc)
						books = books.OrderByDescending(x => x.Genres.First().GenreName);
				}
				else
				{
					if (parameters.SortDir == UrlConstants.SortDirAsc)
						books = books.OrderBy(x => x.GetType().GetProperty(parameters.SortField).GetValue(x, null));
					if (parameters.SortDir == UrlConstants.SortDirDesc)
						books = books.OrderByDescending(x => x.GetType().GetProperty(parameters.SortField).GetValue(x, null));
				}

			return books;
		}
	}
}