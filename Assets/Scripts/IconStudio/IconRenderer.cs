using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IconRenderer : MonoBehaviour
{

    public RenderTexture IconRenderTexture;

    [ExecuteInEditMode]
    public void TakeScreenshotsOfChildren()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == transform)continue;
            if (children[i].parent != transform) continue;
            children[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == transform) continue;
            if (children[i].parent != transform) continue;

            children[i].gameObject.SetActive(true);
            TakeScreenshot(children[i].name);
            children[i].gameObject.SetActive(false);
        }
    }

    void TakeScreenshot(string pFilename)
    {
        Texture2D _screenshot = new Texture2D(IconRenderTexture.width, IconRenderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = IconRenderTexture;
        Camera.main.targetTexture = IconRenderTexture;
        Camera.main.Render();
        _screenshot.ReadPixels(new Rect(0, 0, _screenshot.width, _screenshot.height), 0, 0);
        _screenshot.Apply();
        Camera.main.targetTexture = null;
        RenderTexture.active = null;

        byte[] fileData = null;

        fileData = _screenshot.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/./Models/Materials/Icons/icon_" + pFilename + ".png", fileData);
        Debug.Log("Wrote " + pFilename + ".png");
    }
}
