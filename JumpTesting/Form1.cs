using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpTesting
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//		Rectangle Player = new Rectangle(64, 24, 16, 14);
		Player p = new Player(64, 24);
		Rectangle ground = new Rectangle(0, 200, 512, 16);
		Rectangle roof = new Rectangle(84, 120, 460, 16);

		public bool isGrounded = false;
		public bool isJumping = false;

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					p.x -= 4;
					//p.head.X -= 4;
					//p.feet.X -= 4;
					//p.visual.X -= 4;
					p.Movement();
					break;

				case Keys.D:
					p.x += 4;
					//p.head.X += 4;
					//p.feet.X += 4;
					//p.visual.X += 4;
					p.Movement();
					break;

				case Keys.Space:
					isJumping = true;
					p.y -= 4;
					p.Movement();
					break;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space:
					isJumping = false;
					break;
			}
		}

		private void gameTimer_Tick(object sender, EventArgs e)
		{
			if (ground.IntersectsWith(p.feet))
			{
				isGrounded = true;
			}

			else if (ground.IntersectsWith(p.head))
			{
				p.y += 4;
				isJumping = false;
			}

			else
			{
				isGrounded = false;
			}

			if (!isGrounded && !isJumping)
			{
				p.y += 4;
				//p.visual.Y += 4;
				//p.head.Y += 4;
				//p.feet.Y += 4;
				p.Movement();
			}

			debugInfo.Text = "PLAYER X: " + p.x + "\nPLAYER Y: " + p.y;

			Refresh();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Pen drawBoxes = new Pen(Color.Red);
			e.Graphics.DrawRectangle(drawBoxes, p.visual);
			e.Graphics.DrawRectangle(drawBoxes, ground);
			e.Graphics.DrawRectangle(drawBoxes, roof);
		}
	}
}
