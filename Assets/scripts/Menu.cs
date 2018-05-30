using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Text HighScore;

	void Start()
	{
		HighScore.text ="HighScore :"+ PlayerPrefs.GetInt ("Score").ToString();
		
	}
	public void PlayGame()
	{
		SceneManager.LoadScene (1);
	}
	public void MainMenu()
	{
		SceneManager.LoadScene (0);
	}
	public void Store()
	{
		SceneManager.LoadScene (2);
	}



}
