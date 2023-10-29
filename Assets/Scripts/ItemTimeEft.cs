using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/ConsumAble/Timer")]
public class ItemTimeEft : ItemEffect
{
    public int time = 0;
    private Timer timer; // private���� ����

    public override bool ExecuteRole()
    {
        // �ڵ带 ���� Timer �ν��Ͻ��� ã�Ƽ� �Ҵ�
        FindAndAssignTimer();

        if (timer != null)
        {
            timer.currentTime += time;

            if (timer.timerText != null)
            {
                timer.timerText.text = Mathf.Floor(timer.currentTime).ToString();
            }

            Debug.Log("timer : " + time);
        }
        else
        {
            Debug.Log("timer is null");
        }
        return true;
    }

    private void FindAndAssignTimer()
    {
        // Timer�� ã�Ƽ� �Ҵ�
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }
    }
}
