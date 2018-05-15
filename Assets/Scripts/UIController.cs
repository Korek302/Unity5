using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject FinishPanel;

    private Text _scoreLabel;
    private int _score = 0;

    private void Awake()
    {
        FinishPanel.SetActive(false);
        Messenger.AddListener(GameEvent.PICK_UP, OnPickUp);
        Messenger.AddListener(GameEvent.HIT, OnHit);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.PICK_UP, OnPickUp);
        Messenger.RemoveListener(GameEvent.HIT, OnHit);
    }

    void Start ()
    {
        _scoreLabel = this.GetComponentsInChildren<Text>()[0];
        _scoreLabel.text = _score.ToString();
	}
	
	private void OnPickUp()
    {
        _score++;
        _scoreLabel.text = _score.ToString();
    }

    private void OnHit()
    {
        _score++;
        _scoreLabel.text = _score.ToString();
    }

    private void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            FinishPanel.SetActive(true);
            Messenger.Broadcast(GameEvent.FINISH_GAME);
            //Destroy(GameObject.FindGameObjectWithTag("Player"));
            Cursor.visible = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
