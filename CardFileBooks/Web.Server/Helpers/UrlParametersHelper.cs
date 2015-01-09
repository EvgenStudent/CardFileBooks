using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Web.Server.Models;

namespace Web.Server.Helpers
{
	public class UrlParametersHelper
	{
		private const string TakeKey = "take";
		private const string SkipKey = "skip";
		private const string SortFieldKey = "sort[0][field]";
		private const string SortDirKey = "sort[0][dir]";
		private const string FilterLogicKey = "filter[logic]";
		private const string FilterFieldTemplateKey = "filter[filters][{0}][field]";
		private const string FilterOperatorTemplateKey = "filter[filters][{0}][operator]";
		private const string FilterValueTemplateKey = "filter[filters][{0}][value]";

		private readonly NameValueCollection _parameters;

		public UrlParametersHelper(string query)
		{
			_parameters = HttpUtility.ParseQueryString(query);
			InitSortParams();
			InitFilterParams();
		}

		public int Take
		{
			get { return _parameters.AllKeys.Contains(TakeKey) ? int.Parse(_parameters[TakeKey]) : 10; }
		}

		public int Skip
		{
			get { return _parameters.AllKeys.Contains(SkipKey) ? int.Parse(_parameters[SkipKey]) : 0; }
		}

		public SortParameters SortParams { get; private set; }

		public IList<FilterParameters> FilterParams { get; private set; }

		public bool FilterIsUsed
		{
			get { return FilterParams.Any(); }
		}

		private void InitSortParams()
		{
			SortParams = new SortParameters
			{
				SortDir = _parameters.AllKeys.Contains(SortDirKey) ? _parameters[SortDirKey] : string.Empty,
				SortField = _parameters.AllKeys.Contains(SortFieldKey) ? _parameters[SortFieldKey] : string.Empty
			};
		}

		private void InitFilterParams()
		{
			FilterParams = new List<FilterParameters>();

			for (int i = 0; ; i++)
			{
				string fullFieldkey = string.Format(FilterFieldTemplateKey, i);
				string fullOperatorkey = string.Format(FilterOperatorTemplateKey, i);
				string fullValuekey = string.Format(FilterValueTemplateKey, i);
				if (_parameters.AllKeys.Contains(fullFieldkey) && _parameters.AllKeys.Contains(fullOperatorkey) && _parameters.AllKeys.Contains(fullValuekey))
				{
					FilterParams.Add(new FilterParameters
					{
						FilterLogic = _parameters[FilterLogicKey],
						FilterField = _parameters[fullFieldkey],
						FilterOperator = _parameters[fullOperatorkey],
						FilterValue = _parameters[fullValuekey]
					});
				}
				else
				{
					break;
				}
			}
		}
	}
}