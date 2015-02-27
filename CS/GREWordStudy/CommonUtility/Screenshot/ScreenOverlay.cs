using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CommonUtility.Screenshot
{
    public partial class ScreenOverlay : Form
    {

        private readonly Pen _eraserPen = new Pen(Color.FromArgb(255, 255, 192), 1);
        private readonly Pen _myPen = new Pen(Color.Blue, 1);
        private readonly Graphics _g;
        private Point _clickPoint;
        private Point _currentBottomRight;
        private Point _currentTopLeft;
        private bool _leftButtonDown;

        public Form ParentForm { get; set; }


        public ScreenOverlay()
        {
            InitializeComponent();

            MouseDown += mouse_Click;
            MouseUp += mouse_Up;
            MouseMove += mouse_Move;
            _myPen.DashStyle = DashStyle.Dot;
            _g = CreateGraphics();
        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {
            _g.Clear(Color.FromArgb(255, 255, 192));
            _leftButtonDown = true;
            _clickPoint = new Point(MousePosition.X, MousePosition.Y);
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {
            _leftButtonDown = false;
            Hide();
            System.Threading.Thread.Sleep(100);
            
            SaveScreen();
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            //Resize (actually delete then re-draw) the rectangle if the left mouse button is held down
            if (_leftButtonDown)
            {
                //Erase the previous rectangle
                _g.DrawRectangle(_eraserPen, _currentTopLeft.X, _currentTopLeft.Y, _currentBottomRight.X - _currentTopLeft.X, _currentBottomRight.Y - _currentTopLeft.Y);

                //Calculate X Coordinates
                if (Cursor.Position.X < _clickPoint.X)
                {
                    _currentTopLeft.X = Cursor.Position.X;
                    _currentBottomRight.X = _clickPoint.X;
                }
                else
                {
                    _currentTopLeft.X = _clickPoint.X;
                    _currentBottomRight.X = Cursor.Position.X;
                }

                //Calculate Y Coordinates
                if (Cursor.Position.Y < _clickPoint.Y)
                {
                    _currentTopLeft.Y = Cursor.Position.Y;
                    _currentBottomRight.Y = _clickPoint.Y;
                }
                else
                {
                    _currentTopLeft.Y = _clickPoint.Y;
                    _currentBottomRight.Y = Cursor.Position.Y;
                }

                //Draw a new rectangle
                _g.DrawRectangle(_myPen, _currentTopLeft.X, _currentTopLeft.Y, _currentBottomRight.X - _currentTopLeft.X, _currentBottomRight.Y - _currentTopLeft.Y);
            }
        }

        private void SaveScreen()
        {
            var StartPoint = new Point(_currentTopLeft.X, _currentTopLeft.Y);
            var bounds = new Rectangle(_currentTopLeft.X, _currentTopLeft.Y, _currentBottomRight.X - _currentTopLeft.X, _currentBottomRight.Y - _currentTopLeft.Y);
            ScreenShot.CaptureImageToClipboard(StartPoint, Point.Empty, bounds);
        }
    }
}
