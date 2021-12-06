using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour, ICharacterEffects
{
    private CharacterController characterController;

    [SerializeField]
    private bool isPlayer;
    private float height;

    private bool isMatColor = true;
    public Material mat;
    public bool IsPlayer => isPlayer;

    public int Health { get; set; }

    public float Height => height;

    public bool MatColor => isMatColor;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mat = this.GetComponent<Renderer>().material;
        mat.color = Color.blue;
    }

    private void Update()
    {
        if (mat.color == Color.blue)
            isMatColor = true;
        else
            isMatColor = false;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(new Vector3(horizontal, height, vertical));
    }
}
