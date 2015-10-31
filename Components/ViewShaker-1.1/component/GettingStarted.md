Reference the component and adding a Using statement to `ViewShaker`.

In your `ViewDidLoad` event create a new reference to `ViewShaker` passing in either a single `UIView` or an `IList<UIView>`.

```
	public override void ViewDidLoad()
	{
		base.ViewDidLoad();

		var viewShaker = new ViewShaker(this.viewToShake);

		viewShaker.AnimationCompleted += this.OnAnimationCompleted;

		btnShake.TouchUpInside += (sender, e) => 
		{
			viewShaker.Shake();
		};		
	}
	
	private void OnAnimationCompleted(object sender, EventArgs e)
	{
	    new UIAlertView("Animation Finished", 
	        "Animation Finished", 
	        null, 
	        "OK", 
	        null).Show();
	}	
```

The animation duration defaults to 0.5 seconds. 