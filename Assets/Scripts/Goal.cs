using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject panel; // Ȱ��ȭ�� �г�
    public string[] requiredItemNames; // ���� ������ �̸��� ������ �迭
    public GameObject timerObject;


    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("����");
            CheckForItems();
            
        }
    }

private void CheckForItems()
{
    Inventory inventory = Inventory.Instance;

    if (inventory != null)
    {
        // �κ��丮�� ��� �ʼ� �������� �ִ��� Ȯ��
        bool hasAllItems = true;

        foreach (string itemName in requiredItemNames)
        {
            if (!inventory.HasItemWithName(itemName))
            {
                hasAllItems = false;
                break; // ������ �������� ã�ڸ��� ������ �������ɴϴ�
            }
        }

        if (hasAllItems)
        {
            panel.SetActive(true);
            timerObject.SetActive(false);
            }
        else
        {
            Debug.Log("�ʼ� �������� ������� �ʽ��ϴ�.");
        }
    }
}

}
