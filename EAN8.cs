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

	public Bitmap CreateBarcodeBitmap(int width, int height)
    {
		width = width - (width % 67);
		int onedigitwidth = (width / 67) * 7;
		Bitmap toReturn = new Bitmap(width, height);
		Bitmap[] barcodeView = new Bitmap[8];
		Graphics grBarcodeView = Graphics.FromImage(toReturn);

		barcodeView[0] = new Bitmap(onedigitwidth, height);
		barcodeView[1] = new Bitmap(onedigitwidth, height);
		barcodeView[2] = new Bitmap(onedigitwidth, height);
		barcodeView[3] = new Bitmap(onedigitwidth, height);
		barcodeView[4] = new Bitmap(onedigitwidth, height);
		barcodeView[5] = new Bitmap(onedigitwidth, height);
		barcodeView[6] = new Bitmap(onedigitwidth, height);
		barcodeView[7] = new Bitmap(onedigitwidth, height);

		barcodeView[0] = returnLeftBarDigit(barcode[0], barcodeView[0].Width, barcodeView[0].Height);
		barcodeView[1] = returnLeftBarDigit(barcode[1], barcodeView[1].Width, barcodeView[1].Height);
		barcodeView[2] = returnLeftBarDigit(barcode[2], barcodeView[2].Width, barcodeView[2].Height);
		barcodeView[3] = returnLeftBarDigit(barcode[3], barcodeView[3].Width, barcodeView[3].Height);
		barcodeView[4] = returnRightBarDigit(barcode[4], barcodeView[4].Width, barcodeView[4].Height);
		barcodeView[5] = returnRightBarDigit(barcode[5], barcodeView[5].Width, barcodeView[5].Height);
		barcodeView[6] = returnRightBarDigit(barcode[6], barcodeView[6].Width, barcodeView[6].Height);
		barcodeView[7] = returnRightBarDigit(barcode[7], barcodeView[7].Width, barcodeView[7].Height);


		//Заполнение начального сектора
		grBarcodeView.FillRectangle(Brushes.Black, 0, 0, width/67, height);
		grBarcodeView.FillRectangle(Brushes.White, width / 67, 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.Black, (width / 67) * 2, 0, width / 67, height);

		//Заполнение левой части штрих-кода
		grBarcodeView.DrawImage(barcodeView[0], (width / 67) * 3, 0);
		grBarcodeView.DrawImage(barcodeView[1], (onedigitwidth + (width / 67) * 3), 0);
		grBarcodeView.DrawImage(barcodeView[2], (onedigitwidth * 2 + (width / 67) * 3), 0);
		grBarcodeView.DrawImage(barcodeView[3], (onedigitwidth * 3 + (width / 67) * 3), 0);

		//Заполнение разделителя
		grBarcodeView.FillRectangle(Brushes.White, (onedigitwidth * 4 + (width / 67) * 3), 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.Black, (onedigitwidth * 4 + (width / 67) * 4), 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.White, (onedigitwidth * 4 + (width / 67) * 5), 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.Black, (onedigitwidth * 4 + (width / 67) * 6), 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.White, (onedigitwidth * 4 + (width / 67) * 7), 0, width / 67, height);

		//Заполнение правой части штрих-кода
		grBarcodeView.DrawImage(barcodeView[4], (onedigitwidth * 4 + (width / 67) * 8), 0);
		grBarcodeView.DrawImage(barcodeView[5], (onedigitwidth * 5 + (width / 67) * 8), 0);
		grBarcodeView.DrawImage(barcodeView[6], (onedigitwidth * 6 + (width / 67) * 8), 0);
		grBarcodeView.DrawImage(barcodeView[7], (onedigitwidth * 7 + (width / 67) * 8), 0);

		//Заполнение конечного сектора
		grBarcodeView.FillRectangle(Brushes.Black, (onedigitwidth * 8 + (width / 67) * 8), 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.White, (onedigitwidth * 8 + (width / 67) * 9), 0, width / 67, height);
		grBarcodeView.FillRectangle(Brushes.Black, (onedigitwidth * 8 + (width / 67) * 10), 0, width / 67, height);

		return toReturn;
    }

	private Bitmap returnLeftBarDigit(int digit, int width, int height)
    {
		Bitmap toReturn = new Bitmap(width, height);
		Graphics tr = Graphics.FromImage(toReturn);
		switch (digit)
        {
            case 0:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 3 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 5 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 1:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 2 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 4 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 2:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 2 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 3 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
			case 3:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 1 + 1), 0, (width / 7) * 4, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 5 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 4:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 1 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 2 + 1), 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
			case 5:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 1 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 3 + 1), 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 6:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 1 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 2 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 3 + 1), 0, (width / 7) * 4, height);
					break;
				}
			case 7:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 1 + 1), 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 4 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
			case 8:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 1 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 3 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 4 + 1), 0, (width / 7) * 3, height);
					break;
				}
			case 9:
				{
					//ready
					tr.FillRectangle(Brushes.Transparent, 0, 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 3 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 4 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
		}
		return toReturn;
    }

	private Bitmap returnRightBarDigit(int digit, int width, int height)
	{
		Bitmap toReturn = new Bitmap(width, height);
		Graphics tr = Graphics.FromImage(toReturn);
		switch (digit)
		{
			case 0:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 3 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 5 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 1:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 2 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 4 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 2:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 2 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 3 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
			case 3:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 1 + 1), 0, (width / 7) * 4, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 5 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 4:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 1 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 2 + 1), 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
			case 5:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 1 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 3 + 1), 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 6 + 1), 0, (width / 7) * 1, height);
					break;
				}
			case 6:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 1 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 2 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 3 + 1), 0, (width / 7) * 4, height);
					break;
				}
			case 7:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 1 + 1), 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 4 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
			case 8:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 1 + 1), 0, (width / 7) * 2, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 3 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 4 + 1), 0, (width / 7) * 3, height);
					break;
				}
			case 9:
				{
					//ready
					tr.FillRectangle(Brushes.Black, 0, 0, (width / 7) * 3, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 3 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Black, ((width / 7) * 4 + 1), 0, (width / 7) * 1, height);
					tr.FillRectangle(Brushes.Transparent, ((width / 7) * 5 + 1), 0, (width / 7) * 2, height);
					break;
				}
		}
		return toReturn;
	}
}
