using UnityEngine;

public enum InputMapType 
{
    Gameplay,
    Pause,
    UI
}

[DefaultExecutionOrder(-60)]
public class InputHandler : MonoBehaviour
{
    // Singleton
    public static InputHandler Instance { get; private set; }

    // Input Action Asset
    public Controls Controls { get; private set; }
    public InputMapType CurrentInputMap => _currentInputMap;
    private InputMapType _currentInputMap = InputMapType.Gameplay;


    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        } else {
            Instance = this;
        }

        Controls = new Controls();
    }

    public void ChangeInputMap(InputMapType inputMapType) {
        switch (inputMapType) {
            case InputMapType.Gameplay:
                Controls.Gameplay.Enable();
                Controls.Pause.Disable();
                Controls.UI.Disable();
                break;
            case InputMapType.Pause:
                Controls.Gameplay.Disable();
                Controls.Pause.Enable();
                Controls.UI.Disable();
                break;
            case InputMapType.UI:
                Controls.Gameplay.Disable();
                Controls.Pause.Disable();
                Controls.UI.Enable();
                break;
        }

        _currentInputMap = inputMapType;
    }

    private void OnEnable() {
        if (Instance == this) {
            Controls.Enable();
            ChangeInputMap(_currentInputMap);
        }
    }

    private void OnDisable() {
        if (Instance == this) {
            Controls.Disable();
        }
    }
}
