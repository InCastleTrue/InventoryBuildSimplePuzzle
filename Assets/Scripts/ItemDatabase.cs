using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;//다른 클래스에서 접근 하게 함
    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>(); // 아이템 리스트

    public GameObject fieldItem;
    public Transform key1Transform;
    public Transform key2Transform;
    public Transform key3Transform;
    public Transform timerTransform;
    


    private void Start()
    {

        GameObject go = Instantiate(fieldItem, key1Transform.position, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemDB[2]);
        GameObject go1 = Instantiate(fieldItem, key2Transform.position, Quaternion.identity);
        go1.GetComponent<FieldItems>().SetItem(itemDB[3]);
        GameObject go2 = Instantiate(fieldItem, key3Transform.position, Quaternion.identity);
        go2.GetComponent<FieldItems>().SetItem(itemDB[4]);
        GameObject timer = Instantiate(fieldItem, timerTransform.position, Quaternion.identity);
        timer.GetComponent<FieldItems>().SetItem(itemDB[5]);

    }
}




