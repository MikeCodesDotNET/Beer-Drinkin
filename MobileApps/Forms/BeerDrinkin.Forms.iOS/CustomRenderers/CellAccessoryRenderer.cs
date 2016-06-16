using BeerDrinkin.Forms.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(CellAccessoryRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellAccessoryRenderer))]
[assembly: ExportRenderer(typeof(ImageCell), typeof(ImageCellAccessoryRenderer))]

namespace BeerDrinkin.Forms.iOS.CustomRenderers
{
    public class CellAccessoryRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell,
            UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            switch (item.StyleId)
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;

                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;

                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;

                case "detail-disclosure-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;

                case "disclosure":
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;

                default:
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
            }
            return cell;
        }
    }

    public class ViewCellAccessoryRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell,
            UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            switch (item.StyleId)
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;

                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;

                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;

                case "detail-disclosure-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;

                case "disclosure":
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;

                default:
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
            }
            return cell;
        }
    }

    public class ImageCellAccessoryRenderer : ImageCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell,
            UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            switch (item.StyleId)
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;

                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;

                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;

                case "detail-disclosure-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;

                case "disclosure":
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;

                default:
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
            }
            return cell;
        }
    }
}