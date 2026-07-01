using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing;

namespace MiAplicacion.Tags
{
    [HtmlTargetElement("codigoqr")]
    public class CodigoQRTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contenido = context.AllAttributes["contenido"]?.Value?.ToString() ?? string.Empty;
            var ancho = context.AllAttributes["ancho"]?.Value?.ToString() ?? "100";
            var alto = context.AllAttributes["alto"]?.Value?.ToString() ?? "100";
            var barcodeWriterPixelData = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = int.Parse(ancho),
                    Height = int.Parse(alto),
                    Margin = 0
                }
            };
            var pixelData = barcodeWriterPixelData.Write(contenido);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    output.TagName = "img";
                    output.Attributes.Clear();
                    output.Attributes.Add("width", ancho);
                    output.Attributes.Add("height", alto);
                    output.Attributes.Add("src", $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}");
                }
            }
        }
    }
}
