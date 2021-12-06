using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrap : MonoBehaviour
{
    CharacterEffects player;
    private CTrap trap;

    private void Awake()
    {
        trap = new CTrap();
        player = GameObject.Find("Player").GetComponent<CharacterEffects>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<ICharacterEffects>();
        trap.HandleColorCharacterEntered(character, player);
    }
}

public class CTrap
{
    public void HandleColorCharacterEntered(ICharacterEffects character, CharacterEffects player)
    {
        if (character.MatColor)
        {
            player.mat.color = Color.green;
        }
    }
}
