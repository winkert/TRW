using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.GameLibraries.GameCore;

namespace TRW.Games.Pong.GameObjects
{
    internal class Ball : IVisibleGameObject
    {
        internal Ball(double initialSpeed, double maxLeft, double maxTop)
        {
            Speed = initialSpeed;
            VelocityX = Statics.R.NextDouble() * Speed;
            VelocityY = Statics.R.NextDouble() * Speed;

            LeftOuterBound = maxLeft;
            TopOuterBound = maxTop;
        }

        public string Name => "Ball";

        public string Description => "Pong Ball";

        public bool IsPlayable => false;

        public Bitmap ObjectImage { get; set; }
        public int ObjectId { get; set; }

        #region UI Positions
        internal double Left { get; private set; }
        internal double Top { get; private set; }
        #endregion

        System.Windows.Controls.Image _wpfImage;
        public System.Windows.Controls.Image WpfImage
        {
            get
            {
                if (_wpfImage == null)
                {
                    _wpfImage = new System.Windows.Controls.Image() { Source = Statics.ToWpfImage(ObjectImage) };
                    _wpfImage.Width = 30;
                    _wpfImage.Height = 30;
                }
                return _wpfImage;
            }
        }

        internal double Speed { get; private set; }
        internal double VelocityX { get; private set; }
        internal double VelocityY { get; private set; }

        internal double LeftOuterBound { get; private set; }
        internal double TopOuterBound { get; private set; }

        public void GameTimerTick()
        {
            if (WpfImage != null)
            {
                WpfImage.Dispatcher.Invoke(new Action(() =>
                {
                    Left = System.Windows.Controls.Canvas.GetLeft(WpfImage);
                    Top = System.Windows.Controls.Canvas.GetTop(WpfImage);
                }));

                double currentLeft = Left;
                double currentTop = Top;

                double newLeft = currentLeft + VelocityX;
                double newTop = currentTop + VelocityY;

                if(newLeft >= LeftOuterBound)
                {
                    VelocityX *= -1;
                    newLeft = currentLeft + VelocityX;
                }
                if(newTop >= TopOuterBound)
                {
                    VelocityY *= -1;
                    newTop = currentTop + VelocityY;
                }

                Left = newLeft;
                Top = newTop;

                WpfImage.Dispatcher.Invoke(new Action(() =>
                {
                    System.Windows.Controls.Canvas.SetLeft(WpfImage, Left);
                    System.Windows.Controls.Canvas.SetTop(WpfImage, Top);
                }));
            }
        }
    }
}
