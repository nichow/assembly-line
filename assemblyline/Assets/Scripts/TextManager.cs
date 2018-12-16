using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour 
{

	public Text TextBox; // the text unity object
	private int _textIndex = 0;

	/* The text available to be displayed in the scene */
	private readonly string[] _text =
	{
		"I am giving you instructions.",
		"I am clarifying those instructions.",
		"I am making a snide remark."
	};
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(AnimateText());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit"))
		{

			if (_textIndex == _text.Length - 1) SceneManager.LoadScene("AssemblyLineScene");
			_textIndex++;
			StopAllCoroutines();
			StartCoroutine(AnimateText());
		}
	}
	
	IEnumerator AnimateText()
	{
		for (var i = 0; i < _text[_textIndex].Length + 1; i++)
		{
			TextBox.text = _text[_textIndex].Substring(0, i);
			yield return new WaitForSeconds(.01f);
		}
	}
}
