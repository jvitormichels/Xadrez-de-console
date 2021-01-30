using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei (Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tab.QualPeca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] aux = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Cima
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Cima-direita
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.DefinirValores(Posicao.linha, Posicao.coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Baixo-direita
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Baixo
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Baixo-esquerda
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(Posicao.linha, Posicao.coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Cima-esquerda
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            return aux;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
