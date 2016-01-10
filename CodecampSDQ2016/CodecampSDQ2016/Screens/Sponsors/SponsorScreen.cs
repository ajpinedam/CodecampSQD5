using System;

using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SponsorScreen : Screen<SponsorViewModel>
	{
		public SponsorScreen ()
		{
			
		}

		public override View CreatePageContent ()
		{
			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 200
			};

			image.SetBinding<SponsorViewModel>(Image.SourceProperty, m => m.Header);

			var headerTitle = new Label
			{
				TextColor = Color.White,
				FontSize = 28,
				FontAttributes = FontAttributes.Bold
			};

			headerTitle.SetBinding<SponsorViewModel>(Label.TextProperty, m => m.HeaderTitle);

			var headerDescription = new Label
			{
				TextColor = Color.White,
				FontSize = 12
			};

			headerDescription.SetBinding<SponsorViewModel>(Label.TextProperty, m => m.HeaderDescription);


			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SponsorViewCell)),
				RowHeight = 100,
				IsPullToRefreshEnabled = true
			};

			listView.SetBinding<SponsorViewModel>(ListView.IsPullToRefreshEnabledProperty, m => m.PullToRefreshEnabled);

			listView.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				((ListView)sender).SelectedItem = null;
			};

			listView.SetBinding<SponsorViewModel>(ListView.ItemsSourceProperty, m => m.Sponsors);

			var builder = new RelativeBuilder()
				.AddView(image)
				.ExpandViewToParentWidth()
				.AddView(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,90,0,0))
				.AddView(headerDescription)
				.BelowOf(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,12,0,0))
				.ApplyConfiguration((p,v)=>{
					p.HeightRequest = 200;
				})
				.BuildLayout();

			return new StackLayout
			{
				Children = 
				{
					builder,
					listView
				}
			};
		}
	}

}
