﻿using ZXing.QrCode;
using ZXing;
using System.Drawing;
using ZXing.Windows.Compatibility;
using QRCoder;

namespace QRCodeGeneratorWebAP.Data
{
    public class QRCodeAppService
    {
        public QRCodeAppService() 
        {
        }

        public byte[] GetQRCodeStream() 
        {
            QrCodeEncodingOptions options = new()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 500,
                Height = 500
            };
            BarcodeWriter writer = new()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            Bitmap qrCodeBitmap = writer.Write(url);

            var stream = new MemoryStream();
            qrCodeBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            var array = stream.ToArray();

            var b64String = Convert.ToBase64String(array);
            string imageURL = "data:image/png;base64," + b64String;

            return array;
        }

        public async Task<string> GetQRCodeImgString(string input) 
        {
            QrCodeEncodingOptions options = new()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 256,
                Height = 256
            };
            BarcodeWriter writer = new()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            string url = input;
            Bitmap qrCodeBitmap = writer.Write(url);

            var stream = new MemoryStream();
            qrCodeBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            var array = stream.ToArray();

            var b64String = Convert.ToBase64String(array);
            string imageURL = "data:image/png;base64," + b64String;

            return imageURL;
        }

        public string GetQRCodeImgString2(string input)
        {
            //https://blog.miniasp.com/post/2023/08/30/How-to-use-QRCoder-generates-QR-Code-using-dotNet
            var array = PngByteQRCodeHelper.GetQRCode(input, QRCodeGenerator.ECCLevel.Q, 5);
            var b64String = Convert.ToBase64String(array);
            string imageURL = "data:image/png;base64," + b64String;

            return imageURL;
        }
    }
}
