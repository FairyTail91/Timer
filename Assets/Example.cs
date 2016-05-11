using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float uselessVariable = 0;
	public float nextTime = 0f;
	public float timer = 0.5f;
	public int counter = 10;
	public int minHeight = 1;
	public int maxHeight = 10;
	public float horizontalSpacing = 1.1f;
	public float verticalSpacing = 1.1f;
	public float scaleSpacing = 0.05f;
	// Update is called once per frame
	void Update () {

		if (counter > 0 && Time.fixedTime > nextTime) {

			nextTime = Time.fixedTime + timer;
			for (int j = 10; j > 0; j--) {
				float shiftPosition = 0;
				int randomNumber = Random.Range (minHeight, maxHeight);
				for (int i = 0; i < randomNumber; i++) {
					CustomBox cBox = new CustomBox ();
					shiftPosition += i * scaleSpacing;
					cBox.box.transform.position = new Vector3 (counter * horizontalSpacing - 10f, 
						verticalSpacing * i - shiftPosition - 3f, horizontalSpacing * j);
					cBox.box.transform.localScale = (1 - i * scaleSpacing) * Vector3.one;
					cBox.pickRandomColor ();
				}
			}
			counter--;
		}
	}

	class CustomBox {
		public GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
		public void pickRandomColor ()
		{
			Vector4 color = new Vector4 ();
			color.x = Random.Range (0, 2);
			color.y = Random.Range (0, 2);
			color.z = Random.Range (0, 2);
			color.w = Random.Range (0, 2);
			Renderer rend = box.GetComponent<Renderer> ();
			rend.material.color = color;
		}
	}
}
