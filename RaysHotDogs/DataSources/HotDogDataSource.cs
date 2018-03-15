using System;
using System.Collections.Generic;
using Foundation;
using RaysHotDogs.Core;
using UIKit;

namespace RaysHotDogs
{
    public class HotDogDataSource: UITableViewSource 
    {
        
        private List<HotDog> hotDogs;
        NSString cellIdentifier = new NSString("HotDogCell");

        public HotDogDataSource(List<HotDog> hotDogs, UITableViewController callingController)
        {
            this.hotDogs = hotDogs;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            //HotDogListCell cell = tableView.DequeueReusableCell(cellIdentifier) as HotDogListCell;

            //if(cell == null){
            //    cell = new HotDogListCell(cellIdentifier);
            //}

            //cell.UpdateCell(hotDogs[indexPath.Row].Name, hotDogs[indexPath.Row].Price.ToString(), UIImage.FromFile("Images/hotdog" + hotDogs[indexPath.Row].HotDogId + ".jpg"));


            //For using default layout
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;

            if(cell == null){
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
            }



            var hotDog = hotDogs[indexPath.Row];
            cell.TextLabel.Text = hotDog.Name;
            if(cell.DetailTextLabel != null)
            { 
                cell.DetailTextLabel.Text = hotDog.ShortDescription;
            }
            cell.ImageView.Image = UIImage.FromFile("Images/hotdog" + hotDog.HotDogId + ".jpg");

            return cell;
        }

        public HotDog GetItem(int id)
        {
            return hotDogs[id];
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return hotDogs.Count;
        }
    }
}
