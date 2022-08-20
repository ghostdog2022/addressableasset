using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    [SerializeField] private Image _image;
    private AsyncOperationHandle _handle;

    public void OnClick_Load ()
    {
        Addressables.LoadAssetAsync<Sprite>("earth").Completed +=
            (AsyncOperationHandle<Sprite> handle) =>
            {
                _handle = handle;
                _image.sprite = handle.Result;
            };
    }

    public void OnClick_Unload ()
    {
        Addressables.Release(_handle);
        _image.sprite = null;
    }
}
