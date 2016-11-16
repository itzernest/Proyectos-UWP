using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Flickr;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp;
using System.Linq;

using Unidad5Actividad8.Navigation;
using Unidad5Actividad8.ViewModels;

namespace Unidad5Actividad8.Sections
{
    public class MisFotosEnFlickrSection : Section<FlickrSchema>
    {
		private FlickrDataProvider _dataProvider;	

		public MisFotosEnFlickrSection()
		{
			_dataProvider = new FlickrDataProvider();
		}

		public override async Task<IEnumerable<FlickrSchema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new FlickrDataConfig
            {
                QueryType = FlickrQueryType.Id,
                Query = @"145038218@N02",
            };
            return await _dataProvider.LoadDataAsync(config, MaxRecords);
        }

        public override async Task<IEnumerable<FlickrSchema>> GetNextPageAsync()
        {
            return await _dataProvider.LoadMoreDataAsync();
        }

        public override bool HasMorePages
        {
            get
            {
                return _dataProvider.HasMoreItems;
            }
        }

        public override ListPageConfig<FlickrSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<FlickrSchema>
                {
                    Title = "Mis fotos en Flickr",

                    Page = typeof(Pages.MisFotosEnFlickrListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.ImageUrl.ToSafeString());
                    },
                    DetailNavigation = (item) =>
                    {
						return NavInfo.FromPage<Pages.MisFotosEnFlickrDetailPage>(true);
                    }
                };
            }
        }

        public override DetailPageConfig<FlickrSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, FlickrSchema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = "";
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.ImageUrl = ItemViewModel.LoadSafeUrl(item.ImageUrl.ToSafeString());
                    viewModel.Content = null;
					viewModel.Source = item.FeedUrl;
                });

                var actions = new List<ActionConfig<FlickrSchema>>
                {
                };

                return new DetailPageConfig<FlickrSchema>
                {
                    Title = "Mis fotos en Flickr",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }
    }
}
