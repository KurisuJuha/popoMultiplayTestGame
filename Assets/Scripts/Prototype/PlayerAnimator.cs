using UnityEngine;
using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class PlayerAnimator : PopoBehaviour
{
    [TabGroup("Tab", "RequireComponents"), SerializeField, Required] private Rigidbody2D rigidBody2D;
    [TabGroup("Tab", "RequireComponents"), SerializeField, Required] private SpriteRenderer spriteRenderer;


    [TabGroup("Tab", "Parameter"), SerializeField] private float spriteChangeSpeed;
    [TabGroup("Tab", "Parameter"), SerializeField] private Sprite[] sprites;
    [ShowInInspector]
    public float elapsed
    {
        get => _elapsed;
        set => _elapsed = value % sprites.Length;
    }
    private float _elapsed;

    protected override void LateUpdate()
    {
        elapsed += Time.deltaTime * spriteChangeSpeed * rigidBody2D.velocity.magnitude;
        elapsed %= sprites.Length;
        spriteRenderer.sprite = sprites[Mathf.FloorToInt(elapsed)];
    }
}
