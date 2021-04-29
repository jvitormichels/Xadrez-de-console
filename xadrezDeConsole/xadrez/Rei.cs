using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez _partida;

        public Rei (Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            _partida = partida;
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tab.QualPeca(pos);
            return p == null || p.Cor != this.Cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.QualPeca(pos);
            return p != null && p is Torre && p.Cor == this.Cor && p.QteDeMovimentos == 0;
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


            
            if (QteDeMovimentos == 0 && !_partida.Xeque)
            {
                //#JogadaEspecial - Roque pequeno
                Posicao posTorre1 = new Posicao(this.Posicao.linha, this.Posicao.coluna + 3);
                if (TesteTorreParaRoque(posTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna + 2);
                    if (Tab.QualPeca(p1) == null && Tab.QualPeca(p2) == null)
                    {
                        aux[Posicao.linha, Posicao.coluna + 2] = true;
                    }                    
                }

                //#JogadaEspecial - Roque grande
                Posicao posTorre2 = new Posicao(this.Posicao.linha, this.Posicao.coluna - 4);
                if (TesteTorreParaRoque(posTorre2))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna - 2);
                    Posicao p3 = new Posicao(Posicao.linha, Posicao.coluna - 3);
                    if (Tab.QualPeca(p1) == null && Tab.QualPeca(p2) == null && Tab.QualPeca(p3) == null)
                    {
                        aux[Posicao.linha, Posicao.coluna - 2] = true;
                    }
                }
            }

            return aux;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
