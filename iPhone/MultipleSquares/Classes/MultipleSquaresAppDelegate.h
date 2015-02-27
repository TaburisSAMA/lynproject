//
//  MultipleSquaresAppDelegate.h
//  MultipleSquares
//
//  Created by Maksudul Alam on 4/12/09.
//  Copyright Commlink 2009. All rights reserved.
//

#import <UIKit/UIKit.h>

@class MainView;

@interface MultipleSquaresAppDelegate : NSObject <UIApplicationDelegate> {
	IBOutlet UIWindow *window;
	IBOutlet MainView *mainView;
}

@property (nonatomic, retain) UIWindow *window;
@property (nonatomic, retain) MainView *mainView;


@end

