using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

    class Digits
    {

		private sbyte _value;
		private string _binaryvalue;
		private int _bitmapwidth, _bitmapheight;
		private Bitmap _bitmapvalue;
		protected Digits(sbyte val, int bitmapwidth, int bitmapheight)
		{
			_value = val;
			_bitmapwidth = bitmapwidth;
			_bitmapheight = bitmapheight;
		}

		protected static Dictionary<sbyte, string> LBinaryDigit = new Dictionary<sbyte, string>
		{
			{ 0, "0001101" },
			{ 1, "0011001" },
			{ 2, "0010011" },
			{ 3, "0111101" },
			{ 4, "0100011" },
			{ 5, "0110001" },
			{ 6, "0101111" },
			{ 7, "0111011" },
			{ 8, "0110111" },
			{ 9, "0001011" }
		};
		protected static Dictionary<sbyte, string> RBinaryDigit = new Dictionary<sbyte, string>
		{
			{ 0, "1110010" },
			{ 1, "1100110" },
			{ 2, "1101100" },
			{ 3, "1000010" },
			{ 4, "1011100" },
			{ 5, "1001110" },
			{ 6, "1010000" },
			{ 7, "1000100" },
			{ 8, "1001000" },
			{ 9, "1110100" }
		};
		protected static Dictionary<sbyte, string> GBinaryDigit = new Dictionary<sbyte, string>
		{
			{ 0, "0100111" },
			{ 1, "0110011" },
			{ 2, "0011011" },
			{ 3, "0100001" },
			{ 4, "0011101" },
			{ 5, "0111001" },
			{ 6, "0000101" },
			{ 7, "0010001" },
			{ 8, "0001001" },
			{ 9, "0010111" }
		};


		public sbyte GetValue()
		{
			return _value;
		}
		public string GetBinaryValue()
		{
			return _binaryvalue;
		}
		protected void SetBinaryValue(char digitType)
        {
			if (digitType.Equals('L'))
            {
				LBinaryDigit.TryGetValue(_value, out _binaryvalue);
            }
			if (digitType.Equals('R'))
            {
				RBinaryDigit.TryGetValue(_value, out _binaryvalue);
            }
			if (digitType.Equals('G'))
            {
				GBinaryDigit.TryGetValue(_value, out _binaryvalue);
            }
        }

        public int GetBitmapWidth()
		{
			return _bitmapwidth;
		}
		public void SetBitmapWidth(int bitmapwidth)
        {
			_bitmapwidth = bitmapwidth;
			CreateBitmap(_bitmapwidth, _bitmapheight);
        }
		public void SetBitmapHeight(int bitmapheight)
		{
			_bitmapheight = bitmapheight;
			CreateBitmap(_bitmapwidth, _bitmapheight);
		}
		public Bitmap GetBitmapValue()
		{
			return _bitmapvalue;
		}

		protected void CreateBitmap (int width, int height)
        {
			_bitmapvalue = new Bitmap(width, height);
			Graphics gr = Graphics.FromImage(_bitmapvalue);
			for (int i = 0; i <= _binaryvalue.Length - 1; i++)
            {
				if (_binaryvalue[i].ToString().Equals("1"))
                {
					gr.FillRectangle(Brushes.Black, (width / 7) * i, 0, width / 7, height);
                }
				else
                {
					gr.FillRectangle(Brushes.Transparent, (width / 7) * i, 0, width / 7, height);
				}
            }
        }
	}