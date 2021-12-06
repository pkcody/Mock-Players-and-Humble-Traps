using NSubstitute;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTests
{
    [Test]
    public void PlayerEnteringTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterEffects characterMover = Substitute.For<ICharacterEffects>();
        characterMover.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void NpcEnteringTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterEffects characterMover = Substitute.For<ICharacterEffects>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);
        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void PlayerEnteringTrap_FlyUp()
    {
        MTrap mtrap = new MTrap();
        Rigidbody rb = new Rigidbody();
        ICharacterEffects character = Substitute.For<ICharacterEffects>();
        mtrap.HandleMoveCharacterEntered(character, TrapTargetType.Player, rb);
        Assert.AreNotEqual(1.5, character.Height);
    }

    [Test]
    public void PlayerEnteringTrap_ChangeColor()
    {
        CTrap ctrap = new CTrap();
        CharacterEffects player = new CharacterEffects();
        ICharacterEffects character = Substitute.For<ICharacterEffects>();
        ctrap.HandleColorCharacterEntered(character, player);
        Assert.AreEqual(false, character.MatColor);
    }
}
