using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class AxeController : CloseWeaponController
{
    public static bool isActivate = false;

    void Update()
    {
        if (isActivate)
            TryAttack();
        //Debug.DrawRay(transform.position, transform.forward * currentHand.range, Color.red);
    }

    protected override IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            if (CheckObject())
            {
               isSwing = false;
               Debug.Log(hitInfo.transform.name);
            }
            yield return null;
        }
    }

    public override void CloseWeaponChange(CloseWeapon _currentCloseWeapon)
    {
        base.CloseWeaponChange(_currentCloseWeapon);
        isActivate = true;
    }
}
