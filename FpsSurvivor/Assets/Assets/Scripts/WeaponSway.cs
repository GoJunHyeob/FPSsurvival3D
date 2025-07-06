using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    //���� ��ġ
    private Vector3 originPos;

    //���� ��ġ
    private Vector3 currentPos;

    //sway �Ѱ�
    [SerializeField]
    private Vector3 limitPos;

    //������ sway �Ѱ�
    [SerializeField]
    private Vector3 fineSightlimitPos;

    //�ε巯�� ������ ����
    [SerializeField]
    private Vector3 smoothSway;

    //�ʿ��� ������Ʈ
    [SerializeField]
    private GunController theGunController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Inventory.inventoryActivated)
            TrySway();
    }
    private void TrySway()
    {
        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
            Swaying();
        else
            BackToOriginPos();
    }

    private void Swaying()
    {
        float _moveX = Input.GetAxisRaw("Mouse X");
        float _moveY = Input.GetAxisRaw("Mouse Y");

        if (!theGunController.GetFineSightMode())
        {
            currentPos.Set(Mathf.Clamp(Mathf.Lerp(currentPos.x, -_moveX, smoothSway.x), -limitPos.x, limitPos.x),
                           Mathf.Clamp(Mathf.Lerp(currentPos.y, -_moveY, smoothSway.x), -limitPos.y, limitPos.y),
                           originPos.z);
        }
        else
        {
            currentPos.Set(Mathf.Clamp(Mathf.Lerp(currentPos.x, -_moveX, smoothSway.y), -fineSightlimitPos.x, fineSightlimitPos.x),
                          Mathf.Clamp(Mathf.Lerp(currentPos.y, -_moveY, smoothSway.y), -fineSightlimitPos.y, fineSightlimitPos.y),
                          originPos.z);
        }

        transform.localPosition = currentPos;
    }

    private void BackToOriginPos()
    {
        currentPos = Vector3.Lerp(currentPos, originPos, smoothSway.x);
        transform.localPosition = currentPos;
    }

}
