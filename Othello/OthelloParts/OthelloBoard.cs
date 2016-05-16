using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Othello.OthelloParts.OthelloPiece;

namespace Othello.OthelloParts
{
    /// <summary>
    /// オセロボード
    /// </summary>
    public partial class OthelloBoard : UserControl
    {
        OthelloCell[,] _cellMatrix = new OthelloCell[8, 8];

        /// <summary>
        /// セルの位置の最大値
        /// </summary>
        private const int MAX_CELL_WIDTH = 7;

        /// <summary>
        /// セルの位置の最小値
        /// </summary>
        private const int MIN_CELL_WIDTH = 0;

        /// <summary>
        /// どちらの順番か？（黒 or 白）
        /// </summary>
        public PieceStatusKind Turn
        {
            get; set;
        }

        public event System.EventHandler CellClicked;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OthelloBoard()
        {
            InitializeComponent();
            InitCellMatrix();
            InitPosition();
        }

        #region 初期化処理
        /// <summary>
        /// セルのコレクションを初期化
        /// </summary>
        private void InitCellMatrix()
        {
            this._cellMatrix[0, 0] = this.othelloCell_11;
            this._cellMatrix[1, 0] = this.othelloCell_12;
            this._cellMatrix[2, 0] = this.othelloCell_13;
            this._cellMatrix[3, 0] = this.othelloCell_14;
            this._cellMatrix[4, 0] = this.othelloCell_15;
            this._cellMatrix[5, 0] = this.othelloCell_16;
            this._cellMatrix[6, 0] = this.othelloCell_17;
            this._cellMatrix[7, 0] = this.othelloCell_18;

            this._cellMatrix[0, 1] = this.othelloCell_21;
            this._cellMatrix[1, 1] = this.othelloCell_22;
            this._cellMatrix[2, 1] = this.othelloCell_23;
            this._cellMatrix[3, 1] = this.othelloCell_24;
            this._cellMatrix[4, 1] = this.othelloCell_25;
            this._cellMatrix[5, 1] = this.othelloCell_26;
            this._cellMatrix[6, 1] = this.othelloCell_27;
            this._cellMatrix[7, 1] = this.othelloCell_28;

            this._cellMatrix[0, 2] = this.othelloCell_31;
            this._cellMatrix[1, 2] = this.othelloCell_32;
            this._cellMatrix[2, 2] = this.othelloCell_33;
            this._cellMatrix[3, 2] = this.othelloCell_34;
            this._cellMatrix[4, 2] = this.othelloCell_35;
            this._cellMatrix[5, 2] = this.othelloCell_36;
            this._cellMatrix[6, 2] = this.othelloCell_37;
            this._cellMatrix[7, 2] = this.othelloCell_38;

            this._cellMatrix[0, 3] = this.othelloCell_41;
            this._cellMatrix[1, 3] = this.othelloCell_42;
            this._cellMatrix[2, 3] = this.othelloCell_43;
            this._cellMatrix[3, 3] = this.othelloCell_44;
            this._cellMatrix[4, 3] = this.othelloCell_45;
            this._cellMatrix[5, 3] = this.othelloCell_46;
            this._cellMatrix[6, 3] = this.othelloCell_47;
            this._cellMatrix[7, 3] = this.othelloCell_48;

            this._cellMatrix[0, 4] = this.othelloCell_51;
            this._cellMatrix[1, 4] = this.othelloCell_52;
            this._cellMatrix[2, 4] = this.othelloCell_53;
            this._cellMatrix[3, 4] = this.othelloCell_54;
            this._cellMatrix[4, 4] = this.othelloCell_55;
            this._cellMatrix[5, 4] = this.othelloCell_56;
            this._cellMatrix[6, 4] = this.othelloCell_57;
            this._cellMatrix[7, 4] = this.othelloCell_58;

            this._cellMatrix[0, 5] = this.othelloCell_61;
            this._cellMatrix[1, 5] = this.othelloCell_62;
            this._cellMatrix[2, 5] = this.othelloCell_63;
            this._cellMatrix[3, 5] = this.othelloCell_64;
            this._cellMatrix[4, 5] = this.othelloCell_65;
            this._cellMatrix[5, 5] = this.othelloCell_66;
            this._cellMatrix[6, 5] = this.othelloCell_67;
            this._cellMatrix[7, 5] = this.othelloCell_68;

            this._cellMatrix[0, 6] = this.othelloCell_71;
            this._cellMatrix[1, 6] = this.othelloCell_72;
            this._cellMatrix[2, 6] = this.othelloCell_73;
            this._cellMatrix[3, 6] = this.othelloCell_74;
            this._cellMatrix[4, 6] = this.othelloCell_75;
            this._cellMatrix[5, 6] = this.othelloCell_76;
            this._cellMatrix[6, 6] = this.othelloCell_77;
            this._cellMatrix[7, 6] = this.othelloCell_78;

            this._cellMatrix[0, 7] = this.othelloCell_81;
            this._cellMatrix[1, 7] = this.othelloCell_82;
            this._cellMatrix[2, 7] = this.othelloCell_83;
            this._cellMatrix[3, 7] = this.othelloCell_84;
            this._cellMatrix[4, 7] = this.othelloCell_85;
            this._cellMatrix[5, 7] = this.othelloCell_86;
            this._cellMatrix[6, 7] = this.othelloCell_87;
            this._cellMatrix[7, 7] = this.othelloCell_88;

            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    this._cellMatrix[j, i].Piece.PieceClicked += Piece_PieceClicked;
                    this._cellMatrix[j, i].Piece.CellIndex = new Point(j, i);
                }
            }
        }

        /// <summary>
        /// コマの初期位置
        /// </summary>
        private void InitPosition()
        {
            this._cellMatrix[3, 3].PieceStatus = PieceStatusKind.BLACK;
            this._cellMatrix[3, 4].PieceStatus = PieceStatusKind.WHITE;
            this._cellMatrix[4, 3].PieceStatus = PieceStatusKind.WHITE;
            this._cellMatrix[4, 4].PieceStatus = PieceStatusKind.BLACK;

        }
        #endregion

        /// <summary>
        /// 黒の数を返す
        /// </summary>
        /// <returns></returns>
        public int GetBlackNum()
        {
            int retval = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this._cellMatrix[j, i].Piece.PieceStatus == PieceStatusKind.BLACK)
                        retval++;
                }
            }

            return retval;
        }

        /// <summary>
        /// 白の数を返す
        /// </summary>
        /// <returns></returns>
        public int GetWhiteNum()
        {
            int retval = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this._cellMatrix[j, i].Piece.PieceStatus == PieceStatusKind.WHITE)
                        retval++;
                }
            }

            return retval;
        }

        /// <summary>
        /// セルクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Piece_PieceClicked(object sender, MouseEventArgs e)
        {
            OthelloPiece clickedPiece = sender as OthelloPiece;

            if (clickedPiece == null)
                return false;

            if (clickedPiece.PieceStatus != PieceStatusKind.NONE)
                return false;

            PieceStatusKind prevTurn = Turn == PieceStatusKind.BLACK ? PieceStatusKind.WHITE : PieceStatusKind.BLACK;

            clickedPiece.DrawColor = Turn;

            if (!IsFlippable(clickedPiece))
            {
                MessageBox.Show("そこには置けません");
                clickedPiece.DrawColor = prevTurn;
                return false;
            }

            FlipPiece(clickedPiece, false);
            TurnChange();

            CellClicked(sender, e);

            return true;
        }

        /// <summary>
        /// ターン変更
        /// </summary>
        private void TurnChange()
        {
            this.Turn = Turn == PieceStatusKind.WHITE ? PieceStatusKind.BLACK : PieceStatusKind.WHITE;
        }

        /// <summary>
        /// ひっくりかえせる箇所にコマが置かれたか？
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        private bool IsFlippable(OthelloPiece piece)
        {
            return FlipPiece(piece, true);
        }

        /// <summary>
        /// はさんだピースの反転
        /// </summary>
        /// <param name="flipDetect"></param>
        /// <param name="piece"></param>
        private bool FlipPiece(OthelloPiece piece, bool flipDetect)
        {
            int clickedCellX = piece.CellIndex.X;
            int clickedCellY = piece.CellIndex.Y;

            int i = 0;
            int j = 0;

            #region 左へ探索
            i = clickedCellX;
            while (true)
            {
                i--;

                if (i < MIN_CELL_WIDTH)
                    break;

                if (this._cellMatrix[i, clickedCellY].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[i, clickedCellY].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellX - i) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        for (int ii = clickedCellX; ii >= i; ii--)
                        {
                            this._cellMatrix[ii, clickedCellY].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            #region 左上に探索
            i = clickedCellX;
            j = clickedCellY;
            while (true)
            {
                i--;
                j--;

                if (i < MIN_CELL_WIDTH || j < MIN_CELL_WIDTH)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellX - i) <= 1 ||
                        Math.Abs(clickedCellY - j) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        int ii = 0;
                        int jj = 0;

                        for (ii = clickedCellX, jj = clickedCellY; ii >= i; ii--, jj--)
                        {
                            this._cellMatrix[ii, jj].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            #region 上に探索
            i = clickedCellY;
            while(true)
            {
                i--;

                if (i < MIN_CELL_WIDTH)
                    break;

                if (this._cellMatrix[clickedCellX, i].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[clickedCellX, i].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellY - i) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        for (int ii = clickedCellY; ii >= i; ii--)
                        {
                            this._cellMatrix[clickedCellX, ii].PieceStatus = piece.DrawColor;
                        }
                    }
                    break;
                }
            }
            #endregion

            #region 右上に探索
            i = clickedCellX;
            j = clickedCellY;
            while(true)
            {
                i++;
                j--;

                if (i > MAX_CELL_WIDTH || j < MIN_CELL_WIDTH)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellX - i) <= 1 ||
                        Math.Abs(clickedCellY - j) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        int ii = 0;
                        int jj = 0;

                        for (ii = clickedCellX, jj = clickedCellY; ii < i; ii++, jj--)
                        {
                            this._cellMatrix[ii, jj].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            #region 右に探索
            i = clickedCellX;
            while (true)
            {
                i++;

                if (i > MAX_CELL_WIDTH)
                    break;

                if (this._cellMatrix[i, clickedCellY].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[i, clickedCellY].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellX - i) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        int ii = 0;

                        for (ii = clickedCellX; ii < i; ii++)
                        {
                            this._cellMatrix[ii, clickedCellY].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            #region 右下に探索
            i = clickedCellX;
            j = clickedCellY;
            while (true)
            {
                i++;
                j++;

                if (i > MAX_CELL_WIDTH || j > MAX_CELL_WIDTH)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellX - i) <= 1 ||
                        Math.Abs(clickedCellY - j) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        int ii = 0;
                        int jj = 0;

                        for (ii = clickedCellX, jj = clickedCellY; ii < i; ii++, jj++)
                        {
                            this._cellMatrix[ii, jj].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            #region 下に探索
            i = clickedCellY;
            while (true)
            {
                i++;

                if (i > MAX_CELL_WIDTH)
                    break;

                if (this._cellMatrix[clickedCellX, i].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[clickedCellX, i].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellY - i) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        for (int ii = clickedCellY; ii < i; ii++)
                        {
                            this._cellMatrix[clickedCellX, ii].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            #region 左下に探索
            i = clickedCellX;
            j = clickedCellY;
            while (true)
            {
                i--;
                j++;

                if (i < MIN_CELL_WIDTH || j > MAX_CELL_WIDTH)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == PieceStatusKind.NONE)
                    break;

                if (this._cellMatrix[i, j].Piece.PieceStatus == piece.DrawColor)
                {
                    // １つ隣のセルに同じ色があった場合は置けな。
                    if (Math.Abs(clickedCellX - i) <= 1 ||
                        Math.Abs(clickedCellY - j) <= 1)
                        break;

                    if (flipDetect)
                    {
                        return true;
                    }
                    else
                    {
                        int ii = 0;
                        int jj = 0;

                        for (ii = clickedCellX, jj = clickedCellY; ii >= i; ii--, jj++)
                        {
                            this._cellMatrix[ii, jj].PieceStatus = piece.DrawColor;
                        }
                        break;
                    }
                }
            }
            #endregion

            return false;
        }
    }
}
