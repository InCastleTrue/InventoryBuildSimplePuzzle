using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/ConsumAble/Timer")]
public class ItemTimeEft : ItemEffect
{
    public int time = 0;
    private Timer timer; // private으로 변경

    public override bool ExecuteRole()
    {
        // 코드를 통해 Timer 인스턴스를 찾아서 할당
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
        // Timer를 찾아서 할당
        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
        }
    }
}
