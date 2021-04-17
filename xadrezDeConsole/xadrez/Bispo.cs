using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(cor, tab)
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

            //Cima - Esquerda
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
                if ((Tab.QualPeca(pos) != null) && (Tab.QualPeca(pos).Cor != this.Cor))
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //Baixo - Direita
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
                if ((Tab.QualPeca(pos) != null) && (Tab.QualPeca(pos).Cor != this.Cor))
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //Cima - Direita
            pos.DefinirValores(Posicao.linha - 1, Posicao.coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
                if ((Tab.QualPeca(pos) != null) && (Tab.QualPeca(pos).Cor != this.Cor))
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //Baixo - Esquerda
            pos.DefinirValores(Posicao.linha + 1, Posicao.coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                aux[pos.linha, pos.coluna] = true;
                if ((Tab.QualPeca(pos) != null) && (Tab.QualPeca(pos).Cor != this.Cor))
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return aux;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
