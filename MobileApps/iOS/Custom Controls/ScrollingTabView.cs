using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using MikeCodesDotNET.iOS;
using UIKit;

namespace BeerDrinkin.iOS.CustomControls
{
    public class ScrollingTabView : UIView, IUIScrollViewDelegate
    {
        float tabbarHeight = 42;

        public ScrollingTabView(List<UIViewController> viewControllers)
        {
            //Create views
            tabbarBackground = new UIView();
            selectedTabUnderlineView = new UIStackView();
            contentScrollView = new UIScrollView();

            ViewControllers = viewControllers;
            DefaultColors();

            CurrentIndex = 0;
            TabItemSelected += HandleTabItemSelected;
        }

        public UIColor TabbarBackgroundColor { get; set;}
        public UIColor SelectedTabUnderlineColor { get; set; }
        public UIColor SelectedTabTextColor { get; set; }
        public UIColor TabTextColor { get; set; }
        public UIColor ContentBackgroundColor { get; set;}
        public int CurrentIndex { get; private set;}

        public List<UIViewController> ViewControllers { get; private set;}

        public override void LayoutSubviews()
        {
            //ContentView 
            contentScrollView = new UIScrollView();
            contentScrollView.Frame = new CoreGraphics.CGRect(0, tabbarHeight, Bounds.Width, Bounds.Height - tabbarHeight - 98);
            contentScrollView.BackgroundColor = ContentBackgroundColor;
            contentScrollView.PagingEnabled = true;

            //tabbar 
            tabbarBackground.BackgroundColor = TabbarBackgroundColor;
            tabbarBackground.Frame = new CoreGraphics.CGRect(0, 0, Bounds.Width, tabbarHeight);

            nfloat tabbuttonWidth = 0;
            foreach (var viewController in ViewControllers)
            {
                var index = ViewControllers.IndexOf(viewController);

                var button = new UIButton(UIButtonType.RoundedRect);
                button.Tag = index;
                button.SetTitle(viewController.Title, UIControlState.Normal);
                button.Font = Helpers.Style.Fonts.ScrollTabbarTitle;

                if(index == 0)
                    button.SetTitleColor(SelectedTabTextColor, UIControlState.Normal);
                else
                    button.SetTitleColor(TabTextColor, UIControlState.Normal);

                tabbuttonWidth = Bounds.Width / ViewControllers.Count +1;
                button.Frame = new CoreGraphics.CGRect(tabbuttonWidth * index, 2, tabbuttonWidth, tabbarHeight - 4);
                button.TouchUpInside += delegate 
                {
                    CurrentIndex = index;
                    TabItemSelected(index);
                };

                tabbarBackground.AddSubview(button);
                viewController.View.Frame = new CGRect(Bounds.Width * index, 0, Bounds.Width, contentScrollView.Frame.Height);

                contentScrollView.AddSubview(viewController.View);
            }

            contentScrollView.ContentSize = new CGSize(Bounds.Width * ViewControllers.Count, 400);
            contentScrollView.Scrolled += ContentScrolled;

            //Underline 
            selectedTabUnderlineView = new UIView();
            selectedTabUnderlineView.BackgroundColor = SelectedTabUnderlineColor;
            selectedTabUnderlineView.Frame = new CGRect(0, tabbarHeight - 4, tabbuttonWidth, 4);
                       
            //Add views
            AddSubview(contentScrollView);
            AddSubview(tabbarBackground);
            AddSubview(selectedTabUnderlineView);
        }

        void ContentScrolled(object sender, EventArgs e)
        { 
            var x = contentScrollView.ContentOffset.X;
            selectedTabUnderlineView.Frame = new CGRect(x / ViewControllers.Count, selectedTabUnderlineView.Frame.Y, selectedTabUnderlineView.Frame.Width, selectedTabUnderlineView.Frame.Height);

            if (x < 369)
            {
                UpdateTabBar(0);
            }
            if (x > 370 && x < 739)
            {
                UpdateTabBar(1);
            }
            if (x > 740 && x < 1125)
            {
                UpdateTabBar(2);
            }
        }

        void HandleTabItemSelected(int index)
        {
            MoveToIndex(index);
            UpdateTabBar(index);
        }

        void MoveToIndex(int index)
        {
            if (index >= 0 && index < ViewControllers.Count)
            {
                CurrentIndex = index;
                var rect = new CGRect(Frame.Width * index, 0, Frame.Size.Width, Frame.Size.Height);
                contentScrollView.ScrollRectToVisible(rect, true);
            }
        }

        void UpdateTabBar(int index)
        {
            if (index == CurrentIndex)
                return;
            
            var newSelectedButton = tabbarBackground.Subviews[index] as UIButton;
            newSelectedButton.SetTitleColor(SelectedTabTextColor, UIControlState.Normal);

            var oldSelectedButton = tabbarBackground.Subviews[CurrentIndex] as UIButton;
            oldSelectedButton.SetTitleColor(TabTextColor, UIControlState.Normal);

            CurrentIndex = index;
        }

        void DefaultColors()
        {
            //These are unique for Beer Drinkin
            TabbarBackgroundColor = "0D93FF".ToUIColor();
            SelectedTabUnderlineColor = "3FCBB6".ToUIColor();
            SelectedTabTextColor = "F5F5F5".ToUIColor();
            TabTextColor = "1F77BC".ToUIColor();
            ContentBackgroundColor = "F5F5F5".ToUIColor();
        }

        public delegate void TabItemSelectedHandler(int index);
        public event TabItemSelectedHandler TabItemSelected;

        UIView tabbarBackground;
        UIView selectedTabUnderlineView; 
        UIScrollView contentScrollView;

    }
}

