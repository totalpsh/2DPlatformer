using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity = new Vector2(10, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Terrain")
        {
            //Destroy(gameObject);
            // ������Ʈ Ǯ���� ����߱� ������ ������ �ı� ��Ű�� �ȵȴ�.
            gameObject.SetActive(false);
        }
        else if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Hit(1);
            gameObject.SetActive(false);
        }
    }
}
