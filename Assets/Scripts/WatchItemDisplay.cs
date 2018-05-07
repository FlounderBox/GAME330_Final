using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchItemDisplay : MonoBehaviour {

    public float MovementMod = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            GenerateItemImage();
        }
    }

    GameObject GenerateItemImage()
    {
        GameObject _itemImage = new GameObject("ItemImage");
        _itemImage.transform.SetParent(transform, false);
        _itemImage.transform.localScale = Vector2.one * 0.25f;
        _itemImage.transform.SetSiblingIndex(1);
        _itemImage.AddComponent<Image>();
        _itemImage.AddComponent<WatchItem>();
        Decay.AddDecay(_itemImage, 6f);
        _itemImage.GetComponent<RectTransform>().anchoredPosition = RandomPositionOutsideCanvas();
        return _itemImage;
    }

    public void GenerateItemImage(Sprite pSprite)
    {
        GameObject _itemImage = GenerateItemImage();
        _itemImage.GetComponent<Image>().sprite = pSprite;
    }

    Vector2 RandomPositionOutsideCanvas()
    {
        RectTransform _rectTransform = GetComponent<RectTransform>();
        Vector2 _pos = Vector3.Normalize(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f))) * (_rectTransform.offsetMax.magnitude + 20f);
        return _pos;
    }
}

public class WatchItem: MonoBehaviour
{
    RectTransform rectTransform;
    Image image;
    Decay decay;

    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        decay = GetComponent<Decay>();
        if (rectTransform == null)
        {
            Destroy(gameObject);
        }
        rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));

    }
    private void Update()
    {
        image.color = new Color(1, 1, 1, Mathf.Lerp(decay.Timer, 0f, decay.StartTime/decay.Timer * (decay.Timer - decay.StartTime) + decay.StartTime));
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, Vector2.zero, Time.deltaTime * 0.25f);
    }
}
