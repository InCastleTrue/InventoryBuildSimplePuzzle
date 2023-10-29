using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singeton
    public static Inventory Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Initialize the onSlotCountChange delegate
        onSlotCountChange = null;
    }


    #endregion


    //SlotCnt 값이 변경되면 변경되었다고 알려주기 위해 Delgate(대리자)를 사용
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    //delegate를 여기서도 활용해 아이템이 추가되면 슬롯 UI에도 추가되게 만들자

    public List<Item>items = new List<Item>();
    //획득한 아이템을 담을 List를 1개 생성

    private int slotCnt; // Slot의 갯수를 정할 int형 변수
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);//여기서 호출
        }
    }

    void Start()
    {
        SlotCnt = 4;
    }

    public bool AddItem(Item _item) //items리스트에 아이템을 추가할 수 있는 메서드 생성
    // 단 items의 개수가 SlotCnt(현재 활성화된 슬롯) 보다 작을 때만 추가
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null) 
            onChangeItem.Invoke();
                //아이템 추가에 성공하면 호출
            return true;
        }
        return false;
        //추가에 성공하면 true 아니면 false
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        //index에 맞는 items의 속성을 제거하고
        onChangeItem.Invoke();
        //onchangeItem을 호출해서 화면을 다시 그려주자

    }

    public bool HasItemWithName(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.itemName == itemName)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
            //이때 AddItem이 추가되면 true를 반환하니
            //이걸 써서 필드 아이템을 파괴시키자
            {
                fieldItems.DestoryItem();
            }
        }
    }
}
