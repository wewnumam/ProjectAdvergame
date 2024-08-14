using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetSpawner : MonoBehaviour
{
    [SerializeField] AssetReference assetReference;
    [ReadOnly] public float progress;
    AsyncOperationHandle operationHandle;

    void Start()
    {
        operationHandle = Addressables.DownloadDependenciesAsync(assetReference);
        operationHandle.Completed += OnLoadDone;
    }

    private void Update()
    {
        progress = operationHandle.PercentComplete;
    }

    private void OnLoadDone(AsyncOperationHandle obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            assetReference.InstantiateAsync();
        }
    }
}
