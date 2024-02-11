using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerObtainScrpit : MonoBehaviour
{
    [SerializeField]
    List<GameObject> obtainedObjectList = new List<GameObject>();
    private int ListCount;
    [SerializeField]
    private GameObject[] UIs;//panelのこと
    [SerializeField]
    private TextMeshProUGUI[] TMPs;//textMESHproのこと

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && obtainedObjectList.Count != 0)//アイテムを取得する処理
        {
            Destroy(obtainedObjectList[0]);
            obtainedObjectList.RemoveAt(0);
            UIReloader();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "obtainable")
        {
            obtainedObjectList.Add(collision.gameObject);
            UIReloader();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "obtainable")
        {
            obtainedObjectList.Remove(collision.gameObject);
            UIReloader();
        }
    }

    /// <summary>
    /// 取得可能なオブジェクトの名前を出しているUIの更新処理
    /// </summary>
    void UIReloader()
    {
        for (int i = 0; i < ListCount && i < 3; i++)//リストを更新する前の個数のUIを非表示
        {
            UIs[i].SetActive(false);
        }
        ListCount = obtainedObjectList.Count;
        for (int i = 0; i < ListCount && i < 3; i++)//リストを更新した後の個数のUIを再表示
        {
            UIs[i].SetActive(true);
            TMPs[i].text = obtainedObjectList[i].name;
        }
    }
}
