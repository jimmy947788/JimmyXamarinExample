//
//  CustomView.m
//  MyLibrary
//
//  Created by Jimmy Wu on 2017/6/1.
//  Copyright © 2017年 Jimmy Wu. All rights reserved.
//

#import "CustomView.h"

@interface CustomView ()
@property (nonatomic, assign) BOOL isCustomized;
@end


@implementation CustomView

@synthesize name = _name, delegate = _delegate, isCustomized = _isCustomized;


-(id) init
{
    if(self = [super init]) {
        // do initialization hurr
        self.isCustomized = true;
    }
    
    return self;
}

-(void) touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event
{
    [self.delegate viewWasTouched:self];
}

-(void) customizeView:(CGRect)fromRect withText:(NSString *)message
{
    //if(self.isCustomized == false && [message length] > 0) {
    
    UITextView *txtView = [[UITextView alloc] init];
    txtView.textAlignment = NSTextAlignmentCenter;
    txtView.textColor = [UIColor blueColor];
    
    NSLog(@"X:%f, Y:%f, Width:%f, Height:%f",
          fromRect.origin.x,
          fromRect.origin.y,
          fromRect.size.width,
          fromRect.size.height);
    
    txtView.frame = fromRect;
    //        txtView.lineBreakMode = UILineBreakModeWordWrap;
    
    // set inner shadow
    txtView.layer.masksToBounds = NO;
    txtView.layer.cornerRadius = 8;
    txtView.layer.shadowOffset = CGSizeMake(-15, 20);
    txtView.layer.shadowRadius = 5;
    txtView.layer.shadowOpacity = 0.5;
    txtView.layer.shadowColor = [[UIColor blackColor] CGColor];
    
    txtView.text = message;
    //        [txtView sizeToFit];
    
    [self addSubview:txtView];
    //}
}

@end
