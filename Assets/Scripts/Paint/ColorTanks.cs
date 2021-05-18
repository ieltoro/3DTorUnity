using UnityEngine;

public class ColorTanks : MonoBehaviour
{
    public Color color;
    public bool usingTank;
    [SerializeField] Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "WaterTank")
        {
            if(!other.GetComponent<TankTrigger>().wgm.tankOn)
            {
                rb.isKinematic = true;
                transform.parent = other.transform.GetChild(0).transform;
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = new Quaternion(0, 180, 0, 0);
                other.GetComponent<TankTrigger>().wgm.TankConnected(color, this.gameObject);
            }
        }
    }
}
