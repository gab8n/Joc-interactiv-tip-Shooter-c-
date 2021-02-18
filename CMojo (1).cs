using Shooter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    class CMojo : CImageBase
    {
        private Rectangle _mojoHotSpot = new Rectangle();

        public CMojo()
            :base(Resources.Villan)
        {
            _mojoHotSpot.X = Left + 20;
            _mojoHotSpot.Y = Top - 1;
            _mojoHotSpot.Width = 30;
            _mojoHotSpot.Height = 40;

        }
        

        public void Update(int X,int Y)
        {
            Left = X;
            Top = Y;
            _mojoHotSpot.X = Left + 20;
            _mojoHotSpot.Y = Top - 1;

        }
        public bool Hit(int X,int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1);
            if (_mojoHotSpot.Contains(c))
            {
                return true;

            }
            return false;
        }

        internal void Update(object p1, object p2)
        {
            throw new NotImplementedException();
        }
    }
}
