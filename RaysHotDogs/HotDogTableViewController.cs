using Foundation;
using RaysHotDogs.Core;
using System;
using UIKit;

namespace RaysHotDogs
{
    public partial class HotDogTableViewController : UITableViewController
    {
        HotDogDataService dataService = new HotDogDataService();

        public HotDogTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            var hotDogs = dataService.GetAllHotDogs();
            var datasource = new HotDogDataSource(hotDogs, this);

            TableView.Source = datasource;

            this.NavigationItem.Title = "Ray's Hot Dog Menu";
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
            base.PrepareForSegue(segue, sender);

            if(segue.Identifier == "HotDogDetailSegue")
            {
                var hotDogDetailViewController = segue.DestinationViewController as HotDogDetailViewController;
                if(hotDogDetailViewController != null)
                {
                    var source = TableView.Source as HotDogDataSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = source.GetItem(rowPath.Row);
                    hotDogDetailViewController.SelectedHotDog = item;
                }
            }
		}
	}
}