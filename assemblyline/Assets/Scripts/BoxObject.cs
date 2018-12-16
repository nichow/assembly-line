using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoxObject : MonoBehaviour
{
    private Vector3 _initPosition; // v3 representation of the initial position of the lever (const z)
    private Vector3 _endPosition; // v3 representation of the end position of the lever (const z)
    private float _journeyLength; // the total distance between the init position and the end position
    private const float Speed = 35f; // the speed at which the lever operates
	
    public Sprite Box; // the sprite for the line object to change to when "boxed"

    public Text Score; // the text box for the score
    private int _scoreInt; // the integer representation of the score
    
	// Use this for initialization
	void Start ()
	{
	    _initPosition = transform.position;
	    _endPosition = new Vector3(transform.position.x, -0.6f, transform.position.z);
	    _journeyLength = Vector3.Distance(_initPosition, _endPosition);

	    _scoreInt = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetButtonDown("Box") && transform.position == _initPosition)
	    {
	        StartCoroutine(MoveLever(Time.time));
	    }
    }

    /* Upon trigger detection update sprite of the object collided with and increase score */
    void OnTriggerEnter2D(Collider2D other)
    {
	    var lineObjRenderer = other.gameObject.GetComponent<SpriteRenderer>();
	    // If the object's sprite has already been changed (that is, already been pressed) then return
	    if (lineObjRenderer.sprite == Box) return;
	    
	    lineObjRenderer.sprite = Box;
		
	    // Update score
	    _scoreInt++;
	    Score.text = _scoreInt.ToString();
    }

    /* Coroutine moves lever down to the top of the assembly line then back up */
    IEnumerator MoveLever(float startTime)
    {
        while (transform.position.y > _endPosition.y)
        {
            var distCovered = (Time.time - startTime) * Speed;
            var fracJourney = distCovered / _journeyLength;
            transform.position = Vector3.Lerp(_initPosition, _endPosition, fracJourney);
            yield return null;
        }

        startTime = Time.time;
        while (transform.position.y < _initPosition.y)
        {
            var distCovered = (Time.time - startTime) * Speed;
            var fracJourney = distCovered / _journeyLength;
            transform.position = Vector3.Lerp(_endPosition, _initPosition, fracJourney);
            yield return null;
        }
    }
}
