using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;// � ���������� �˾ƾ��ϴ� ����
    public SpriteRenderer image;//�����ۿ� �°� �̹����� ��ȯ�ؾ��ϴ� ����

    public void SetItem(Item _item)    //SetItem�޼��� �����ϰ� �Ű������� Item�� ����
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.efts = _item.efts;

        image.sprite = item.itemImage;//�����ۿ� ���� Sprite ��ȯ
    }    

    public Item GetItem()// �������� ȹ�� �ÿ� ����� �޼���
    {

        return item;

    }
    public void DestoryItem()//ȹ�� �ÿ� �ʵ� ������ �ı�
    {
        Destroy(gameObject);
    }
}
