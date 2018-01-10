using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TextureImporterSettings : AssetPostprocessor {

	void OnPreprocessTexture()
    {
		TextureImporter textureImporter  = (TextureImporter)assetImporter;
		textureImporter.textureType = TextureImporterType.Sprite;
		textureImporter.spritePixelsPerUnit = 16;
		textureImporter.wrapMode = TextureWrapMode.Clamp;
		textureImporter.filterMode = FilterMode.Point;
		textureImporter.maxTextureSize = 8192;
		textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
    }

	void OnPostprocessTexture(Texture2D texture)
	{
		
	}
}
