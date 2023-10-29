using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // 열거형
{
    Equipment,
    Consumables,
    Etc,
    Timer
}

[System.Serializable] //직렬화 시킴
public class Item // MonoBehaviour 지워버리기
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()// 아이템 사용 성공 여부 반환을 위해 bool
    {
        bool isUsed = false; //bool 값 선언 후에

        foreach (ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }

        return isUsed;
        
    }
}
