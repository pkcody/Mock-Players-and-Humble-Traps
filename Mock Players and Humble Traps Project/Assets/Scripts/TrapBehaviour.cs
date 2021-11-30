using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] 
    private TrapTargetType trapType;
    
    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }

    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacterMover characterMover, TrapTargetType trapTargetType)
    {
        if (characterMover.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                characterMover.Health--;
        }
        else
        {
            if (trapTargetType == TrapTargetType.Npc)
                characterMover.Health--;
        }

        
    }
}

public enum TrapTargetType { Player, Npc }