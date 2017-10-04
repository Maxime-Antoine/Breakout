using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.LoseLife();
    }
}
