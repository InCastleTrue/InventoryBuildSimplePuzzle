using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotNum;
    public Item item;
    public Image itemIcon;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
            //itemIcon.sprite�� ������ �̹����� �ʱ�ȭ�ϰ� Ȱ��ȭ ��������


    }
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

public void OnPointerUp(PointerEventData eventData)
{
    if (item != null)
    {
        bool isUse = item.Use();
        if (isUse)
        {
            Inventory.Instance.RemoveItem(slotNum);
        }
        else
        {
            Debug.Log("�Ҹ�ǰ�� �ƴմϴ�");
        }
    }
}
}
