using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpTesting
{
	class Player
	{
		public int x, y;

		public Rectangle feet = new Rectangle(0, 0 + 24, 16, 4),
						 head = new Rectangle(0, 0, 16, 4),
						 visual = new Rectangle(0, 0, 16, 24);

		public Player(int _x, int _y)
		{
			x = _x;
			y = _y;
		}

		public void Movement()
		{
			head.X = x;
			head.Y = y;
			feet.X = x;
			feet.Y = y + 24;
			visual.X = x;
			visual.Y = y;
		}
	}
}
