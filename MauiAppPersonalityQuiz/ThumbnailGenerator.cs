using System;
using System.IO;
using SkiaSharp;

namespace MauiAppPersonalityQuiz
{
	public class ThumbnailGenerator
	{
		public static void GenerateThumbnail(string originalImagePath, string thumbnailImagePath)
		{
			Console.WriteLine($"Original Image Path (GenerateThumbnail): {originalImagePath}");
			Console.WriteLine($"Thumbnail Path (GenerateThumbnail): {thumbnailImagePath}");

			try
			{
				using (var originalStream = File.OpenRead(originalImagePath))
				using (var originalBitmap = SKBitmap.Decode(originalStream))
				using (var thumbnailBitmap = originalBitmap.Resize(new SKImageInfo(100, 100), SKFilterQuality.High))
				using (var thumbnailStream = File.Create(thumbnailImagePath))
				{
					thumbnailBitmap.Encode(SKEncodedImageFormat.Jpeg, 80).SaveTo(thumbnailStream);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error generating thumbnail: {ex.Message}");
				// Handle the exception as needed, for example, logging or notifying the user.
			}
		}
	}
}
