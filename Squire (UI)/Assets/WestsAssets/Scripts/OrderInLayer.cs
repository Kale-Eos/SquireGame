using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public sealed class OrderInLayer : MonoBehaviour
{

    [SerializeField]
    private string sortingLayerName = "Default";

    [SerializeField]
    private int sortingOrder = 0;

    public void OnValidate()
    {
        Apply();
    }

    public void OnEnable()
    {
        Apply();
    }

    private void Apply()
    {
        var meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = sortingLayerName;
        meshRenderer.sortingOrder = sortingOrder;
    }
}
