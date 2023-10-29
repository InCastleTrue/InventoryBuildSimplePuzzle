using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // ������
{
    Equipment,
    Consumables,
    Etc,
    Timer
}

[System.Serializable] //����ȭ ��Ŵ
public class Item // MonoBehaviour ����������
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()// ������ ��� ���� ���� ��ȯ�� ���� bool
    {
        bool isUsed = false; //bool �� ���� �Ŀ�

        foreach (ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed;
        
    }
}
