//
//  MultipleSquaresAppDelegate.m
//  MultipleSquares
//
//  Created by Maksudul Alam on 4/12/09.
//  Copyright Commlink 2009. All rights reserved.
//

#import "MultipleSquaresAppDelegate.h"


@implementation MultipleSquaresAppDelegate

@synthesize window, mainView;



- (void)applicationDidFinishLaunching:(UIApplication *)application {	
	
	// Override point for customization after app launch	
    //[window addSubview:viewController.view];
	[mainView loadView];
	[window makeKeyAndVisible];
}


- (void)dealloc {
	[mainView release];
	[window release];
	[super dealloc];
}


@end
