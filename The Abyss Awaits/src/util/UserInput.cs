using Microsoft.Xna.Framework;

namespace The_Abyss_Awaits.util; 

using Microsoft.Xna.Framework.Input;

public static class UserInput {
    
    private static KeyboardState _keyboardPrev;
    private static MouseState _mousePrev;
    private static GamePadState _gpPrev;
    
    public static void Update() {
        // Poll input
        KeyboardState keyboardCur = Keyboard.GetState();
        MouseState mouseCur = Mouse.GetState();
        GamePadState gpCur = GamePad.GetState(PlayerIndex.One);
        
        // Check for presses
        if (keyboardCur.IsKeyDown(Keys.Space) && _keyboardPrev.IsKeyUp(Keys.Space)) {
            Logger.Debug("Space bar was pressed!");
        }

        if (keyboardCur.IsKeyDown(Keys.F11) && _keyboardPrev.IsKeyUp(Keys.F11)) {
            Logger.Debug("F11 was pressed");
        }
        
        if (mouseCur.RightButton == ButtonState.Released && _mousePrev.RightButton == ButtonState.Pressed) {
            Logger.Debug("Right mouse button was released!");
        }
        
        if (gpCur.Buttons.A == ButtonState.Pressed && _gpPrev.Buttons.A == ButtonState.Pressed) {
            Logger.Debug("A button is being held!");
        }

        // Current is now previous!
        _keyboardPrev = keyboardCur;
        _mousePrev = mouseCur;
        _gpPrev = gpCur;
    }
}