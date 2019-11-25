namespace ToyGraf.Controls
{
    using FastColoredTextBoxNS;
    using System;
    using System.Drawing;

    public class ReadOnlyTextStyle : ReadOnlyStyle
    {
        public Brush ForeBrush { get; set; }
        public Brush BackgroundBrush { get; set; }
        public FontStyle FontStyle { get; set; }
        public StringFormat StringFormat { get; set; }

        public ReadOnlyTextStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle)
        {
            ForeBrush = foreBrush;
            BackgroundBrush = backgroundBrush;
            FontStyle = fontStyle;
            StringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            if (BackgroundBrush != null)
                gr.FillRectangle(BackgroundBrush, position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
            using (var f = new Font(range.tb.Font, FontStyle))
            {
                Line line = range.tb[range.Start.iLine];
                float
                    dx = range.tb.CharWidth,
                    y = position.Y + range.tb.LineInterval / 2,
                    x = position.X - range.tb.CharWidth / 3;
                if (ForeBrush == null)
                    ForeBrush = new SolidBrush(range.tb.ForeColor);
                if (range.tb.ImeAllowed)
                    for (var i = range.Start.iChar; i < range.End.iChar; i++, x += dx)
                    {
                        SizeF size = FastColoredTextBox.GetCharSize(f, line[i].c);
                        var gs = gr.Save();
                        float k = size.Width > range.tb.CharWidth + 1 ? range.tb.CharWidth / size.Width : 1;
                        gr.TranslateTransform(x, y + (1 - k) * range.tb.CharHeight / 2);
                        gr.ScaleTransform(k, (float)Math.Sqrt(k));
                        gr.DrawString(line[i].c.ToString(), f, ForeBrush, 0, 0, StringFormat);
                        gr.Restore(gs);
                    }
                else
                    for (var i = range.Start.iChar; i < range.End.iChar; i++, x += dx)
                        gr.DrawString(line[i].c.ToString(), f, ForeBrush, x, y, StringFormat);
            }
        }
    }
}
