//
//  CustomViewDelegate.h
//  MyLibrary
//
//  Created by Jimmy Wu on 2017/6/1.
//  Copyright © 2017年 Jimmy Wu. All rights reserved.
//

#ifndef CustomViewDelegate_h
#define CustomViewDelegate_h


#endif /* CustomViewDelegate_h */


#import "CustomView.h"
#import <Foundation/Foundation.h>

@protocol CustomViewDelegate<NSObject>

@required
-(void)viewWasTouched:(UIView *)view;


@end
