using The_Abyss_Awaits.util;

namespace The_Abyss_Awaits;

using System;
using Microsoft.Xna.Framework;

class FNAGame : Game  {
    [STAThread]
    static void Main(string[] args) {
        Logger.Info("Program Started");
        using (FNAGame g = new FNAGame()) {
            g.Run();
        }
        Logger.ShowLog();
        Logger.Info("Program Ended");
    }
    
    private FNAGame() {
        new GraphicsDeviceManager(this);
        
        Content.RootDirectory = "Resources";
    }

    protected override void Initialize() {
        /* This is a nice place to start up the engine, after
         * loading configuration stuff in the constructor
         */
        base.Initialize();
    }

    protected override void LoadContent() {
        // Load textures, sounds, and so on in here...
        base.LoadContent();
    }

    protected override void UnloadContent() {
        // Clean up after yourself!
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime) {
        // Update user input to get the user's keyboard, mouse, and controller inputs
        UserInput.Update();
        
        // Run game logic in here. Do NOT render anything here!
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        // Render stuff in here. Do NOT run game logic in here!
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // Draw texture to screen corner
        
        
        base.Draw(gameTime);
    }
}