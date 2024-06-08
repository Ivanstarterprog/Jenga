using UnityEngine;

public class TableScript : MonoBehaviour
{

    public GameObject firstPlayerRagePoint;
    public GameObject secondPlayerRagePoint;
    private bool _isTurnedOver;

    private void Start()
    {
        _isTurnedOver = false;
    }

    /**ate void Update()
    {
        if (!_isTurnedOver && GameManager.instance.isGameEnded) 
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameManager.instance.currentPlayer == "First")
                {
                    
                }
            }
        }
    }**/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "JengaWood")
        {
            GameManager.instance.WoodColidedWithTable();
            Debug.Log(collision.gameObject.name);
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
