using Microsoft.Xna.Framework.Input;

namespace The_Abyss_Awaits.input.controller;

public class ControllerButton {
    public Buttons Button;
    public InputState InputState;

    public ControllerButton(Buttons button) {
        Button = button;
        InputState = InputState.None;
    }
}