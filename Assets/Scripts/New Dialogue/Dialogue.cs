using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
	public string name;

	[TextArea(3,10)]
	public string[] sentences;
	[TextArea(2,4)]
	public string[] options;
	[TextArea(3,10)]
	public string[] sentences0;
	[TextArea(2,4)]
	public string[] options0;
	[TextArea(3,10)]
	public string[] sentences1;
	[TextArea(2,4)]
	public string[] options1;
	[TextArea(3,10)]
	public string[] sentences2;
	[TextArea(2,4)]
	public string[] options2;

}
