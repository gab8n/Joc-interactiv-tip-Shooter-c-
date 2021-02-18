
//#define MyDebug
using Shooter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter
{
    public partial class FireShooter : Form
    {
        const int FrameNum = 8;
        const int SplatNum = 3;
        bool splat = false;
        int _gameFrame = 0;
        int _splatTime = 0;
        int _hits = 0;
        int _misses = 0;
        int _totalShots = 0;
        double _averageHits = 0;
#if MyDebug
        int _cursX = 0;
        int _cursY = 0;
#endif
        CMojo _mojo;
        CSign _sign;
        CTV _TV;
        CBoom _boom;
        Random rnd = new Random();

        public FireShooter()
        {
            InitializeComponent();
            Bitmap b = new Bitmap(Resources.Site);
            this.Cursor = CSite.CreateCursor(b, b.Height / 2, b.Width / 2);

            _mojo = new CMojo() { Left = 10, Top = 200 };
            _sign = new CSign() { Left = 500, Top = -85 };
            _TV = new CTV() { Left = 0, Top = 5 };
            _boom = new CBoom();
        }

        private void timerGameLoop_Tick(object sender, EventArgs e)
        {
            if (_gameFrame >= FrameNum)
            {
                UpdateMojo();
                _gameFrame = 0;
            }
            if(splat)
            {
                if(_splatTime>=SplatNum)
                {
                    splat = false;
                    _splatTime = 0;
                    UpdateMojo();
                }
                _splatTime++;
            }
            _gameFrame++;

            this.Refresh();

        }

        private void UpdateMojo()
        {
            _mojo.Update(rnd.Next(Resources.Villan.Width, this.Width - Resources.Villan.Width),
                         rnd.Next(this.Height / 2, this.Height - Resources.Villan.Height * 2));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            if (splat==true)
            {
                _boom.DrawImage(dc);
            }
            else
            {
                _mojo.DrawImage(dc);
            }
            

            _sign.DrawImage(dc);
            _TV.DrawImage(dc);
#if MyDebug

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font,
                new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flags);
#endif
            TextFormatFlags flags = TextFormatFlags.Left;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, "Shots:" + _totalShots.ToString(), _font, new Rectangle(30, 32, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Hits:" + _hits.ToString(), _font, new Rectangle(30, 52, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Misses:" + _misses.ToString(), _font, new Rectangle(30, 72, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Avg:" + _averageHits.ToString("F0")+"%", _font, new Rectangle(30, 92, 120, 20), SystemColors.ControlText, flags);




            base.OnPaint(e);
        }

        private void FireShooter_MouseMove(object sender, MouseEventArgs e)
        {
#if MyDebug   
            _cursX = e.X;
            _cursY = e.Y;
#endif

            this.Refresh();
        }

        private void FireShooter_Load(object sender, EventArgs e)
        {

        }

        private void FireShooter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 584 && e.X < 615 && e.Y > 54 && e.Y < 71)
            {
                timerGameLoop.Start();
            }
            else
                 if (e.X > 589 && e.X < 636 && e.Y > 78 && e.Y < 92)
            {
                timerGameLoop.Stop();
            }
            else
                 if (e.X > 581 && e.X < 648 && e.Y > 98 && e.Y < 113)
            {
                _totalShots = 0;
                _hits = 0;
                _averageHits = 0;
                _misses = 0;
                
            }
            else
                 if (e.X > 590 && e.X < 638 && e.Y > 119 && e.Y < 133)
            {
                Application.Exit();
            }
            else
            {
                if (_mojo.Hit(e.X, e.Y))
                {
                    splat = true;
                    _boom.Left = _mojo.Left - Resources.Boom.Width / 3;
                    _boom.Top = _mojo.Top - Resources.Boom.Height / 3;

                    _hits++;
                }
                else
                {
                    _misses++;
                }
                _totalShots = _hits + _misses;
                _averageHits =(double) _hits /(double) _totalShots * 100;
            }


            FireGun();

        }
        private void FireGun()
        {
            SoundPlayer simpleSound = new SoundPlayer(Resources.Shotgun_Pump);
            simpleSound.Play();
        }
    }
    
}
