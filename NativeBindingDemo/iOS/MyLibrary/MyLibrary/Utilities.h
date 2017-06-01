//
//  Utilities.h
//  MyLibrary
//
//  Created by Jimmy Wu on 2017/6/1.
//  Copyright © 2017年 Jimmy Wu. All rights reserved.
//

#ifndef Utilities_h
#define Utilities_h


#endif /* Utilities_h */

#import <Foundation/Foundation.h>

// This is how to define a block function prototype.
typedef void (^UtilityCallbackDelegate) (NSString *message);

@interface Utilities : NSObject {
    UtilityCallbackDelegate _callback;
}

-(id) init;
+(NSString *) echo:(NSString *)message;
-(NSString *) hello:(NSString *)name;
-(NSInteger) add:(NSInteger)operandUn and:(NSInteger) operandDeux;
-(NSInteger) multiply:(NSInteger)operandUn and:(NSInteger)operandDeux;
-(void) setCallback:(UtilityCallbackDelegate) callback;
-(void) invokeCallback:(NSString *) message;

@end
