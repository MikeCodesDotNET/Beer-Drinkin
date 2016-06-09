# SWTableViewCell

An easy-to-use UITableViewCell subclass that implements a swipeable content view which exposes utility buttons (similar to iOS 7 Mail Application)

## Functionality
### Right Utility Buttons
Utility buttons that become visible on the right side of the Table View Cell when the user swipes left. This behavior is similar to that seen in the iOS apps Mail and Reminders.

### Left Utility Buttons
Utility buttons that become visible on the left side of the Table View Cell when the user swipes right. 

### Features
* Dynamic utility button scaling: 
  As you add more buttons to a cell, the other buttons on that side get smaller to make room
* Smart selection: 
  The cell will pick up touch events and either scroll the cell back to center or fire the delegate method `public override void RowSelected(UITableView tableView, NSIndexPath indexPath)` 
  The cell will not be considered selected when the user touches the cell while utility buttons are visible, instead the cell will slide back into place (same as iOS 7 Mail App functionality)
* Create utility buttons with either a title or an icon along with a RGB color

## Usage

### Standard Table View Cells

In your `public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)` method you set up the SWTableView cell and add an arbitrary amount of utility buttons to it, using the `LeftUtilityButtons` and `RightUtilityButtons` properties of the `SWTableViewCell` object.

### Custom Table View Cells

Thanks to [Matt Bowman](https://github.com/MattCBowman) you can now create custom table view cells using Interface Builder that have the capabilities of an SWTableViewCell

The first step is to design your cell either in a standalone nib or inside of a table view using prototype cells. Make sure to set the custom class on the cell in interface builder to the subclass you made for it. Then your new type should be a subclass of `SWTableViewCell`
If you are using a separate nib and not a prototype cell, you'll need to be sure to register the nib in your table view.

Then, in the `public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)` method of your `UITableViewDelegate`, initialize your custom cell.

### Delegate

The delegate `SWTableViewCellDelegate` is used by the developer to find out which button was pressed. There are five methods:

	public override void ScrollingToState(SWTableViewCell cell, SWCellState state)
	public override void DidTriggerLeftUtilityButton(SWTableViewCell cell, int index)
	public override void DidTriggerRightUtilityButton(SWTableViewCell cell, int index)
	public override bool ShouldHideUtilityButtonsOnSwipe(SWTableViewCell cell)
	public override bool CanSwipeToState(SWTableViewCell cell, SWCellState state)

The index signifies which utility button the user pressed, for each side the button indices are ordered from right to left 0...n

