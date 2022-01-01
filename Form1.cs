using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using Rectangle = System.Drawing.Rectangle;

namespace SpaceLander
{
	public partial class Form1 : Form
	{
		private Timer gameTimer;
		private bool isMove;
		private SpaceShip ship;
		private int maximalSpeed;
		private LevelCreator level;
		private BufferedGraphics grafx;
		private Fire fire;
		private int minimalDegree;
		public Form1()
		{
			InitializeComponent();
			
			gameTimer = new Timer();
			gameTimer.Tick += GameTimer_Tick;
			isMove = false;
			maximalSpeed = 2;
			gameTimer.Interval = 10;
			ship = new SpaceShip
			{
				ShipImage = imageList1.Images[0],
				Degree = 0,
				Speed = maximalSpeed / 2,
				Resistant = maximalSpeed - 1,
				Height = 16,
				Width = 16,
				DrawingBrush = new Pen(Brushes.White),
				Location = new Point(100, 0)
			};
			level = new LevelCreator
			{
				GroundTexture = Textures.Images[0],
				LandingZoneSize = 50,
				ScreenHeight = ClientSize.Height,
				LandingPen = new Pen(Brushes.Green, 15),
				GroundPen = new Pen(Brushes.LightGoldenrodYellow, 5),
				MaximalHeight = 400,
				MaximalWidth = this.Width
			};
			fire = new Fire
			{
				Degree = 0,
				FireImage = Fires.Images[0],
				Location = ship.Location
			};
			minimalDegree = 25;
			level.SetMaximalCountOfPoints(15);
			level.GenaratePoints();
			gameTimer.Start();
			
			BufferedGraphicsContext context = BufferedGraphicsManager.Current;
			
			context.MaximumBuffer = new Size(Width + 1, Height + 1);
			
			grafx = context.Allocate(this.CreateGraphics(),
				 new Rectangle(0, 0, this.Width, this.Height));
			
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw , true);
			Draw();
			this.Invalidate();
		}

		private void SetCoordsByCoolisionCheck()
		{
			float x = ship.Location.X;
			float y = ship.Location.Y;

			if (ship.Location.Y * GameMath.Cos(ship.Degree)
				> ship.Speed && isMove)
			{
				y = (float)(ship.Location.Y - ship.Speed
					* GameMath.Cos(ship.Degree));

				x = (float)(ship.Location.X + ship.Speed
					* GameMath.Sin(ship.Degree));

				if (x + ship.Height > this.Width - ship.Speed ||
								x - ship.Height < -ship.Height)
				{
					x = ship.Location.X;
				}
			}
			else if (ship.Location.Y + ship.Height < this.ClientSize.Height)
			{
				x = (float)(ship.Location.X + (maximalSpeed - ship.Resistant)
					* GameMath.Sin(ship.Degree));

				y = (float)(ship.Location.Y + maximalSpeed - ship.Resistant);

				if (x + ship.Height > this.Width - maximalSpeed - ship.Resistant ||
												x - ship.Height < -ship.Height)
				{
					x = ship.Location.X;
				}
			}
			ship.Location = new PointF(x, y);
		}
		private void GameTimer_Tick(object sender, EventArgs e)
		{
			PointF point;
			point = new PointF
			{
				X = (float)(ship.Location.X + ship.Width),
				Y = (float)(ship.Location.Y + ship.Height)
			};
			if (!GroundCoolision.CheckCoordInPoints(point, level.Points))
			{
				SetCoordsByCoolisionCheck();
			}
			else if (point.X > level.Points[level.LandingIndex].X &&
				point.X < level.Points[level.LandingIndex + 1].X)
			{
				gameTimer.Stop();
				this.Text = ship.Degree.ToString();
				if (ship.Degree < 25 && ship.Degree > -25)
					new WinGame(this).ShowDialog();
				else
					new LoseGame(this).ShowDialog();
				this.Close();

			}
			else
			{
				gameTimer.Stop();
				new LoseGame(this).ShowDialog();
				this.Close();
			}
			//this.Invalidate();
			this.Refresh();
			Draw();
		}

		private void UpdateBuffer()
        {
			grafx.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);
		}
		private void Draw()
        {
			
			grafx.Graphics.DrawImage(this.BackgroundImage, 0, 0);
			grafx.Graphics.DrawImage(Flags.Images[0],
				level.Points[level.LandingIndex].X - Flags.Images[0].Width,
				level.Points[level.LandingIndex].Y - Flags.Images[0].Height);

			grafx.Graphics.DrawImage(Flags.Images[0],
				level.Points[level.LandingIndex + 1].X - Flags.Images[0].Width,
				level.Points[level.LandingIndex + 1].Y - Flags.Images[0].Height);
			level.DrawPoints(grafx.Graphics);
			
			Matrix matrix = new Matrix();
			matrix.RotateAt(ship.Degree, new PointF { 
				X = ship.Location.X + ship.Width / 2,
				Y = ship.Location.Y + ship.Height / 2 });
			
			grafx.Graphics.Transform = matrix;

			if (isMove)
			{
				if (ship.Speed != maximalSpeed)
					fire.FireImage = Fires.Images[0];
				else
					fire.FireImage = TurboFire.Images[0];
				fire.Degree = ship.Degree;
				fire.Location = new PointF(
					(float)(ship.Location.X - fire.FireImage.Width /2),
					 (float)(ship.Location.Y + ship.Height));
				fire.DrawObject(grafx.Graphics);
			}
			ship.DrawObject(grafx.Graphics);
			matrix.Reset();
			grafx.Graphics.Transform = matrix;
			grafx.Render(this.CreateGraphics());

		}
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			
			if (e.KeyCode == Keys.Space || e.KeyCode == Keys.X)
			{
				isMove = true;
				if (e.KeyCode == Keys.X)
					ship.Speed = maximalSpeed;
			}
			if(e.KeyCode == Keys.D)
			{
				if (ship.Degree == 360)
					ship.Degree = 0;
				ship.Degree += 5;
			}
			else if (e.KeyCode == Keys.A)
			{
				if (ship.Degree == -360)
					ship.Degree = 0;
				ship.Degree -= 5;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			Line line = new Line();

			if (e.KeyCode == Keys.Space || e.KeyCode == Keys.X)
			{
				isMove = false;
				if (e.KeyCode == Keys.X)
				{
					ship.Speed = maximalSpeed / 2;
				}
				UpdateBuffer();
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			grafx.Render(e.Graphics);
		}
	

    }
}
