using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Core.DB;
using Core.Entities.DTOs;

namespace Web.Server
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register); 
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			Mapper.CreateMap<Book, BookDTO>()
				.ForMember(x => x.Authors, opt => opt.MapFrom(x => String.Join(", ", x.Authors.Select(y => y.FullName))))
				.ForMember(x => x.Genres, opt => opt.MapFrom(x => String.Join(", ", x.Genres.Select(y => y.GenreName))));
			Mapper.CreateMap<BookDTO, Book>()
				.ForMember(x => x.Authors, opt => opt.MapFrom(x => x.Authors.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(y => new Author { FullName = y.Trim(' ') }).ToList()))
				.ForMember(x => x.Genres, opt => opt.MapFrom(x => x.Genres.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(y => new Genre { GenreName = y.Trim(' ') }).ToList()));
		}
	}
}
