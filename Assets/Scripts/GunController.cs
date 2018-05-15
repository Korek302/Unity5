using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public int range = 50;
    public Texture2D viewfinderTexture;
    public AudioClip pistolShotClip;

    private AudioSource audioSource;
    private Rect viewfinderPos;
    private bool acceptInput = true;

    void Start()
    {
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pistolShotClip;
        viewfinderPos = new Rect((Screen.width - viewfinderTexture.width) / 2,
            (Screen.height - viewfinderTexture.height) / 2,
            viewfinderTexture.width, viewfinderTexture.height);
        Messenger.AddListener(GameEvent.FINISH_GAME, OnFinish);
    }

    void Update ()
    {
		if(Input.GetButtonDown("Fire1") && acceptInput)
        {
            audioSource.PlayOneShot(pistolShotClip);

            Ray ray = new Ray(transform.parent.position, transform.parent.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Enemy" && hit.distance < range)
                {
                    hit.transform.gameObject.GetComponent<EnemyController>().hit();
                    hit.transform.tag = "Untagged";
                    Messenger.Broadcast(GameEvent.HIT);
                }
            }
        }
	}

    void OnGUI()
    {
        GUI.DrawTexture(viewfinderPos, viewfinderTexture);
    }

    private void OnFinish()
    {
        acceptInput = false;
    }
}
