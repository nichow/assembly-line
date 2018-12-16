using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject _lineObject; // the gameobject of the spawner
    private Vector3 _spawnPosition; // the position of that object

	// Use this for initialization
	void Start ()
	{
        // create dummy object for the assembly line object that is invisible and does not move
        // line object is reassigned to the dummy
        _lineObject = GameObject.FindGameObjectWithTag("lineObject");
	    _spawnPosition = _lineObject.transform.position;
	    var dummy = GameObject.Instantiate(_lineObject, _spawnPosition, Quaternion.identity);
	    dummy.GetComponent<SpriteRenderer>().enabled = false;
	    dummy.GetComponent<LineMovement>().enabled = false;
	    _lineObject = dummy;
	    StartCoroutine(SpawnTimer());
    }
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    // every second spawn a new moving visible line object
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            var dummy = GameObject.Instantiate(_lineObject, _spawnPosition, Quaternion.identity);
            dummy.GetComponent<SpriteRenderer>().enabled = true;
            dummy.GetComponent<LineMovement>().enabled = true;
        }
    }
}
