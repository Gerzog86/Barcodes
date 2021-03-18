using System;
using System.Windows.Forms;
using System.Drawing;

public class EAN13
{
	private int[] barcode = new int[13];

	public EAN13(long full_barcode)
	{
		for (int i = 0; i <= full_barcode.ToString().Length - 1; i++)
        {
			barcode[i] = (int.Parse(full_barcode.ToString()[i].ToString()));
		}
	}

	private Digits[] BarCode = new Digits[13];

	public Bitmap CreateBarcodeBitmap(int width, int height)
	{
		Bitmap toReturn = new Bitmap(width, height);
		Graphics gr = Graphics.FromImage(toReturn);
		int onedigitwidth = (width / 95) * 7;

		switch (barcode[0])
        {
			case 0:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new LDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new LDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new LDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new LDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new LDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 1:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new LDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new GDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new LDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new GDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new GDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 2:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new LDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new GDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new GDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new LDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new GDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 3:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new LDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new GDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new GDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new GDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new LDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 4:
				{
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new GDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new LDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new LDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new GDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new GDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 5:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new GDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new GDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new LDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new LDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new GDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 6:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new GDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new GDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new GDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new LDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new LDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 7:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new GDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new LDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new GDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new LDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new GDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 8:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new GDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new LDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new GDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new GDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new LDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
			case 9:
                {
					BarCode[1] = new LDigits((sbyte)barcode[1], onedigitwidth, height);
					BarCode[2] = new GDigits((sbyte)barcode[2], onedigitwidth, height);
					BarCode[3] = new GDigits((sbyte)barcode[3], onedigitwidth, height);
					BarCode[4] = new LDigits((sbyte)barcode[4], onedigitwidth, height);
					BarCode[5] = new GDigits((sbyte)barcode[5], onedigitwidth, height);
					BarCode[6] = new LDigits((sbyte)barcode[6], onedigitwidth, height);
					break;
				}
		}
		for (int i = 7; i <= 12; i++)
		{
			BarCode[i] = new RDigits((sbyte)barcode[i], onedigitwidth, height);
		}

		gr.FillRectangle(Brushes.Black, 0, 0, width / 95, height);
		gr.FillRectangle(Brushes.Transparent, width / 95, 0, width / 95, height);
		gr.FillRectangle(Brushes.Black, (width / 95) * 2, 0, width / 95, height);

		for (int i = 1; i <= 6; i++)
		{
			gr.DrawImage(BarCode[i].GetBitmapValue(), (onedigitwidth * (i - 1) + (width / 95) * 3), 0);
		}

		gr.FillRectangle(Brushes.Transparent, (onedigitwidth * 6 + (width / 95) * 3), 0, width / 95, height);
		gr.FillRectangle(Brushes.Black, (onedigitwidth * 6 + (width / 95) * 4), 0, width / 95, height);
		gr.FillRectangle(Brushes.Transparent, (onedigitwidth * 6 + (width / 95) * 5), 0, width / 95, height);
		gr.FillRectangle(Brushes.Black, (onedigitwidth * 6 + (width / 95) * 6), 0, width / 95, height);
		gr.FillRectangle(Brushes.Transparent, (onedigitwidth * 6 + (width / 95) * 7), 0, width / 95, height);

		for (int i = 7; i <= 12; i++)
		{
			gr.DrawImage(BarCode[i].GetBitmapValue(), (onedigitwidth * (i - 1) + (width / 95) * 8), 0);
		}

		gr.FillRectangle(Brushes.Black, (onedigitwidth * 12 + (width / 95) * 8), 0, width / 95, height);
		gr.FillRectangle(Brushes.Transparent, (onedigitwidth * 12 + (width / 95) * 9), 0, width / 95, height);
		gr.FillRectangle(Brushes.Black, (onedigitwidth * 12 + (width / 95) * 10), 0, width / 95, height);


		return toReturn;
	}

	public string returnBarcode()
	{
		string toReturn = "";
		foreach (int i in barcode)
		{
			toReturn += i.ToString();
		}
		return toReturn;
	}
}
