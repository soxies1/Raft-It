using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	void Start () {
		StartCoroutine("RestartGame");
	}

	IEnumerator RestartGame(){
		yield return new WaitForSeconds(6f);
		Destroy(GameManager.Instance);
		SceneManager.LoadScene(0);
	}
	
}
