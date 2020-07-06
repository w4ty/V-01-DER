using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text.RegularExpressions;

public class DialogueParser : MonoBehaviour
{
	public DialogueManager dialogueManager;
	struct DialogueLine
	{
		public string name;
		public string content;
		public int pose;
		public string position;
		public int skip;
		public string[] options;
		public int evidenceAdd;
		public int eventNext;

		public DialogueLine(string Name, string Content, int Pose, string Position, int Skip, int EviAdd, int EventNext)
		{
			name = Name;
			content = Content;
			pose = Pose;
			position = Position;
			skip = Skip;
			options = new string[0];
			evidenceAdd = EviAdd;
			eventNext = EventNext;
		}
	}
	List<DialogueLine> lines;
	/*void Start()
	{
		LoadFile();
	}*/

	public void LoadFile(string fileLocation, int lineBegin)
	{
		string file = fileLocation;
		//string sceneNum = SceneManager.GetActiveScene().name;
		//sceneNum = Regex.Replace(sceneNum, "[^0-9]", "");
		//file += sceneNum;
		Debug.Log(file);

		lines = new List<DialogueLine>();

		LoadDialogue(file, lineBegin);
		dialogueManager.ShowDialogue(lineBegin);
	}

	void LoadDialogue(string filename, int lineBegin)
	{
		string line;
		StreamReader r = new StreamReader(filename);

		using (r)
		{
			do
			{
				line = r.ReadLine();
				if (line != null)
				{
					Debug.Log(line);
					string[] lineData = line.Split(';');
					if (lineData[0] == "Player")
					{
						DialogueLine lineEntry = new DialogueLine(lineData[0], "", 0, "", 0, -1, -1);
						lineEntry.options = new string[lineData.Length - 1];
						for (int i = 1; i < lineData.Length; i++)
						{
							lineEntry.options[i - 1] = lineData[i];
						}
						lines.Add(lineEntry);
					}
					else
					{
						DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]), lineData[3], int.Parse(lineData[4]), int.Parse(lineData[5]), int.Parse(lineData[6]));
						lines.Add(lineEntry);
						Debug.Log(lineData[6]);
					}
				}
			}
			while (line != null);
			r.Close();
		}
		dialogueManager.ShowDialogue(lineBegin);
	}

	public string GetPosition(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			return lines[lineNumber].position;
		}
		return "";
	}
	public string GetName(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			Debug.Log(lines[lineNumber].name);
			return lines[lineNumber].name;
		}
		return "";
	}
	public string GetContent(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			return lines[lineNumber].content;
		}
		return "";
	}
	public int GetPose(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			return lines[lineNumber].pose;
		}
		return 0;
	}
	public string[] GetOptions(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			return lines[lineNumber].options;
		}
		return new string[0];
	}
	public int GetSkip(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			return lines[lineNumber].skip;
		}
		return 0;
	}
	public int GetEvidence(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			return lines[lineNumber].evidenceAdd;
		}
		return 0;
	}

	public int GetNextEvent(int lineNumber)
	{
		if (lineNumber < lines.Count)
		{
			Debug.Log(lines[lineNumber].eventNext);
			return lines[lineNumber].eventNext;
		}
		return 0;
	}
}
