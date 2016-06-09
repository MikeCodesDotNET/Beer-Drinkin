
About XCardView
======================

`XCardView` displays its views as a stack of cards. Cards can be swiped off physically by the user or programmatically from code.

`XCardView` wraps a native third-party library in a Xamarin binding library that targets the new **Unified API**.

Loading Cards
=============

The `ICardViewDataSource` interface defines a `NextViewForCardView` method that returns a view for the next card.

An `XCardView` appears like a stack of cards being viewed from the top. Edges of the lower cards are visible underneath the top card. `XCardView` will prefetch three views in advance to animate them. A new card is fetched every time a card is swiped.

Events
======

An `XCardView` has the following events:

- DidSwipeLeft

- DidSwipeRight

- DidCancelSwipe

- DidStartSwipingCardAtLocation

- SwipingCardAtLocation

- DidEndSwipingCard

***

XCardView wraps Zhixuan Lai’s _ZLSwipeableView_ in a Xamarin binding library.