using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using System;
using UIKit;

namespace Phoneword.iOS.Views
{
    public partial class MyCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MyCell");

        public string Title { get { return TextLabel.Text; } set { TextLabel.Text = value; } }

        protected MyCell(IntPtr handle) : base(handle)
        {
            //this.DelayBind(() =>
            //{
            //    var set = this.CreateBindingSet<MyCell, string>();
            //    Console.WriteLine(DataContext.ToString());
            //    set.Bind().For(c => c.Label.Text).To(vm => vm);
            //    set.Apply();
            //});
        }
    }

    public class MyTableViewSource : MvxTableViewSource
    {
        private NSString cellIdentifier = new NSString("MyCell");

        public MyTableViewSource(UITableView tableView)
            : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (MyCell)tableView.DequeueReusableCell(cellIdentifier);
            var set = cell.CreateBindingSet<MyCell, string> ();
            set.Bind().For(c => c.Title).To(vm => vm);
            set.Apply();
            return cell;
        }
    }
}
