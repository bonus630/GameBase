using br.com.bonus630.GameBase;

namespace GameBase
{
    public abstract class Game2D : GameObject2D
    {
        private Thread gameLoopThread;
        private Form gameForm;
        private bool running = false;
        private int sleepTime = 50;
        public Game2D(Form gameForm)
        {
            this.gameForm = gameForm;
            this.gameForm.FormBorderStyle = FormBorderStyle.None;
            this.gameForm.KeyPreview = true;
            this.gameForm.Controls.Clear();
            this.gameForm.KeyUp += GameForm_KeyUp;
            this.gameForm.KeyDown += GameForm_KeyDown;
            this.gameForm.Paint += GameForm_Paint;
            this.Bounds = this.Bounds = new Rectangle(0, 0, gameForm.Bounds.Width, gameForm.Bounds.Height);
        }

        private void GameForm_KeyDown(object? sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    Input.UP = true;
                    break;
                case Keys.Down:
                    Input.DOWN = true;
                    break;
                case Keys.Left:
                    Input.LEFT = true;
                    break;
                case Keys.Right:
                    Input.RIGHT = true;
                    break;
                case Keys.Space:
                    Input.SPACE = true;
                    break;
            }
        }

        private void GameForm_KeyUp(object? sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    this.End();
                    break;
                case Keys.Up:
                    Input.UP = false;
                    break;
                case Keys.Down:
                    Input.DOWN = false;
                    break;
                case Keys.Left:
                    Input.LEFT = false;
                    break;
                case Keys.Right:
                    Input.RIGHT = false;
                    break;
                case Keys.Space:
                    Input.SPACE = false;
                    break;
            }
        }

        private void GameForm_Paint(object? sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        public virtual void Start()
        {
            running = true;
            gameLoopThread = new Thread(new ThreadStart(GameLoop));
            gameLoopThread.IsBackground = true;
            gameLoopThread.Start();
        }
        public virtual void End()
        {
            gameForm.Dispose();
        }
        public virtual void GameLoop()
        {
            while (running)
            {
                gameForm.Invoke(() =>
                {
                    Update();
                });
                Thread.Sleep(sleepTime);
            }
        }
        public override void Update()
        {
            base.Update();
          
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            this.gameForm.Invalidate();
        }
        public abstract void Configure();
        public abstract void GameOver();

    }
}