using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject panel; // 활성화할 패널
    public string[] requiredItemNames; // 여러 아이템 이름을 저장할 배열
    public GameObject timerObject;


    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("닿음");
            CheckForItems();
            
        }
    }

private void CheckForItems()
{
    Inventory inventory = Inventory.Instance;

    if (inventory != null)
    {
        // 인벤토리에 모든 필수 아이템이 있는지 확인
        bool hasAllItems = true;

        foreach (string itemName in requiredItemNames)
        {
            if (!inventory.HasItemWithName(itemName))
            {
                hasAllItems = false;
                break; // 누락된 아이템을 찾자마자 루프를 빠져나옵니다
            }
        }

        if (hasAllItems)
        {
            panel.SetActive(true);
            timerObject.SetActive(false);
            }
        else
        {
            Debug.Log("필수 아이템이 충분하지 않습니다.");
        }
    }
}

}
