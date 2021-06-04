using Cecs475.BoardGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.BoardGames.ComputerOpponent
{
	internal struct MinimaxBestMove
	{
		public long Weight { get; set; }
		public IGameMove Move { get; set; }
	}

	public class MinimaxAi : IGameAi
	{
		private int mMaxDepth;
		public MinimaxAi(int maxDepth)
		{
			mMaxDepth = maxDepth;
		}

		public IGameMove FindBestMove(IGameBoard b)
		{
			return FindBestMove(b, true ? long.MinValue : long.MaxValue, true ? long.MaxValue : long.MinValue, mMaxDepth).Move;
		}

		private static MinimaxBestMove FindBestMove(IGameBoard b, long alpha, long beta, int depthLeft)
		{


			if (depthLeft == 0 || b.IsFinished == true)
			{
				return new MinimaxBestMove()
				{
					Weight = b.BoardWeight,
					Move = null
				};
			}
			else
			{
				MinimaxBestMove move = new MinimaxBestMove();
				move.Move = null;
				if (b.CurrentPlayer == 1)
				{
					move.Weight = long.MinValue;
				}
				else if (b.CurrentPlayer == 2)
				{
					move.Weight = long.MaxValue;
				}

				foreach (var m in b.GetPossibleMoves())
				{
					b.ApplyMove(m);
					long w = FindBestMove(b, alpha, beta, depthLeft - 1).Weight;
					b.UndoLastMove();

					if ((b.CurrentPlayer == 1) && w > alpha)
					{
						move.Weight = w;
						move.Move = m;
						alpha = w;
					}

					else if ((b.CurrentPlayer == 2) && w < beta)
					{
						move.Weight = w;
						move.Move = m;
						beta = w;
					}

					if (!(alpha < beta))
					{
						return move;
					}

				}

				return move;
			}

		}


		//}// end of function 
	}//end of class
} // eof 
