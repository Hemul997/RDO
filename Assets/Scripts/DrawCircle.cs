using UnityEngine;
using System.Collections;
//using System.IO;

public class DrawCircle : MonoBehaviour {

    [SerializeField] private float _thetaScale = 0.05f;        	//Set lower to add more points
	[SerializeField] private float _radius = 5f;
    [SerializeField] private LineRenderer _lineRenderer;

    private float lineStartWidth = 0.1f;
    private float lineEndWidth = 0.1f;

	void Awake () {
		float sizeValue = (2.0f * Mathf.PI) / _thetaScale;
		var size = (int)sizeValue;
		size++;


        _lineRenderer.startWidth = lineStartWidth;
        _lineRenderer.endWidth = lineEndWidth;
        _lineRenderer.positionCount = size;

        Vector3 pos;
		float theta = 0.5f;

		for(int i = 0; i < size; i++){          
			theta += (2.0f * Mathf.PI * _thetaScale);
			float x = _radius * Mathf.Cos(theta);
			float y = _radius * Mathf.Sin(theta);
			x += gameObject.transform.position.x;
			y += gameObject.transform.position.y;

			pos = new Vector3(x, -1f, y);
			_lineRenderer.SetPosition(i, pos);
		}
	}
}
