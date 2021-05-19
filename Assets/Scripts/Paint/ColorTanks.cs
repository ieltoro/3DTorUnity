using UnityEngine;

public class ColorTanks : MonoBehaviour
{
    public Color color;
    public bool usingTank;
    [SerializeField] Rigidbody rb;
    [SerializeField] CapsuleCollider collider;
    [SerializeField] WaterGunManager wgm;
    GameObject colorPistol;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.tag == "WaterTank")
    //    {
    //        if(!other.GetComponent<TankTrigger>().wgm.tankOn)
    //        {
    //            colorPistol = other.gameObject;
    //            usingTank = true;
    //            rb.isKinematic = true;
    //            transform.parent = other.transform.GetChild(0).transform;
    //            transform.localPosition = new Vector3(0, 0, 0);
    //            transform.localRotation = new Quaternion(0, 180, 0, 0);
    //            colorPistol.GetComponent<TankTrigger>().wgm.TankConnected(color, this.gameObject);
    //        }
    //    }
    //}
    public void Connected(GameObject g)
    {
        usingTank = true;
        rb.isKinematic = true;
        transform.parent = g.transform.GetChild(0).transform;
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = new Quaternion(0, 180, 0, 0);
    }

    public void PickUpTank()
    {
        collider.enabled = false;
        if (usingTank)
        {
            print("PickedUpTankWhileUsing");
            transform.parent = null;
            rb.isKinematic = false;
            usingTank = false;
            wgm.DropTank();
        }
    }
    public void DroppedFromHand()
    {
        print("DroppedFromHand");
        collider.enabled = true;
        rb.isKinematic = false;
        transform.parent = null;
    }
}
