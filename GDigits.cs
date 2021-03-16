using System;
using System.Collections.Generic;
using System.Text;

class GDigits : Digits
{
    public GDigits(sbyte val, int bitmapwidth, int bitmapheight) : base(val, bitmapwidth, bitmapheight)
    {
        SetValue(val);
        CreateBitmap(bitmapwidth, bitmapheight);
    }


    private void SetValue(sbyte val)
    {
        SetBinaryValue('G');
    }
}
