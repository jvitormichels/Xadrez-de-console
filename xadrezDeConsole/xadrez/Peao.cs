using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez _partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            _partida = partida;
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

                //#JogadaEspecial - En Passant
                if (Posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.QualPeca(esquerda) == _partida.VulneravelEnPassant)
                    {
                        aux[2, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.QualPeca(direita) == _partida.VulneravelEnPassant)
                    {
                        aux[2, direita.coluna] = true;
                    }
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

                //#JogadaEspecial - En Passant
                if (Posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.QualPeca(esquerda) == _partida.VulneravelEnPassant)
                    {
                        aux[5, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.QualPeca(direita) == _partida.VulneravelEnPassant)
                    {
                        aux[5, direita.coluna] = true;
                    }
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
