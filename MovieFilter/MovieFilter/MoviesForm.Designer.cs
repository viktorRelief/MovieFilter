namespace MovieFilter
{
    partial class MoviesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewMovies = new System.Windows.Forms.DataGridView();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovies)).BeginInit();
            this.dataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMovies
            // 
            this.dataGridViewMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovies.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewMovies.Name = "dataGridViewMovies";
            this.dataGridViewMovies.ReadOnly = true;
            this.dataGridViewMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMovies.Size = new System.Drawing.Size(649, 376);
            this.dataGridViewMovies.TabIndex = 0;
            this.dataGridViewMovies.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMovies_CellMouseDoubleClick);
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.dataGridViewMovies);
            this.dataGroupBox.ForeColor = System.Drawing.Color.Green;
            this.dataGroupBox.Location = new System.Drawing.Point(12, 12);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(664, 401);
            this.dataGroupBox.TabIndex = 1;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "Double click on the row for getting more information";
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.ForeColor = System.Drawing.Color.Green;
            this.filtersGroupBox.Location = new System.Drawing.Point(682, 12);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(228, 354);
            this.filtersGroupBox.TabIndex = 2;
            this.filtersGroupBox.TabStop = false;
            this.filtersGroupBox.Text = "Filters";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filter_button_Click);
            // 
            // MoviesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filtersGroupBox);
            this.Controls.Add(this.dataGroupBox);
            this.Name = "MoviesForm";
            this.Text = "Movies";
            this.Load += new System.EventHandler(this.MoviesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovies)).EndInit();
            this.dataGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMovies;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.Button button1;
    }
}

