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
    /// オセロのセル
    /// </summary>
    public partial class OthelloCell : UserControl
    {
        [Browsable(true)]
        public PieceStatusKind PieceStatus
        {
            set
            {
                this.othelloPiece.PieceStatus = value;
                Refresh();
            }
            get
            {
                return this.othelloPiece.PieceStatus;
            }
        }

        /// <summary>
        /// セルのサイズの指定
        /// </summary>
        public Size CellSize
        {
            set
            {
                this.Size = value;
                this.othelloPiece.PieceSize = new Rectangle(-1, 0, value.Width - 26, value.Height - 26);
            }
            get
            {
                return this.Size;
            }
        }

        /// <summary>
        /// コマのオブジェクトの取得
        /// </summary>
        public OthelloPiece Piece
        {
            get { return this.othelloPiece; }
            set { this.othelloPiece = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OthelloCell()
        {
            InitializeComponent();
        }
    }
}
