using UnityEngine;
using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class GunController : PopoBehaviour
{
    [SerializeField, Required, TabGroup("Tab", "Components")] private Transform gunTransform;
    [SerializeField, TabGroup("Tab", "Parameter")] private float maxGunDistance;


    protected override void Update()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition = new(cursorPosition.x, cursorPosition.y, 0);
        transform.rotation = Quaternion.FromToRotation(Vector3.right, (cursorPosition - transform.position));
        transform.localScale = new(
            1,
            ((transform.rotation.eulerAngles.z + 90) % 360f) < 180 ? 1 : -1,
            1
        );

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, maxGunDistance, 1 << 9);
        gunTransform.localPosition = new(hit2D ? ((Vector2)transform.position - hit2D.point).magnitude : maxGunDistance, 0, 0);
    }
}
