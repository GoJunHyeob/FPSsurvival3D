using UnityEngine;
using System.Collections;

public abstract class CloseWeaponController : MonoBehaviour
{
   

    [SerializeField]
    protected CloseWeapon currentCloseWeapon;

    protected bool isAttack = false;
    protected bool isSwing = false;

    protected RaycastHit hitInfo;
    [SerializeField]
    protected LayerMask layerMask;


    protected void TryAttack()
    {
        if (!Inventory.inventoryActivated)
        { 
            if (Input.GetButton("Fire1"))
            {
                 if (!isAttack)
                 {
                     StartCoroutine(AttackCoroutine());
                 }
            }
        }
    }

    protected IEnumerator AttackCoroutine()
    {
        isAttack = true;
        currentCloseWeapon.anim.SetTrigger("Attack");

        yield return new WaitForSeconds(currentCloseWeapon.attackDelayA);
        isSwing = true;
        StartCoroutine(HitCoroutine());

        yield return new WaitForSeconds(currentCloseWeapon.attackDelayB);
        isSwing = false;

        yield return new WaitForSeconds(currentCloseWeapon.attackDelayA - currentCloseWeapon.attackDelayB);
        isAttack = false;
    }

    protected abstract IEnumerator HitCoroutine();

    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currentCloseWeapon.range, layerMask))
        {
            return true;
        }
        return false;
    }

    public virtual void CloseWeaponChange(CloseWeapon _currentCloseWeapon)
    {
        if ((WeaponManager.currentWeapon != null))
        {
            if (WeaponManager.currentWeapon != null)
                WeaponManager.currentWeapon.gameObject.SetActive(false);

            currentCloseWeapon = _currentCloseWeapon;
            WeaponManager.currentWeapon = currentCloseWeapon.GetComponent<Transform>();
            WeaponManager.currentWeaponAnim = currentCloseWeapon.anim;

            currentCloseWeapon.transform.localPosition = Vector3.zero;
            currentCloseWeapon.gameObject.SetActive(true);
        }
    }
}
