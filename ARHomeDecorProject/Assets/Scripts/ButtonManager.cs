using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField] private RawImage buttonImage;

    public GameObject furniture;

    private int _itemId;
    public Sprite _buttonTexture;
    public Sprite ButtonTexture 
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    public int ItemID
    { 
        set { _itemId = value; }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            //transform.localScale = Vector3.one * 2;
            transform.DOScale(Vector3.one * 2, 0.3f);
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            //transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
       DataHandler.Instance.SetFurniture(_itemId);
    }
}
