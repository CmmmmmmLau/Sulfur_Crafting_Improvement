using System;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingImprove.Components;

public class ImageOutlineController : MonoBehaviour{
    private GameObject container;
    private Image originalImage;
    private Image outlineImage;
    
    private void Start() {
        container = this.transform.parent.gameObject;
        originalImage = container.transform.Find("ItemImage").GetComponent<Image>();
        outlineImage = this.gameObject.AddComponent<Image>();
        
        transform.SetAsFirstSibling();
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
        
        outlineImage.sprite = originalImage.sprite;
        outlineImage.SetNativeSize();
        outlineImage.preserveAspect = true;
        
        var source = originalImage.gameObject.GetComponent<RectTransform>();
        var target = outlineImage.GetComponent<RectTransform>();
        target.anchorMin = source.anchorMin;
        target.anchorMax = source.anchorMax;
        target.offsetMax = source.offsetMax;
        target.offsetMin = source.offsetMin;
        target.pivot = source.pivot;
        target.sizeDelta = source.sizeDelta;
    }
}