using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class LoadAndUseAssetBundle : MonoBehaviour
{
    public RawImage rawImage;
    AssetBundle bundle;
    IEnumerator LoadFromMemoryAsync(string path, string name)
    {
        if(bundle == null)
        {
            AssetBundleCreateRequest createRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
            yield return null;
            bundle = createRequest.assetBundle;
            rawImage.texture = bundle.LoadAsset<Texture2D>(name);
        }
        else
        {
            rawImage.texture = bundle.LoadAsset<Texture2D>(name);
        }
    }

    public void HandleOnClick(string name)
    {
        string tempPath = Application.persistentDataPath + "Level_1" + ".File";
        StartCoroutine(LoadFromMemoryAsync(tempPath, name));
    }
}

