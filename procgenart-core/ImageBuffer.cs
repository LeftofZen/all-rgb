using System.Drawing;
using System.Drawing.Imaging;

namespace procgenart_core
{
	public class ImageBuffer
	{
		public ImageBuffer(int width, int height)
		{
			buf = new Colour[height, width];
			isSet = new bool[height, width];
			Radius = MathsHelpers.DistanceEuclidean(new Point(0, 0), Middle);
		}

		public float Radius { get; init; }

		public ImageBuffer(Bitmap img) : this(img.Width, img.Height)
		{
			var rect = new Rectangle(0, 0, Width, Height);
			var imgData = img.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			for (var y = 0; y < Height; ++y)
			{
				for (var x = 0; x < Width; ++x)
				{
					SetPixel(x, y, imgData.GetPixel(x, y));
				}
			}

			img.UnlockBits(imgData);
		}

		private Colour[,] buf;
		private bool[,] isSet;

		public void Clear()
		{
			buf = new Colour[Height, Width];
			isSet = new bool[Height, Width];
		}

		public bool Contains(int X, int Y)
			=> X >= 0 && X < Width && Y >= 0 && Y < Height;

		public bool Contains(Point p)
			=> Contains(p.X, p.Y);

		public Colour GetPixel(Point p)
			=> GetPixel(p.X, p.Y);
		public Colour GetPixel(int X, int Y)
			=> buf[Y, X];

		public void SetPixel(Point p, Colour c)
			=> SetPixel(p.X, p.Y, c);

		public void SetPixel(int X, int Y, Colour c)
		{
			isSet[Y, X] = true;
			buf[Y, X] = c;
		}

		public bool IsEmpty(Point p)
			=> IsEmpty(p.X, p.Y);

		public bool IsEmpty(int X, int Y)
			//=> !isSet[Y, X];
			=> buf[Y, X].A == 0;

		public void FillRect(int X, int Y, int Width, int Height, Colour c)
		{
			for (var x = X; x < X + Width; ++x)
			{
				for (var y = Y; y < Y + Height; ++y)
				{
					SetPixel(x, y, c);
				}
			}
		}

		public int Width
			=> buf.GetLength(1);
		public int Height
			=> buf.GetLength(0);

		public int NumberOfPixels
			=> Width * Height;

		public Point Middle
			=> new(Width / 2, Height / 2);

		public Image GetImage()
		{
			if (Width == 0 || Height == 0)
			{
				throw new ArgumentOutOfRangeException("Width/Height", $"Image dimensions were invalid. Width={Width} Height={Height}");
			}

			var img = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
			var rect = new Rectangle(0, 0, Width, Height);
			var imgData = img.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			for (var y = 0; y < Height; ++y)
			{
				for (var x = 0; x < Width; ++x)
				{
					imgData.SetPixel(x, y, isSet[y, x] ? GetPixel(x, y) : Colour.FromSystemColor(Color.White));
				}
			}

			img.UnlockBits(imgData);
			return img;
		}

		public void Save()
			=> Save(GetImage());

		private void Save(Image i)
		{
			Console.WriteLine("Saving");
			//i.Save(@"C:\Users\Benjamin.Sutas\source\repos\all-rgb\all-rgb\content\img.png", ImageFormat.Png);
			var filename = @$"{BaseFileName}\img_{DateTime.Now.ToString().Replace(':', '-')}_{Width}x{Height}.png";
			filename = filename.Replace(' ', '_');
			i.Save(filename, ImageFormat.Png);
		}

		public const string BaseFileName = @"C:\Users\bigba\source\repos\all-rgb\all-rgb\content";
	}
}
