using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ImageResizer
    {
        [MenuItem("Assets/Resize Image")]
        private static void ResizeSelectedImages()
        {
            var newWidth = 512; // Desired width
            var newHeight = 1024; // Desired height

            foreach (var obj in Selection.objects)
            {
                if (obj is Texture2D texture)
                {
                    var path = AssetDatabase.GetAssetPath(texture);
                    var importer = AssetImporter.GetAtPath(path) as TextureImporter;

                    if (importer != null)
                    {
                        importer.isReadable = true;
                        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

                        var resizedTexture = ResizeTexture(texture, newWidth, newHeight);
                        System.IO.File.WriteAllBytes(path, resizedTexture.EncodeToPNG());

                        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                    }
                }
            }

            AssetDatabase.Refresh();
        }

        private static Texture2D ResizeTexture(Texture2D source, int newWidth, int newHeight)
        {
            var result = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
            var rpixels = result.GetPixels(0);

            // Fill the entire new texture with a transparent color
            for (int i = 0; i < rpixels.Length; i++)
            {
                rpixels[i] = new Color(0, 0, 0, 0); // Transparent color
            }

            var offsetX = (newWidth - source.width) / 2;
            var offsetY = (newHeight - source.height) / 2;

            for (var y = 0; y < source.height; y++)
            {
                for (var x = 0; x < source.width; x++)
                {
                    var color = source.GetPixel(x, y);
                    rpixels[(y + offsetY) * newWidth + (x + offsetX)] = color;
                }
            }

            result.SetPixels(rpixels, 0);
            result.Apply();

            return result;
        }
    }
}