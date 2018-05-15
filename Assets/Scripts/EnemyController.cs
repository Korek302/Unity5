using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ParticleSystem explosion;
    private bool isHit = false;

    private void Start()
    {
        Messenger.AddListener(GameEvent.HIT, OnHit);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HIT, OnHit);
    }

    private void OnHit()
    {
        if (isHit)
        {
            explosion = this.gameObject.GetComponent<ParticleSystem>();
            explosion.Play();
            Destroy(this.gameObject, 0.5f);
        }
    }

    public void hit()
    {
        isHit = true;
    }
}
