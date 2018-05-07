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
        Vector2 _pos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * (_rectTransform.offsetMax.magnitude + 20f);
        return _pos;
    }
}

public class WatchItem: MonoBehaviour
{
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Destroy(gameObject);
        }
        rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));

    }
    private void Update()
    {
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, Vector2.zero, Time.deltaTime * 0.25f);
    }
}
