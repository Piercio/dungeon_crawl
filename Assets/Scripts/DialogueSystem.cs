using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem Instance { get; set; }

	public delegate void OnDialogueFinish();
	
	[SerializeField] GameObject dialoguePanel;
	[SerializeField] Button okButton;
	[SerializeField] Text dialogueText;

	int dialogueIndex;
	List<string> dialogueLines;
	OnDialogueFinish finishCallback;
    
    void Awake() {
    	if (Instance != null && Instance != this) {
    		Destroy(gameObject);
    	} else {
    		Instance = this;
    	}

        dialoguePanel.SetActive(false);
        okButton.onClick.AddListener(delegate { ContinueDialogue(); });
    }

    public void AddNewDialogue(List<string> lines, OnDialogueFinish callback) {
    	if (!dialoguePanel.activeSelf) {
	    	dialogueIndex = 0;
	    	dialogueLines = lines;
			finishCallback = callback;
	        CreateDialogue();
	    }
    }

    void CreateDialogue() {
    	dialogueText.text = dialogueLines[dialogueIndex];
    	dialoguePanel.SetActive(true);
    }

    void ContinueDialogue() {
    	dialogueIndex++;
    	if (dialogueIndex < dialogueLines.Count) {
    		dialogueText.text = dialogueLines[dialogueIndex];
    	} else {
    		CancelDialogue();
    		finishCallback();
    	}
    }

    public void CancelDialogue() {
    	dialoguePanel.SetActive(false);
    }
}
