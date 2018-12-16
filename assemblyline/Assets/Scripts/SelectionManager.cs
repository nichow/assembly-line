using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public GameObject[] Interactables; // array of the interactable objects in the scene
    private GameObject _highlighted; // the highlighted object in the scene 
    private SpriteRenderer _hlRenderer; // the renderer of the highlighted object in the scene
    private int _selected; // index of object selected ; default value of zero

    public Text TextBox; // the text unity object

    /* The text available to be displayed in the scene */
    private readonly string[] _text =
    {
        "this is a description for selection 0",
        "this is a description for selection 1",
        "this is a description for selection 2"
    };
    /* names of the scenes that can be loaded from this scene */
    private readonly string[] _scenes =
    {
        "name of scene for selection 0",
        "name of scene for selection 1",
        "name of scene for selection 2"
    };

    // Use this for initialization
    void Start ()
	{
	    _highlighted = Interactables[0];
	    _hlRenderer = _highlighted.GetComponent<SpriteRenderer>();
	    _hlRenderer.color = Color.yellow;

	    StartCoroutine(AnimateText());
    }
	
	// Update is called once per frame
	void Update () {
        /* Cycles left or right through the highlighted objects and displays the associated text */
	    if (Input.GetButtonDown("Left"))
	    {
	        _hlRenderer.color = Color.white;
	        _selected = (_selected == 0) ? Interactables.Length - 1 : _selected - 1;
            _highlighted = Interactables[_selected];
	        _hlRenderer = _highlighted.GetComponent<SpriteRenderer>();
	        _hlRenderer.color = Color.yellow;

	        StopAllCoroutines();
	        StartCoroutine(AnimateText());

	    }

	    else if (Input.GetButtonDown("Right"))
	    {
	        _hlRenderer.color = Color.white;
            _selected = (_selected == Interactables.Length - 1) ? 0 : _selected + 1;
	        _highlighted = Interactables[_selected];
	        _hlRenderer = _highlighted.GetComponent<SpriteRenderer>();
	        _hlRenderer.color = Color.yellow;

	        StopAllCoroutines();
	        StartCoroutine(AnimateText());
        }

	    if (Input.GetButtonDown("Submit"))
	    {
            SceneManager.LoadScene(_scenes[_selected]);
	    }
    }

    /* Coroutine that animates the text letter by letter */
    IEnumerator AnimateText()
    {
        for (var i = 0; i < _text[_selected].Length + 1; i++)
        {
            TextBox.text = _text[_selected].Substring(0, i);
            yield return new WaitForSeconds(.01f);
        }
    }
}
