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
    private GameObject[] UIs;//panel�̂���
    [SerializeField]
    private TextMeshProUGUI[] TMPs;//textMESHpro�̂���

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && obtainedObjectList.Count != 0)//�A�C�e�����擾���鏈��
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
    }
}
