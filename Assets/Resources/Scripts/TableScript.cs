using UnityEngine;

public class TableScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "JengaWood")
        {
            GameManager.instance.WoodColidedWithTable();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "JengaWood")
        {
            GameManager.instance.WoodLeftTable();
        }
    }
}
