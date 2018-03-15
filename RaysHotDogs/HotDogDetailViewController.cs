using Foundation;
using RaysHotDogs.Core;
using System;
using UIKit;
using System.CodeDom.Compiler;

namespace RaysHotDogs
{
    public partial class HotDogDetailViewController : UIViewController
    {

        public HotDog SelectedHotDog { get; set; }

        public HotDogDetailViewController (IntPtr handle) : base (handle)
        {
            HotDogDataService hotDogDataService = new HotDogDataService();
            SelectedHotDog = hotDogDataService.GetHotDogById(1);
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            this.ParentViewController.NavigationItem.Title = SelectedHotDog.Name;
            this.Title = SelectedHotDog.Name;
            DataBindUI();

            AddToCartBtn.TouchUpInside += (object sender, EventArgs e) =>
            {
                UIAlertView msg = new UIAlertView(){
                    Title="Ray's Hot Dogs", Message ="That hot dog was added to your order"
                };
                msg.AddButton("OK");
                msg.Show();
            }; 

            CancelBtn.TouchUpInside += (object sender, EventArgs e) =>
            {
                this.DismissModalViewController(true);
                UIAlertView cancelConfirm = new UIAlertView()
                {
                    Title="Ray's Hot Dogs",
                    Message = "Do you really want to cancel?"
                };
                cancelConfirm.AddButton("Yes");
                cancelConfirm.AddButton("No");
                cancelConfirm.Show();
            };

        
		}

        private void DataBindUI()
        {
            UIImage img = UIImage.FromFile("Images/" + SelectedHotDog.ImagePath + ".jpg");
            HotDogImageView.Image = img;
            NameLabel.Text = SelectedHotDog.Name;
            DescLabel.Text = SelectedHotDog.ShortDescription;
            DescriptionTB.Text = SelectedHotDog.Description;
            PriceLabel.Text = "$" + SelectedHotDog.Price.ToString();
        }
	}
}