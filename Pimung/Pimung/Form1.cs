using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ResizeControl;

namespace Pimung
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResizableControl myControl = new ResizableControl();
            myControl.MakeControlResizable(panel1, 10, null, ResizeLocation.Bottom, new Size(1, 100), new Size(9999, 9999));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 100, panel1.Height , 200, panel1.Height );
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        

       
    }
}

namespace ResizeControl
{
    public enum ResizeLocation
    {
        Top = 1,
        Bottom = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,
        TopLeft = 1 << 4,
        TopRight = 1 << 5,
        BottomLeft = 1 << 6,
        BottomRight = 1 << 7,
        All = (1 << 7) + (1 << 6) + (1 << 5) + (1 << 4) + (1 << 3) + (1 << 2) + (1 << 1) + 1,
        Center = 1 << 8
    }

    public class ResizableControl
    {
        private Control control;
        private int handleSize;
        private Size minSize;
        private Size maxSize;
        private ResizeLocation locations;
        private ResizeLocation draggingLocation;
        private Point bottomRightPos; // Absolute
        private bool isDragging;

        // Too lazy for any overloads
        /// <summary>
        /// Make a control form resizable
        /// </summary>
        /// <param name="form">The control you want to make resizable</param>
        /// <param name="handleSize">Margin size to drag the control</param>
        /// <param name="children">Children controls that respond to mouse events (that will be dragged)</param>
        /// <param name="locations">Which sides/corners can be dragged to resize the control</param>
        /// <param name="minSize">Minimum size</param>
        /// <param name="maxSize">Maximum size</param>
        public void MakeControlResizable(Control control, int handleSize, Control[] children, ResizeLocation resizeHandles, Size minSize, Size maxSize)
        {
            this.control = control;
            this.handleSize = handleSize;
            this.locations = resizeHandles;
            this.minSize = minSize;
            this.maxSize = maxSize;

            // Mouse events for children
            if (children != null)
                if (children.Length > 0)
                    foreach (Control child in children)
                    {
                        child.MouseEnter += mouseEnter;
                        child.MouseLeave += mouseLeave;
                        child.MouseDown += mouseDown;
                        child.MouseUp += mouseUp;
                        child.MouseMove += mouseMove;
                    }

            // Mouse events for the control itself
            control.MouseEnter += mouseEnter;
            control.MouseLeave += mouseLeave;
            control.MouseDown += mouseDown;
            control.MouseUp += mouseUp;
            control.MouseMove += mouseMove;
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            // Get the control the mouse is over
            Control senderControl;
            try
            {
                senderControl = (Control)sender;
            }
            catch
            {
                return;
            }

            // Figure out what cursor to use
            ResizeLocation location = getMouseLocation();
            if (Convert.ToBoolean(location & locations))
            {
                if (location == ResizeLocation.TopLeft || location == ResizeLocation.BottomRight)
                    senderControl.Cursor = Cursors.SizeNWSE;
                else if (location == ResizeLocation.TopRight || location == ResizeLocation.BottomLeft)
                    senderControl.Cursor = Cursors.SizeNESW;
                else if (location == ResizeLocation.Top || location == ResizeLocation.Bottom)
                    senderControl.Cursor = Cursors.SizeNS;
                else if (location == ResizeLocation.Left || location == ResizeLocation.Right)
                    senderControl.Cursor = Cursors.SizeWE;
                else
                    senderControl.Cursor = Cursors.Default;
            }
            else
            {
                senderControl.Cursor = Cursors.Default;
            }
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Control senderControl;
            try
            {
                senderControl = (Control)sender;
            }
            catch
            {
                return;
            }

            control.Cursor = Cursors.Default;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            draggingLocation = getMouseLocation();
            if (Convert.ToBoolean(draggingLocation & locations))
            {
                isDragging = true;
                bottomRightPos = control.PointToScreen(new Point(control.Size));
                mouseMove(sender, e);
            }
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            Size controlSize = control.Size;
            // Absolute positions
            Point controlLocation = control.PointToScreen(Point.Empty);
            Point mousePos = Control.MousePosition;

            // Resize if dragging
            if (isDragging)
            {
                switch (draggingLocation)
                {
                    case ResizeLocation.Top:
                        controlSize.Height = bottomRightPos.Y - mousePos.Y;
                        controlLocation.Y = mousePos.Y;
                        break;
                    case ResizeLocation.Bottom:
                        controlSize.Height = mousePos.Y - controlLocation.Y;
                        break;
                    case ResizeLocation.Left:
                        controlSize.Width = bottomRightPos.X - mousePos.X;
                        controlLocation.X = mousePos.X;
                        break;
                    case ResizeLocation.Right:
                        controlSize.Width = mousePos.X - controlLocation.X;
                        break;

                    case ResizeLocation.TopLeft:
                        controlSize.Height = bottomRightPos.Y - mousePos.Y;
                        controlLocation.Y = mousePos.Y;
                        controlSize.Width = bottomRightPos.X - mousePos.X;
                        controlLocation.X = mousePos.X;
                        break;
                    case ResizeLocation.TopRight:
                        controlSize.Height = bottomRightPos.Y - mousePos.Y;
                        controlLocation.Y = mousePos.Y;
                        controlSize.Width = mousePos.X - controlLocation.X;
                        break;
                    case ResizeLocation.BottomLeft:
                        controlSize.Height = mousePos.Y - controlLocation.Y;
                        controlSize.Width = bottomRightPos.X - mousePos.X;
                        controlLocation.X = mousePos.X;
                        break;
                    case ResizeLocation.BottomRight:
                        controlSize.Height = mousePos.Y - controlLocation.Y;
                        controlSize.Width = mousePos.X - controlLocation.X;
                        break;
                    case ResizeLocation.Center:
                        // Nothing
                        break;
                    default:
                        // Same here
                        break;
                }

                // Size must be inside bounds
                bool dontMoveX = false, dontMoveY = false;
                if (controlSize.Height < minSize.Height)
                {
                    controlSize.Height = minSize.Height;
                    dontMoveY = true;
                }
                if (controlSize.Width < minSize.Width)
                {
                    controlSize.Width = minSize.Width;
                    dontMoveX = true;
                }
                if (controlSize.Height > maxSize.Height)
                {
                    controlSize.Height = maxSize.Height;
                    dontMoveY = true;
                }
                if (controlSize.Width > maxSize.Width)
                {
                    controlSize.Width = maxSize.Width;
                    dontMoveX = true;
                }

                // Set new size and location
                ResizeLocation special = ResizeLocation.Top | ResizeLocation.TopLeft | ResizeLocation.BottomLeft | ResizeLocation.TopRight | ResizeLocation.Left;
                if (Convert.ToBoolean(draggingLocation & special))
                {
                    if (dontMoveX)
                        controlLocation.X = bottomRightPos.X - controlSize.Width;
                    if (dontMoveY)
                        controlLocation.Y = bottomRightPos.Y - controlSize.Height;
                }

                // Make location relative
                Point relativeToControl = control.PointToClient(controlLocation);
                controlLocation = new Point(control.Location.X + relativeToControl.X,
                                            control.Location.Y + relativeToControl.Y);

                // Set new bound
                control.SetBounds(controlLocation.X, controlLocation.Y, controlSize.Width, controlSize.Height);
            }
            // Else update cursor
            else
            {
                mouseEnter(sender, e);
            }
        }

        /// <summary>
        /// Gets mouse "ResizeLocation"
        /// </summary>
        /// <returns>The mouse "ResizeLocation"</returns>
        private ResizeLocation getMouseLocation()
        {
            Point mousePos = getRelativeMousePoint();
            ResizeLocation location;
            if (mousePos.X <= handleSize)
            {
                if (mousePos.Y <= handleSize)
                    location = ResizeLocation.TopLeft;
                else if (mousePos.Y >= control.Height - handleSize)
                    location = ResizeLocation.BottomLeft;
                else
                    location = ResizeLocation.Left;
            }
            else if (mousePos.X >= control.Width - handleSize)
            {
                if (mousePos.Y <= handleSize)
                    location = ResizeLocation.TopRight;
                else if (mousePos.Y >= control.Height - handleSize)
                    location = ResizeLocation.BottomRight;
                else
                    location = ResizeLocation.Right;
            }
            else
            {
                if (mousePos.Y <= handleSize)
                    location = ResizeLocation.Top;
                else if (mousePos.Y >= control.Height - handleSize)
                    location = ResizeLocation.Bottom;
                else
                    location = ResizeLocation.Center;
            }
            return location;
        }

        /// <summary>
        /// Get mouse position relative to the form
        /// </summary>
        /// <returns>The mouse position relative to the form</returns>
        private Point getRelativeMousePoint()
        {
            return new Point(Control.MousePosition.X - control.PointToScreen(Point.Empty).X,
                             Control.MousePosition.Y - control.PointToScreen(Point.Empty).Y);
        }
    }

}
