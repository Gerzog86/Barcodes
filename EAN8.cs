using System;
using System.Windows.Forms;
using System.Drawing;

public class EAN8
{

	private int[] barcode = new int[8];

	/// <summary>
	/// 
	/// </summary>
	/// <param name="short_barcode">Семизначное значение штрих-кода</param>
	public EAN8(string short_barcode)
	{
		barcode[0] = (int.Parse(short_barcode[0].ToString()) * 3);
		barcode[1] = (int.Parse(short_barcode[1].ToString()));
		barcode[2] = (int.Parse(short_barcode[2].ToString()) * 3);
		barcode[3] = (int.Parse(short_barcode[3].ToString()));
		barcode[4] = (int.Parse(short_barcode[4].ToString()) * 3);
		barcode[5] = (int.Parse(short_barcode[5].ToString()));
		barcode[6] = (int.Parse(short_barcode[6].ToString()) * 3);
		barcode[7] = 0;
		for (int i = 0; i < 7; i++)
        {
			barcode[7] += barcode[i];
        }
		barcode[7] = barcode[7]%10;
		barcode[7] = 10 - barcode[7];

		barcode[0] = (int.Parse(short_barcode[0].ToString()));
		barcode[1] = (int.Parse(short_barcode[1].ToString()));
		barcode[2] = (int.Parse(short_barcode[2].ToString()));
		barcode[3] = (int.Parse(short_barcode[3].ToString()));
		barcode[4] = (int.Parse(short_barcode[4].ToString()));
		barcode[5] = (int.Parse(short_barcode[5].ToString()));
		barcode[6] = (int.Parse(short_barcode[6].ToString()));
	}
	public EAN8(long full_barcode)
	{
		string short_barcode = full_barcode.ToString();
		barcode[0] = (int.Parse(short_barcode[0].ToString()));
		barcode[1] = (int.Parse(short_barcode[1].ToString()));
		barcode[2] = (int.Parse(short_barcode[2].ToString()));
		barcode[3] = (int.Parse(short_barcode[3].ToString()));
		barcode[4] = (int.Parse(short_barcode[4].ToString()));
		barcode[5] = (int.Parse(short_barcode[5].ToString()));
		barcode[6] = (int.Parse(short_barcode[6].ToString()));
		barcode[7] = (int.Parse(short_barcode[7].ToString()));
	}

	private Digits[] BarCode = new Digits[8];

	public Bitmap CreateBarcodeBitmap (int width, int height)
    {
		Bitmap toReturn = new Bitmap(width, height);
		Graphics gr = Graphics.FromImage(toReturn);
		int onedigitwidth = (width / 67) * 7;

		for (int i = 0; i <= 3; i++)
		{
			BarCode[i] = new LDigits((sbyte)barcode[i], width / 67 * 7, height);
		}
		for (int i = 4; i <= 7; i++)
		{
			BarCode[i] = new RDigits((sbyte)barcode[i], width / 67 * 7, height);
		}

		gr.FillRectangle(Brushes.Black, 0, 0, width / 67, height);
		gr.FillRectangle(Brushes.White, width / 67, 0, width / 67, height);
		gr.FillRectangle(Brushes.Black, (width / 67) * 2, 0, width / 67, height);

		for (int i = 0; i <= 3; i++)
		{
			gr.DrawImage(BarCode[i].GetBitmapValue(), (onedigitwidth * i + (width / 67) * 3), 0);
		}

		gr.FillRectangle(Brushes.White, (onedigitwidth * 4 + (width / 67) * 3), 0, width / 67, height);
		gr.FillRectangle(Brushes.Black, (onedigitwidth * 4 + (width / 67) * 4), 0, width / 67, height);
		gr.FillRectangle(Brushes.White, (onedigitwidth * 4 + (width / 67) * 5), 0, width / 67, height);
		gr.FillRectangle(Brushes.Black, (onedigitwidth * 4 + (width / 67) * 6), 0, width / 67, height);
		gr.FillRectangle(Brushes.White, (onedigitwidth * 4 + (width / 67) * 7), 0, width / 67, height);

		for (int i = 4; i <= 7; i++)
		{
			gr.DrawImage(BarCode[i].GetBitmapValue(), (onedigitwidth * i + (width / 67) * 8), 0);
		}

		gr.FillRectangle(Brushes.Black, (onedigitwidth * 8 + (width / 67) * 8), 0, width / 67, height);
		gr.FillRectangle(Brushes.White, (onedigitwidth * 8 + (width / 67) * 9), 0, width / 67, height);
		gr.FillRectangle(Brushes.Black, (onedigitwidth * 8 + (width / 67) * 10), 0, width / 67, height);


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
