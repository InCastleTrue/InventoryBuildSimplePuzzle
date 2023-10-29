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


    //SlotCnt ���� ����Ǹ� ����Ǿ��ٰ� �˷��ֱ� ���� Delgate(�븮��)�� ���
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    //delegate�� ���⼭�� Ȱ���� �������� �߰��Ǹ� ���� UI���� �߰��ǰ� ������

    public List<Item>items = new List<Item>();
    //ȹ���� �������� ���� List�� 1�� ����

    private int slotCnt; // Slot�� ������ ���� int�� ����
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);//���⼭ ȣ��
        }
    }

    void Start()
    {
        SlotCnt = 4;
    }

    public bool AddItem(Item _item) //items����Ʈ�� �������� �߰��� �� �ִ� �޼��� ����
    // �� items�� ������ SlotCnt(���� Ȱ��ȭ�� ����) ���� ���� ���� �߰�
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null) 
            onChangeItem.Invoke();
                //������ �߰��� �����ϸ� ȣ��
            return true;
        }
        return false;
        //�߰��� �����ϸ� true �ƴϸ� false
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        //index�� �´� items�� �Ӽ��� �����ϰ�
        onChangeItem.Invoke();
        //onchangeItem�� ȣ���ؼ� ȭ���� �ٽ� �׷�����

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
            //�̶� AddItem�� �߰��Ǹ� true�� ��ȯ�ϴ�
            //�̰� �Ἥ �ʵ� �������� �ı���Ű��
            {
                fieldItems.DestoryItem();
            }
        }
    }
}
