using UnityEngine;
using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class PlayerController : PopoBehaviour
{
    [TabGroup("Tab", "RequireComponents"), SerializeField, Required] private Rigidbody2D rigidBody2D;
    [TabGroup("Tab", "Parameter"), SerializeField] private float walkSpeed;

    protected override void Update()
    {
        Vector2 inputVec = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidBody2D.velocity = inputVec.normalized * walkSpeed;
    }
}
