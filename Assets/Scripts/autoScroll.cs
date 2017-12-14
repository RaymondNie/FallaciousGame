using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required when Using UI elements.

public class autoScroll : MonoBehaviour {

	public ScrollRect myScrollRect;

	public void Update()
	{
		//Change the current vertical scroll position.
		myScrollRect.verticalNormalizedPosition = 0f;
	}
}
