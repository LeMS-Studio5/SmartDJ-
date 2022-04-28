
namespace SmartDJ__
{
    partial class Form1
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
            this.fbdMusic = new System.Windows.Forms.FolderBrowserDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.Score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCompare = new System.Windows.Forms.Button();
            this.ltvDetail = new System.Windows.Forms.ListView();
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.First_Song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Second_Song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Scored = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDetails = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnOpenFolders = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.sfdScores = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // fbdMusic
            // 
            this.fbdMusic.Description = "Choose which folder to scan";
            this.fbdMusic.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            this.fbdMusic.ShowNewFolderButton = false;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.Title,
            this.Album,
            this.Artist,
            this.Genre,
            this.Year});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(658, 444);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 0;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // Album
            // 
            this.Album.Text = "Album";
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // Genre
            // 
            this.Genre.Text = "Genre";
            // 
            // Year
            // 
            this.Year.Text = "Year";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Score,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(676, 50);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(506, 444);
            this.listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // Score
            // 
            this.Score.DisplayIndex = 5;
            this.Score.Text = "Score";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Album";
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "Artist";
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "Genre";
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "Year";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(666, 11);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 3;
            this.btnCompare.Text = "&Compare Songs";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // ltvDetail
            // 
            this.ltvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.type,
            this.First_Song,
            this.Second_Song,
            this.Scored});
            this.ltvDetail.FullRowSelect = true;
            this.ltvDetail.HideSelection = false;
            this.ltvDetail.Location = new System.Drawing.Point(1188, 50);
            this.ltvDetail.Name = "ltvDetail";
            this.ltvDetail.Size = new System.Drawing.Size(232, 444);
            this.ltvDetail.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ltvDetail.TabIndex = 5;
            this.ltvDetail.UseCompatibleStateImageBehavior = false;
            this.ltvDetail.View = System.Windows.Forms.View.Details;
            // 
            // type
            // 
            this.type.Text = "Tag";
            // 
            // First_Song
            // 
            this.First_Song.Text = "First Song";
            // 
            // Second_Song
            // 
            this.Second_Song.Text = "Second Song";
            // 
            // Scored
            // 
            this.Scored.Text = "Score";
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(1107, 16);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "&Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(1189, 21);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(77, 13);
            this.lblScore.TabIndex = 7;
            this.lblScore.Text = "Overall Score: ";
            // 
            // btnOpenFolders
            // 
            this.btnOpenFolders.Location = new System.Drawing.Point(12, 16);
            this.btnOpenFolders.Name = "btnOpenFolders";
            this.btnOpenFolders.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFolders.TabIndex = 9;
            this.btnOpenFolders.Text = "&Open Folder";
            this.btnOpenFolders.UseVisualStyleBackColor = true;
            this.btnOpenFolders.Click += new System.EventHandler(this.btnOpenFolders_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(93, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // sfdScores
            // 
            this.sfdScores.DefaultExt = "txt";
            this.sfdScores.Filter = "Text Files|*.txt";
            this.sfdScores.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 506);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOpenFolders);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.ltvDetail);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "SmartDJ++";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog fbdMusic;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Genre;
        private System.Windows.Forms.ColumnHeader Year;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView ltvDetail;
        private System.Windows.Forms.ColumnHeader First_Song;
        private System.Windows.Forms.ColumnHeader Second_Song;
        private System.Windows.Forms.ColumnHeader Scored;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnOpenFolders;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SaveFileDialog sfdScores;
    }
}

