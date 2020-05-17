using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class AttackAnimationEnded : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    public void AttackEndedEvent()
    {
        pc.StopAttack();
    }
}
