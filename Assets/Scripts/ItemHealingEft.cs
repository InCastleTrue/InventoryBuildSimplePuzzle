using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ItemEffect�� ��ӹް� ���ϴ� ������ ��� ȿ���� �����ϸ� ��
[CreateAssetMenu(menuName = "ItemEft/ConsumAble/Health")]
//��Ʈ����Ʈ �߰�
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("PlayerHp Add : " +  healingPoint);
        return true;
    }
}
