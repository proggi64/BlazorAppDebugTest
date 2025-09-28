
using SkiaSharp;

namespace BlazorAppDebugTest.Client;

public class GdiGraphics : IDisposable
{
    private SKDocument _document;
    private SKCanvas _canvas;
    private SKPaint _paint;
    private SKFont _font;
    private int _pageWidth;
    private int _pageHeight;
    private MemoryStream _stream;
    private SKPath? _currentPath;

    public GdiGraphics(MemoryStream stream, int width = 595, int height = 842)
    {
        _stream = stream;
        _document = SKDocument.CreatePdf(_stream);
        _pageWidth = width;
        _pageHeight = height;
        _canvas = _document.BeginPage(width, height);
        _paint = new SKPaint { IsAntialias = true };
        _font = new SKFont(SKTypeface.Default, 16);
    }

    public void Close()
    {
        _document.Close();
    }

    public void SetPenColor(SKColor color) => _paint.Color = color;
    public void SetBrushColor(SKColor color) => _paint.Color = color;
    public void SetTextColor(SKColor color) => _paint.Color = color;

    public void SetFont(string familyName, float textSize)
    {
        var typeface = SKTypeface.FromFamilyName(familyName);
        _font = new SKFont(typeface, textSize);
    }

    public void DrawLine(float x1, float y1, float x2, float y2)
    {
        _paint.Style = SKPaintStyle.Stroke;
        _canvas.DrawLine(x1, y1, x2, y2, _paint);
    }

    public void DrawRectangle(float x, float y, float width, float height)
    {
        _canvas.DrawRect(x, y, width, height, _paint);
    }

    public void DrawEllipse(float x, float y, float width, float height)
    {
        _canvas.DrawOval(new SKRect(x, y, x + width, y + height), _paint);
    }

    public void DrawText(string text, float x, float y)
    {
        _canvas.DrawText(text, x, y, _font, _paint);
    }

    public void BeginPath() => _currentPath = new SKPath();
    public void AddLine(float x1, float y1, float x2, float y2)
    {
        if (_currentPath == null)
            throw new InvalidOperationException("BeginPath must be called before adding lines.");
        _currentPath.MoveTo(x1, y1);
        _currentPath.LineTo(x2, y2);
    }
    public void AddRectangle(float x, float y, float width, float height)
    {
        if (_currentPath == null)
            throw new InvalidOperationException("BeginPath must be called before adding lines.");
        _currentPath.AddRect(new SKRect(x, y, x + width, y + height));
    }
    public void FillPath()
    {
        _paint.Style = SKPaintStyle.Fill;
        _canvas.DrawPath(_currentPath, _paint);
    }
    public void StrokePath()
    {
        _paint.Style = SKPaintStyle.Stroke;
        _canvas.DrawPath(_currentPath, _paint);
    }

    public void Translate(float dx, float dy) => _canvas.Translate(dx, dy);
    public void Scale(float sx, float sy) => _canvas.Scale(sx, sy);
    public void Rotate(float degrees) => _canvas.RotateDegrees(degrees);
    public void Save() => _canvas.Save();
    public void Restore() => _canvas.Restore();

    public void SetClipRect(float x, float y, float width, float height)
    {
        var clipRect = new SKRect(x, y, x + width, y + height);
        _canvas.ClipRect(clipRect);
    }
    public void ResetClip()
    {
        _canvas.Restore();
        _canvas.Save();
    }

    public void EndPage()
    {
        _document.EndPage();
    }

    public byte[] GetPdfBytes() => _stream.ToArray();

    public void Dispose()
    {
        _document.Close();
        _document.Dispose();
        _paint.Dispose();
    }
}
