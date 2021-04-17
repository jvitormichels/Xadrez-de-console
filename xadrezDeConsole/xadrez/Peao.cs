using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(cor, tab)
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

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.linha - 1, Posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    aux[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(Posicao.linha - 2, Posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteDeMovimentos==0)
                {
                    aux[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(Posicao.linha - 1, Posicao.coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    aux[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(Posicao.linha - 1, Posicao.coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    aux[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.linha + 1, Posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    aux[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(Posicao.linha + 2, Posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteDeMovimentos == 0)
                {
                    aux[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(Posicao.linha + 1, Posicao.coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    aux[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(Posicao.linha + 1, Posicao.coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    aux[pos.linha, pos.coluna] = true;
                }
            }

            return aux;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.QualPeca(pos);
            return (p != null && p.Cor != Cor);
        }

        private bool Livre(Posicao pos)
        {
            return Tab.QualPeca(pos) == null;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
