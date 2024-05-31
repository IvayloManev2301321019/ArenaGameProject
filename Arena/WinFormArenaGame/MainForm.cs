using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            TextBox tbAttacker;
            if (args.Attacker is Knight)
                tbAttacker = tbKnight;
               
            else tbAttacker = tbAssassin;
            Random random = new Random();
            double ran = random.NextDouble();
            if (ran < 0.30)
            {
                tbAttacker.AppendText(
                $"{args.Attacker.Name} attacked {args.Defender.Name} with the special ability {args.Attacker.Weapon.SpecialAbility()} and caused {Math.Round(args.Damage, 2)} damage.\r\n");
            }
            tbAttacker.AppendText(
                $"{args.Attacker.Name} attacked {args.Defender.Name} and caused {Math.Round(args.Damage, 2)} damage.\r\n");

            DateTime dt = DateTime.Now;
            
            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbAssassin.Text = "";
            tbKnight.Text = "";
            lbWinner.Visible = false;

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Knight("Knight", 10, 20, new Sword("Sword")),
                HeroB = new Monk("Monk", 10, 10, new Dagger("Dagger")),
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"And the winner is:\n{gameEngine.Winner}";
            lbWinner.Visible = true;
        }

        private void lbWinner_Click(object sender, EventArgs e)
        {

        }
    }
}