using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform spawnPointBullet;
    private float delayShot;

    private void OnEnable()
    {
        delayShot = GameSettings.GetPlayerSettings.DelayShot;
        StartCoroutine(TimerShot());
    }

    private IEnumerator TimerShot()
    {
        yield return new WaitForSeconds(delayShot);
        var bullet = BulletPool.GetObject(spawnPointBullet.position, transform.forward);
        AudioEnvironment.ShotAudio();
        StartCoroutine(TimerShot());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
}
