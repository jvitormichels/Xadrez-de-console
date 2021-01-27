namespace tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteDeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            QteDeMovimentos = 0;
            Tab = tab;
        }

        public void IncrementarQteDeMovimentos()
        {
            QteDeMovimentos++;
        }
    }
}
