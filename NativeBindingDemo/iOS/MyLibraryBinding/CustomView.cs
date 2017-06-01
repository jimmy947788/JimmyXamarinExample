using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MyLibraryBinding
{
	// @protocol CustomViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface CustomViewDelegate
	{
		// @required -(void)viewWasTouched:(UIView *)view;
		[Abstract]
		[Export("viewWasTouched:")]
		void ViewWasTouched(UIView view);
	}

	// @interface CustomView : UIView
	[BaseType(typeof(UIView))]
	interface CustomView
	{
		// @property (nonatomic, strong) NSString * name;
		[Export("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		[Wrap("WeakDelegate")]
		CustomViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<CustomViewDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)customizeView:(CGRect)fromRect withText:(NSString *)message;
		[Export("customizeView:withText:")]
		void CustomizeView(CGRect fromRect, string message);
	}
}
