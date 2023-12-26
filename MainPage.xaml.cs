namespace JogoAdicao
{
    public partial class MainPage : ContentPage
    {
        int score = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnZerar_Clicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Zerar", "Deseja zerar o placar?", "Sim", "Não");
            if (resposta)
            {
                score = 0;
                lbScore.Text = score.ToString();
            }
        }

        private async void BtnJogar_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int num1 = random.Next(0, 51);
            int num2 = random.Next(0, 51);
            int total = num1 + num2;

            string texto = await DisplayPromptAsync("Jogo de Adição", $"{num1} + {num2} = ?");
            try
            {
                                int resposta = Convert.ToInt32(texto);
                if (resposta == total)
                {
                    score++;
                    lbScore.Text = score.ToString();
                    await DisplayAlert("Jogo de Adição", "Resposta correta!", "OK");
                }
                else
                {
                    await DisplayAlert("Jogo de Adição", "Resposta incorreta!", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Jogo de Adição", "Resposta incorreta!", "OK");
            }
        }
    }

}
