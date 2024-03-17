using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    [Serializable]
    public class ItemData
    {
        public string ItemName;
        public int ItemCount;
        public Sprite ItemImage;
    }
    [SerializeField]
    public ItemData[] ItemDatas;
    public string[] needItemList;

    public Dictionary<string, int> ItemIndexDict = new Dictionary<string, int>();//アイテム名、アイテム管理番号

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ItemDatas.Length; i++)
        {
            ItemIndexDict.Add(ItemDatas[i].ItemName, i);
        }
    }
    public bool IsHasItem (string[] needItems)
    {
        for (int i = 0 ; i < needItems.Length ; i++)
        {
            Debug.Log("動いたよ");
            Debug.Log(needItems.Length);
            if (ItemDatas[ItemIndexDict[needItems[i]]].ItemCount == 0)
            {
                return false;
            }
        }
        return true;
    }
}
