using UnityEngine;
using JuhaKurisu.PopoTools.Extentions;
using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class GunController : PopoBehaviour
{
    [SerializeField, Required, TabGroup("Tab", "Components")] private Transform gunTransform;
    [SerializeField, TabGroup("Tab", "Parameter")] private float maxGunDistance;
    [SerializeField, TabGroup("Tab", "Parameter"), DisableInPlayMode] private float interval;
    [SerializeField, TabGroup("Tab", "Parameter"), ReadOnly] private Vector3 cursorPosition;
    [SerializeField, Required, TabGroup("Tab", "Prefabs")] private GameObject bulletPrefab;
    private ActionWithInterval FireWithInterval;

    protected override void Awake()
    {
        FireWithInterval = new ActionWithInterval(interval, Fire);
    }

    protected override void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition = new(cursorPosition.x, cursorPosition.y, 0);

        RotateGun();
        if (Input.GetKey(KeyCode.Space)) FireWithInterval.Invoke();
    }

    private void RotateGun()
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.right, (cursorPosition - transform.position));
        transform.localScale = new(
            1,
            ((transform.rotation.eulerAngles.z + 90) % 360f) < 180 ? 1 : -1,
            1
        );

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, maxGunDistance, 1 << 9);
        gunTransform.localPosition = new(hit2D ? ((Vector2)transform.position - hit2D.point).magnitude : maxGunDistance, 0, 0);
    }

    private void Fire()
    {
        "Fire".Inspect();

        Instantiate(bulletPrefab, gunTransform.position, Quaternion.Euler(0, 0, gunTransform.rotation.eulerAngles.z - 90));
    }
}
