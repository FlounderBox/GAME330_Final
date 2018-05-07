using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IconPreProcess : AssetPostprocessor {

    void OnPreprocessTexture()
    {
        var _texture = (TextureImporter)assetImporter;
        if (_texture != null)
        {
            if (assetPath.Contains("Icons"))
            {
                _texture.textureType = TextureImporterType.Sprite;
            }
        }
    }
}
