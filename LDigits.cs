using System;
using System.Collections.Generic;
using System.Text;

class LDigits : Digits
{
    public LDigits(sbyte val, int bitmapwidth, int bitmapheight) : base(val, bitmapwidth, bitmapheight)
    {
        SetValue(val);
        CreateBitmap(bitmapwidth, bitmapheight);
    }


    private void SetValue(sbyte val)
    {
        SetBinaryValue('L');
    }
}