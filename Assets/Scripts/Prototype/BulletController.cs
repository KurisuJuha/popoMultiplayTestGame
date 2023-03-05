using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;
using UnityEngine;

[HideMonoScript]
public class BulletController : PopoBehaviour
{
    [ShowInInspector, TabGroup("Tab", "Parameter")] public bool isMyTeam { get; private set; }
    [SerializeField, TabGroup("Tab", "Parameter")] private float speed;
    [SerializeField, Required, TabGroup("Tab", "Components")] private Rigidbody2D rigidBody2D;

    protected override void Update()
    {
        rigidBody2D.velocity = transform.up * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.TryGetComponent<BulletController>(out var otherBullet) && otherBullet.isMyTeam)) Destroy(gameObject);
    }
}