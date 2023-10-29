using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ItemEffect를 상속받고 원하는 아이템 사용 효과를 구현하면 됨
[CreateAssetMenu(menuName = "ItemEft/ConsumAble/Health")]
//애트리뷰트 추가
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("PlayerHp Add : " +  healingPoint);
        return true;
    }
}
