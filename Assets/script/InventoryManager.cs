using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    ItemManager itemManager;
    public Image[] Inventorys;
    [SerializeField]
    private TextMeshProUGUI[] ItemQuantity;//ƒAƒCƒeƒ€‚ÌŒÂ”
    public int inventorynumber = 0;
    // Start is called before the first frame update
    public void ApplyToInventory()
    {
        inventorynumber = 0;
        for (int i = 0; i < itemManager.ItemDatas.Length&&inventorynumber < 10; i++)
        {
            if (itemManager.ItemDatas[i].ItemCount != 0)
            {
                Inventorys[inventorynumber].sprite = itemManager.ItemDatas[i].ItemImage;
                ItemQuantity[inventorynumber].text = itemManager.ItemDatas[i].ItemCount.ToString();
                inventorynumber ++ ;
            }
        }
    }
}
