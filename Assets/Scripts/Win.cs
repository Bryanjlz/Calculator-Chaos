using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	[SerializeField] CanvasGroup cg;
	[SerializeField] Transform panel;
	[SerializeField] float time;

	private bool doneTrans = false;
	private float vel;
	private Vector2 vel1;
	void Start() {
		GameObject.Find("Round").GetComponent<RoundManager>().Pause();
		cg.alpha = 0f;
	}

	// Update is called once per frame
	void Update() {
		if (!doneTrans) {
			cg.alpha = Mathf.SmoothDamp(cg.alpha, 1f, ref vel, time);
			panel.position = Vector2.SmoothDamp(panel.position, Vector2.zero, ref vel1, time);
			if (cg.alpha > 0.999f) {
				doneTrans = true;
            }
		}
	}

	public void NextLevel (string sceneName) {
		ChangeScene(sceneName);
    }

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
    }
}
