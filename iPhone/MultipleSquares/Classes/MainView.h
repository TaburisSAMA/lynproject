#import <UIKit/UIKit.h>
#import <Foundation/Foundation.h>

@interface MainView : UIView {
    IBOutlet UIImageView *image1;
    IBOutlet UIImageView *image2;
    IBOutlet UIImageView *image3;
    IBOutlet UIImageView *image4;
    IBOutlet UILabel *myLabel;
	
	
	
	CGPoint square1Center;
	CGPoint square2Center;
	CGPoint square3Center;
	CGPoint square4Center;
}


@property (nonatomic, retain) UIImageView *image1;
@property (nonatomic, retain) UIImageView *image2;
@property (nonatomic, retain) UIImageView *image3;
@property (nonatomic, retain) UIImageView *image4;
@property (nonatomic, retain) UILabel *myLabel;


- (IBAction)loadView;
- (void)resetSquares;
- (void)moveSquare:(UIImageView *)view toPoint:(CGRect)location;

@end
