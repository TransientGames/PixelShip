using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool down = false;
    public float speed = 1f;


    void Update()
    {
        if (down)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
