using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(cor, tab)
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

            //Esquerda Cima
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Esquerda Baixo
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Direita Cima
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Direita Baixo
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Cima Direita
            pos.DefinirValores(Posicao.linha - 2, Posicao.coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Cima Esquerda
            pos.DefinirValores(Posicao.linha - 2, Posicao.coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Baixo Direita
            pos.DefinirValores(Posicao.linha + 2, Posicao.coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            //Baixo Esquerda
            pos.DefinirValores(Posicao.linha + 2, Posicao.coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
            }

            return aux;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
