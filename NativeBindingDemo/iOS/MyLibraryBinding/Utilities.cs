using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace MyLibraryBinding
{
	// typedef void (^UtilityCallbackDelegate)(NSString *);
	delegate void UtilityCallbackDelegate(string arg0);

	// @interface Utilities : NSObject
	[BaseType(typeof(NSObject))]
	interface Utilities
	{
		// +(NSString *)echo:(NSString *)message;
		[Static]
		[Export("echo:")]
		string Echo(string message);

		// -(NSString *)hello:(NSString *)name;
		[Export("hello:")]
		string Hello(string name);

		// -(NSInteger)add:(NSInteger)operandUn and:(NSInteger)operandDeux;
		[Export("add:and:")]
		nint Add(nint operandUn, nint operandDeux);

		// -(NSInteger)multiply:(NSInteger)operandUn and:(NSInteger)operandDeux;
		[Export("multiply:and:")]
		nint Multiply(nint operandUn, nint operandDeux);

		// -(void)setCallback:(UtilityCallbackDelegate)callback;
		[Export("setCallback:")]
		void SetCallback(UtilityCallbackDelegate callback);

		// -(void)invokeCallback:(NSString *)message;
		[Export("invokeCallback:")]
		void InvokeCallback(string message);
	}
}
