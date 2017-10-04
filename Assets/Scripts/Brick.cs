using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject particles;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
