namespace Othello
{
    partial class OthelloForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Black = new System.Windows.Forms.Label();
            this.lbl_numBlack = new System.Windows.Forms.Label();
            this.lbl_numWhite = new System.Windows.Forms.Label();
            this.lbl_White = new System.Windows.Forms.Label();
            this.lbl_Turn = new System.Windows.Forms.Label();
            this.btn_Pass = new System.Windows.Forms.Button();
            this.othelloBoard = new Othello.OthelloParts.OthelloBoard();
            this.SuspendLayout();
            // 
            // lbl_Black
            // 
            this.lbl_Black.AutoSize = true;
            this.lbl_Black.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Black.Location = new System.Drawing.Point(538, 171);
            this.lbl_Black.Name = "lbl_Black";
            this.lbl_Black.Size = new System.Drawing.Size(45, 20);
            this.lbl_Black.TabIndex = 1;
            this.lbl_Black.Text = "黒 : ";
            // 
            // lbl_numBlack
            // 
            this.lbl_numBlack.AutoSize = true;
            this.lbl_numBlack.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_numBlack.Location = new System.Drawing.Point(590, 171);
            this.lbl_numBlack.Name = "lbl_numBlack";
            this.lbl_numBlack.Size = new System.Drawing.Size(19, 20);
            this.lbl_numBlack.TabIndex = 2;
            this.lbl_numBlack.Text = "0";
            // 
            // lbl_numWhite
            // 
            this.lbl_numWhite.AutoSize = true;
            this.lbl_numWhite.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_numWhite.Location = new System.Drawing.Point(590, 203);
            this.lbl_numWhite.Name = "lbl_numWhite";
            this.lbl_numWhite.Size = new System.Drawing.Size(19, 20);
            this.lbl_numWhite.TabIndex = 4;
            this.lbl_numWhite.Text = "0";
            // 
            // lbl_White
            // 
            this.lbl_White.AutoSize = true;
            this.lbl_White.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_White.Location = new System.Drawing.Point(538, 203);
            this.lbl_White.Name = "lbl_White";
            this.lbl_White.Size = new System.Drawing.Size(45, 20);
            this.lbl_White.TabIndex = 3;
            this.lbl_White.Text = "白 : ";
            // 
            // lbl_Turn
            // 
            this.lbl_Turn.AutoSize = true;
            this.lbl_Turn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Turn.Location = new System.Drawing.Point(523, 22);
            this.lbl_Turn.Name = "lbl_Turn";
            this.lbl_Turn.Size = new System.Drawing.Size(118, 24);
            this.lbl_Turn.TabIndex = 5;
            this.lbl_Turn.Text = "黒の番です";
            // 
            // btn_Pass
            // 
            this.btn_Pass.Location = new System.Drawing.Point(538, 67);
            this.btn_Pass.Name = "btn_Pass";
            this.btn_Pass.Size = new System.Drawing.Size(88, 45);
            this.btn_Pass.TabIndex = 6;
            this.btn_Pass.Text = "パス";
            this.btn_Pass.UseVisualStyleBackColor = true;
            // 
            // othelloBoard
            // 
            this.othelloBoard.Location = new System.Drawing.Point(12, 12);
            this.othelloBoard.Name = "othelloBoard";
            this.othelloBoard.Size = new System.Drawing.Size(487, 484);
            this.othelloBoard.TabIndex = 0;
            this.othelloBoard.Turn = Othello.OthelloParts.OthelloPiece.PieceStatusKind.NONE;
            // 
            // OthelloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 504);
            this.Controls.Add(this.btn_Pass);
            this.Controls.Add(this.lbl_Turn);
            this.Controls.Add(this.lbl_numWhite);
            this.Controls.Add(this.lbl_White);
            this.Controls.Add(this.lbl_numBlack);
            this.Controls.Add(this.lbl_Black);
            this.Controls.Add(this.othelloBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OthelloForm";
            this.Text = "オセロ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OthelloParts.OthelloBoard othelloBoard;
        private System.Windows.Forms.Label lbl_Black;
        private System.Windows.Forms.Label lbl_numBlack;
        private System.Windows.Forms.Label lbl_numWhite;
        private System.Windows.Forms.Label lbl_White;
        private System.Windows.Forms.Label lbl_Turn;
        private System.Windows.Forms.Button btn_Pass;
    }
}

