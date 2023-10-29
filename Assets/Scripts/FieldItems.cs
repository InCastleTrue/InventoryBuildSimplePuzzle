using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;// 어떤 아이템인지 알아야하니 선언
    public SpriteRenderer image;//아이템에 맞게 이미지도 변환해야하니 선언

    public void SetItem(Item _item)    //SetItem메서드 생성하고 매개변수는 Item을 가짐
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.efts = _item.efts;

        image.sprite = item.itemImage;//아이템에 맞춰 Sprite 전환
    }    

    public Item GetItem()// 아이템을 획득 시에 사용할 메서드
    {

        return item;

    }
    public void DestoryItem()//획득 시에 필드 아이템 파괴
    {
        Destroy(gameObject);
    }
}
