using Microsoft.Xna.Framework.Graphics;
using The_Abyss_Awaits.util;
using Microsoft.Xna.Framework;
using The_Abyss_Awaits.gameobjects;
using The_Abyss_Awaits.input;

namespace The_Abyss_Awaits;

public class MainGame : Game  {
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
        _graphics = new GraphicsDeviceManager(this);
        
        // Set the height and width
        _graphics.PreferredBackBufferWidth = 1080;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        Content.RootDirectory = "../../Resources";
        IsMouseVisible = true;
        
        _player = new Player(this, new Vector2(0.0f, 0.0f));
    }
    
    /* Game engine startup */
    protected override void Initialize() {
        base.Initialize();
    }
    
    /* Load textures, sounds, and other assets */
    protected override void LoadContent() {
        // Create the batch...
        _batch = new SpriteBatch(GraphicsDevice);
        
        _player.LoadContent();
    }
    
    /* Clean up assets */
    protected override void UnloadContent() {
        _batch.Dispose();
    }
    
    private SpriteBatch _batch;
    private Player _player;
    private GraphicsDeviceManager _graphics;
    
    /* Game loop */
    protected override void Update(GameTime gameTime) {
        // Update user input to get the user's keyboard, mouse, and controller inputs
        UserInput.Update();
        
        base.Update(gameTime);
        _player.Update(gameTime);
    }
    
    /* Render loop */
    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // Draw
        _batch.Begin();
        
        _player.Draw(gameTime, _batch);
        
        base.Draw(gameTime);
        _batch.End();
    }
}