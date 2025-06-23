using Microsoft.Maui.Graphics;

public class SimpleDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Red;
        canvas.FillRectangle(10, 10, 100, 50);
    }
}