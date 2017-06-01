//
//  CustomView.h
//  MyLibrary
//
//  Created by Jimmy Wu on 2017/6/1.
//  Copyright © 2017年 Jimmy Wu. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "CustomViewDelegate.h"

#ifndef CustomView_h
#define CustomView_h


#endif /* CustomView_h */


@interface CustomView : UIView
{
    
}

@property (nonatomic, strong) NSString* name;
@property (nonatomic, assign) id <CustomViewDelegate> delegate;


-(void) customizeView:(CGRect)fromRect withText:(NSString *)message;

@end
