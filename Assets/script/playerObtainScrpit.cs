using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerObtainScrpit : MonoBehaviour
{
    [SerializeField]
    List<GameObject> obtainedObjectList = new List<GameObject>();
    [SerializeField]
    List<GameObject> intaractedObjectList = new List<GameObject>();
    private int ListCount;
    [SerializeField]
    private GameObject[] UIs;//panel�̂���
    [SerializeField]
    private TextMeshProUGUI[] TMPs;//textMESHpro�̂���
    [SerializeField]
    ItemManager itemManager;
    [SerializeField]
    InventoryManager inventoryManager;
    [SerializeField]
    private GameObject InventoryFull;
    IntaractedObj intaractedObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && obtainedObjectList.Count != 0 && inventoryManager.inventorynumber < 10)//�A�C�e�����擾���鏈��
        {
            itemManager.ItemDatas[itemManager.ItemIndexDict[obtainedObjectList[0].name]].ItemCount += 1;
            inventoryManager.ApplyToInventory();
            Destroy(obtainedObjectList[0]);
            obtainedObjectList.RemoveAt(0);
            UIReloader();
        }
        else if (Input.GetKeyDown(KeyCode.V) && intaractedObjectList.Count != 0)
        {
            if (itemManager.IsHasItem(intaractedObj.needItems))
            {
                intaractedObj.OnAction.Invoke();//�ϐ��̒��̊֐������s���邽�߁A�uinvoke�v
            }
        }
        else if (inventoryManager.inventorynumber >= 10)
        {
            InventoryFullActiveTimer();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "obtainable")
        {
            obtainedObjectList.Add(collision.gameObject);
            UIReloader();
        }
        if (collision.gameObject.tag == "IntaractableObj")
        {
            intaractedObjectList.Add(collision.gameObject);
            intaractedObj = intaractedObjectList[0].GetComponent<IntaractedObj>();
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
        if (collision.gameObject.tag == "IntaractableObj")
        {
            intaractedObjectList.Remove(collision.gameObject);
            UIReloader();
        }
    }

    /// <summary>
    /// �擾�\�ȃI�u�W�F�N�g�̖��O���o���Ă���UI�̍X�V����
    /// </summary>
    void UIReloader()
    {
        for (int i = 0; i < ListCount && i < 3; i++)//���X�g���X�V����O�̌���UI���\��
        {
            UIs[i].SetActive(false);
        }
        ListCount = obtainedObjectList.Count;
        for (int i = 0; i < ListCount && i < 3; i++)//���X�g���X�V������̌���UI���ĕ\��
        {
            UIs[i].SetActive(true);
            TMPs[i].text = obtainedObjectList[i].name;
        }
        if (intaractedObjectList.Count != 0)
        {
            UIs[3].SetActive(true);
            TMPs[3].text = intaractedObjectList[0].name;
        }
        else if (intaractedObjectList.Count == 0)
        {
            UIs[3].SetActive(false);
        }
    }
    private IEnumerator InventoryFullActiveTimer()
    {
        InventoryFull.SetActive(true);
        yield return new WaitForSeconds(4);
        InventoryFull.SetActive(false);
    }
}
