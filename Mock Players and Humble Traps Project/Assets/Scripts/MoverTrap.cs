using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTrap : MonoBehaviour
{
    Rigidbody rb_;

    [SerializeField]
    private TrapTargetType trapType;

    private MTrap trap;

    private void Awake()
    {
        trap = new MTrap();
        rb_ = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<ICharacterEffects>();
        trap.HandleMoveCharacterEntered(character, trapType, rb_);
    }
}

public class MTrap
{
    public void HandleMoveCharacterEntered(ICharacterEffects character, TrapTargetType trapTargetType, Rigidbody rb)
    {
        if (character.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                rb.AddForce(0, 0, 4, ForceMode.Impulse);
        }
        else
        {
            if (trapTargetType == TrapTargetType.Npc)
                rb.AddForce(0, 0, 1, ForceMode.Impulse);
        }


    }
}

public enum MTrapTargetType { Player, Npc }