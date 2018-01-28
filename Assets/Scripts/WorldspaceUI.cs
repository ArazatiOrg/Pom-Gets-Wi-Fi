using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldspaceUI : MonoBehaviour {
    public static WorldspaceUI instance;

    public Image MainMenu_Selected;
    public Text MainMenu_TitleText;

    public Image SaveLoad_Selected;
    public Text SaveLoad_TitleText;
    public Text SaveLoad_FileText;

    int selectedSlot = 0;

    UIState state = UIState.MainMenu;

    public int saveSlots = 15;
    public Global.SaveFile[] saveFiles;

    int validSaveFileCount = 0;

	void Start () {
        instance = this;

        LoadSaveSlotInfo();

        if (Global.loadedData)
        {
            validSaveFileCount = 1;
            state = UIState.None;
            Global.LoadVariables(0);
        }

        //main menu
        //TODO: support for other languages? Probably needed.
        MainMenu_TitleText.text = (validSaveFileCount > 0 ? "New Game\nLoad Game\nQuit Game" : "New Game\n<color=#FFFFFF7F>Load Game</color>\nQuit Game");
	}
	
	void Update () {
        switch (state)
        {
            default:
            case UIState.None:
                break;
            case UIState.MainMenu:
                {
                    var changeSelected = false;
                    if (InputController.JustPressed(Action.Up))
                    {
                        changeSelected = true;
                        selectedSlot--;

                        if (selectedSlot <= -1) selectedSlot = 2;
                    }
                    if (InputController.JustPressed(Action.Down))
                    {
                        changeSelected = true;
                        selectedSlot++;

                        if (selectedSlot >= 3) selectedSlot = 0;
                    }

                    if (InputController.JustPressed(Action.Confirm))
                    {
                        switch(selectedSlot)
                        {
                            case 0: //New Game
                                {
                                    AudioController.instance.PlaySFX((int)SFX.Choice, 1f);
                                    state = UIState.None;
                                    AudioController.instance.bgmSource.Stop();
                                    KeepCameraInBounds.instance.objectToFollow = Player.playerInstance.anim.gameObject;
                                    Player.playerInstance.AllowMovement = true;
                                } break;
                            case 1: //Load Game
                                {
                                    if(validSaveFileCount > 0)
                                    {
                                        AudioController.instance.PlaySFX((int)SFX.Choice, 1f);

                                        //TODO: temp, remove when I actually add the save/load screen properly
                                        {
                                            Global.LoadVariables(0);
                                            state = UIState.None;
                                            selectedSlot = 0;
                                            changeSelected = true;
                                        }


                                        if (false)
                                        {

                                            KeepCameraInBounds.instance.objectToFollow = SaveLoad_FileText.transform.parent.gameObject;
                                            state = UIState.SaveLoad;

                                            //reset the main menu select box
                                            selectedSlot = 0;
                                            changeSelected = true;
                                        }
                                    }
                                    else
                                    {
                                        AudioController.instance.PlaySFX((int)SFX.Buzzer, 1f);
                                    }
                                } break;
                            case 2: //Quit Game
                                {
                                    AudioController.instance.PlaySFX((int)SFX.Choice, 1f);
                                    Application.Quit();
                                } break;
                        }
                    }

                    if (changeSelected)
                    {
                        var selectedObjectOrigin = new Vector3(-0.6f, -44.1f);
                        MainMenu_Selected.transform.localPosition = selectedObjectOrigin += new Vector3(0f, -16f * selectedSlot);

                        AudioController.instance.PlaySFX((int)SFX.Cursor, 1f);
                    }
                } break;
            case UIState.SaveLoad:
                {

                } break;
            case UIState.Battle:
                {

                } break;
        }
    }

    public void LoadSaveSlotInfo()
    {
        saveFiles = new Global.SaveFile[saveSlots];
        validSaveFileCount = 0;

        for (int i = 0; i < saveSlots; i++)
        {
            saveFiles[i] = Global.SaveFile.Load(i, saveFiles[i]);

            if (saveFiles[i] != null) validSaveFileCount++;
        }
    }

    enum UIState
    {
        None,
        MainMenu,
        SaveLoad,
        Battle
    }
}
