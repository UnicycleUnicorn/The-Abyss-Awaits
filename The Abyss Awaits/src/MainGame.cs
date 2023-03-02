using Microsoft.Xna.Framework.Graphics;
using The_Abyss_Awaits.util;
using Microsoft.Xna.Framework;
using The_Abyss_Awaits.input;

namespace The_Abyss_Awaits;

class MainGame : Game  {
    [STAThread]
    static void Main(string[] args) {
        Logger.Info("Program Started");
        // Attempt running the game, if fail, log the error
        try {
            using MainGame g = new MainGame();
            g.Run();
        } catch (Exception e) {
            Logger.Error(e.ToString());
        }
        //TODO Logger.ShowLog();
        Logger.Info("Program Ended");
    }

    /* Constructor */
    private MainGame() {
        new GraphicsDeviceManager(this);
        
        Content.RootDirectory = "../../Resources";
    }
    
    /* Game engine startup */
    protected override void Initialize() {
        IsMouseVisible = true;
        base.Initialize();
    }
    
    /* Load textures, sounds, and other assets */
    protected override void LoadContent() {
        // Create the batch...
        batch = new SpriteBatch(GraphicsDevice);

        // ... then load a texture from ./Content/FNATexture.png
        texture = Content.Load<Texture2D>("steve");
    }
    
    /* Clean up assets */
    protected override void UnloadContent() {
        batch.Dispose();
        texture.Dispose();
    }
    
    private SpriteBatch batch;
    private Texture2D texture;
    private Vector2 position = Vector2.Zero;
    
    /* Game loop */
    protected override void Update(GameTime gameTime) {
        // Update user input to get the user's keyboard, mouse, and controller inputs
        UserInput.Update();
        
        base.Update(gameTime);
    }
    
    /* Render loop */
    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // Draw the texture to the corner of the screen
        batch.Begin();
        batch.Draw(texture, position, Color.White);
        batch.End();
        
        base.Draw(gameTime);
    }
}