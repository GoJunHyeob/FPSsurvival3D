using UnityEngine;
using UnityEngine.UI;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Base;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Text txt_ItemName;
    [SerializeField]
    private Text txt_ItemDesc;
    [SerializeField]
    private Text txt_ItemHowtoUsed;

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        go_Base.SetActive(true);
        _pos += new Vector3(go_Base.GetComponent<RectTransform>().rect.width * 0.5f, -go_Base.GetComponent<RectTransform>().rect.height * 0.5f, 0f);
        transform.position = _pos;
        //rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x + go_Base.GetComponent<RectTransform>().rect.width * 0.5f,
        //                                             rectTransform.anchoredPosition.y - go_Base.GetComponent<RectTransform>().rect.height * 0.5f ,0f);
        txt_ItemName.text = _item.itemName;
        txt_ItemDesc.text = _item.itemDesc;

        if (_item.itemType == Item.ItemType.Equipment)
            txt_ItemHowtoUsed.text = "¿ìÅ¬¸¯ - ÀåÂø";
        else if (_item.itemType == Item.ItemType.Used)
            txt_ItemHowtoUsed.text = "¿ìÅ¬¸¯ - ¸Ô±â";
        else 
            txt_ItemHowtoUsed.text = "";

    }

    public void HideToolTip()
    {
        go_Base.SetActive(false);
    }
}
