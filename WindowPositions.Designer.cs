namespace WindowPosition {

	partial class WindowPositions {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing&&(components!=null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.LabelResX = new System.Windows.Forms.Label();
			this.LabelResY = new System.Windows.Forms.Label();
			this.LabelMousePosX = new System.Windows.Forms.Label();
			this.LabelMousePosY = new System.Windows.Forms.Label();
			this.ResX = new System.Windows.Forms.Label();
			this.ResY = new System.Windows.Forms.Label();
			this.MouseX = new System.Windows.Forms.Label();
			this.MouseY = new System.Windows.Forms.Label();
			this.LoadFileButton = new System.Windows.Forms.Button();
			this.SaveFileButton = new System.Windows.Forms.Button();
			this.ApplyButton = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.LabelWindowList = new System.Windows.Forms.Label();
			this.LabelFormat = new System.Windows.Forms.Label();
			this.LabelFormatList = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.ClearTextboxButton = new System.Windows.Forms.Button();
			this.loadWindowsButton = new System.Windows.Forms.Button();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LabelResX
			// 
			this.LabelResX.AutoSize = true;
			this.LabelResX.ForeColor = System.Drawing.Color.Yellow;
			this.LabelResX.Location = new System.Drawing.Point(13, 13);
			this.LabelResX.Name = "LabelResX";
			this.LabelResX.Size = new System.Drawing.Size(76, 15);
			this.LabelResX.TabIndex = 0;
			this.LabelResX.Text = "Resolution X:";
			// 
			// LabelResY
			// 
			this.LabelResY.AutoSize = true;
			this.LabelResY.ForeColor = System.Drawing.Color.Yellow;
			this.LabelResY.Location = new System.Drawing.Point(13, 31);
			this.LabelResY.Name = "LabelResY";
			this.LabelResY.Size = new System.Drawing.Size(76, 15);
			this.LabelResY.TabIndex = 1;
			this.LabelResY.Text = "Resolution Y:";
			// 
			// LabelMousePosX
			// 
			this.LabelMousePosX.AutoSize = true;
			this.LabelMousePosX.ForeColor = System.Drawing.Color.Yellow;
			this.LabelMousePosX.Location = new System.Drawing.Point(153, 13);
			this.LabelMousePosX.Name = "LabelMousePosX";
			this.LabelMousePosX.Size = new System.Drawing.Size(78, 15);
			this.LabelMousePosX.TabIndex = 2;
			this.LabelMousePosX.Text = "Mouse Pos X:";
			// 
			// LabelMousePosY
			// 
			this.LabelMousePosY.AutoSize = true;
			this.LabelMousePosY.ForeColor = System.Drawing.Color.Yellow;
			this.LabelMousePosY.Location = new System.Drawing.Point(153, 31);
			this.LabelMousePosY.Name = "LabelMousePosY";
			this.LabelMousePosY.Size = new System.Drawing.Size(78, 15);
			this.LabelMousePosY.TabIndex = 3;
			this.LabelMousePosY.Text = "Mouse Pos Y:";
			// 
			// ResX
			// 
			this.ResX.AutoSize = true;
			this.ResX.ForeColor = System.Drawing.Color.Yellow;
			this.ResX.Location = new System.Drawing.Point(96, 13);
			this.ResX.Name = "ResX";
			this.ResX.Size = new System.Drawing.Size(13, 15);
			this.ResX.TabIndex = 4;
			this.ResX.Text = "0";
			// 
			// ResY
			// 
			this.ResY.AutoSize = true;
			this.ResY.ForeColor = System.Drawing.Color.Yellow;
			this.ResY.Location = new System.Drawing.Point(96, 31);
			this.ResY.Name = "ResY";
			this.ResY.Size = new System.Drawing.Size(13, 15);
			this.ResY.TabIndex = 5;
			this.ResY.Text = "0";
			// 
			// MouseX
			// 
			this.MouseX.AutoSize = true;
			this.MouseX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MouseX.ForeColor = System.Drawing.Color.Yellow;
			this.MouseX.Location = new System.Drawing.Point(237, 13);
			this.MouseX.Name = "MouseX";
			this.MouseX.Size = new System.Drawing.Size(13, 15);
			this.MouseX.TabIndex = 6;
			this.MouseX.Text = "0";
			// 
			// MouseY
			// 
			this.MouseY.AutoSize = true;
			this.MouseY.ForeColor = System.Drawing.Color.Yellow;
			this.MouseY.Location = new System.Drawing.Point(237, 31);
			this.MouseY.Name = "MouseY";
			this.MouseY.Size = new System.Drawing.Size(13, 15);
			this.MouseY.TabIndex = 7;
			this.MouseY.Text = "0";
			// 
			// LoadFileButton
			// 
			this.LoadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoadFileButton.ForeColor = System.Drawing.Color.Orange;
			this.LoadFileButton.Location = new System.Drawing.Point(807, 4);
			this.LoadFileButton.Name = "LoadFileButton";
			this.LoadFileButton.Size = new System.Drawing.Size(75, 23);
			this.LoadFileButton.TabIndex = 8;
			this.LoadFileButton.Text = "Load File";
			this.LoadFileButton.UseVisualStyleBackColor = true;
			this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
			// 
			// SaveFileButton
			// 
			this.SaveFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveFileButton.ForeColor = System.Drawing.Color.Orange;
			this.SaveFileButton.Location = new System.Drawing.Point(726, 4);
			this.SaveFileButton.Name = "SaveFileButton";
			this.SaveFileButton.Size = new System.Drawing.Size(75, 23);
			this.SaveFileButton.TabIndex = 9;
			this.SaveFileButton.Text = "Save File";
			this.SaveFileButton.UseVisualStyleBackColor = true;
			this.SaveFileButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ApplyButton
			// 
			this.ApplyButton.BackColor = System.Drawing.SystemColors.Highlight;
			this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ApplyButton.ForeColor = System.Drawing.Color.Orange;
			this.ApplyButton.Location = new System.Drawing.Point(713, 31);
			this.ApplyButton.Name = "ApplyButton";
			this.ApplyButton.Size = new System.Drawing.Size(53, 23);
			this.ApplyButton.TabIndex = 10;
			this.ApplyButton.Text = "Apply";
			this.ApplyButton.UseVisualStyleBackColor = false;
			this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.DarkBlue;
			this.richTextBox1.DetectUrls = false;
			this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.richTextBox1.ForeColor = System.Drawing.Color.White;
			this.richTextBox1.Location = new System.Drawing.Point(13, 60);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(869, 516);
			this.richTextBox1.TabIndex = 11;
			this.richTextBox1.Text = "";
			// 
			// LabelWindowList
			// 
			this.LabelWindowList.AutoSize = true;
			this.LabelWindowList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.LabelWindowList.ForeColor = System.Drawing.Color.Yellow;
			this.LabelWindowList.Location = new System.Drawing.Point(389, 4);
			this.LabelWindowList.Name = "LabelWindowList";
			this.LabelWindowList.Size = new System.Drawing.Size(96, 21);
			this.LabelWindowList.TabIndex = 12;
			this.LabelWindowList.Text = "Window List";
			// 
			// LabelFormat
			// 
			this.LabelFormat.AutoSize = true;
			this.LabelFormat.ForeColor = System.Drawing.Color.Yellow;
			this.LabelFormat.Location = new System.Drawing.Point(267, 35);
			this.LabelFormat.Name = "LabelFormat";
			this.LabelFormat.Size = new System.Drawing.Size(53, 15);
			this.LabelFormat.TabIndex = 13;
			this.LabelFormat.Text = "FORMAT";
			// 
			// LabelFormatList
			// 
			this.LabelFormatList.AutoSize = true;
			this.LabelFormatList.ForeColor = System.Drawing.Color.Yellow;
			this.LabelFormatList.Location = new System.Drawing.Point(326, 35);
			this.LabelFormatList.Name = "LabelFormatList";
			this.LabelFormatList.Size = new System.Drawing.Size(364, 15);
			this.LabelFormatList.TabIndex = 14;
			this.LabelFormatList.Text = "Window Title....X....Y....Width....Height....Process Name....Arguments";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "*.winposlist|";
			this.openFileDialog1.Title = "Open Window Position List File";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.CreatePrompt = true;
			this.saveFileDialog1.DefaultExt = "winposlist";
			this.saveFileDialog1.FileName = "default";
			this.saveFileDialog1.Filter = "*.winposlist|";
			this.saveFileDialog1.InitialDirectory = ".";
			this.saveFileDialog1.Title = "Save Configuration";
			// 
			// ClearTextboxButton
			// 
			this.ClearTextboxButton.BackColor = System.Drawing.SystemColors.Highlight;
			this.ClearTextboxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ClearTextboxButton.ForeColor = System.Drawing.Color.Orange;
			this.ClearTextboxButton.Location = new System.Drawing.Point(772, 30);
			this.ClearTextboxButton.Name = "ClearTextboxButton";
			this.ClearTextboxButton.Size = new System.Drawing.Size(57, 24);
			this.ClearTextboxButton.TabIndex = 15;
			this.ClearTextboxButton.Text = "Clear";
			this.ClearTextboxButton.UseVisualStyleBackColor = false;
			this.ClearTextboxButton.Click += new System.EventHandler(this.ClearTextboxButton_Click);
			// 
			// loadWindowsButton
			// 
			this.loadWindowsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loadWindowsButton.ForeColor = System.Drawing.Color.Orange;
			this.loadWindowsButton.Location = new System.Drawing.Point(619, 4);
			this.loadWindowsButton.Name = "loadWindowsButton";
			this.loadWindowsButton.Size = new System.Drawing.Size(101, 23);
			this.loadWindowsButton.TabIndex = 16;
			this.loadWindowsButton.Text = "Load Windows";
			this.loadWindowsButton.UseVisualStyleBackColor = true;
			this.loadWindowsButton.Click += new System.EventHandler(this.LoadWindowsButton_Click_1);
			// 
			// StatusLabel
			// 
			this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.ForeColor = System.Drawing.Color.Yellow;
			this.StatusLabel.Location = new System.Drawing.Point(389, 579);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(137, 15);
			this.StatusLabel.TabIndex = 17;
			this.StatusLabel.Text = "Updated Sept. 19th, 2021";
			this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WindowPositions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(898, 600);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.loadWindowsButton);
			this.Controls.Add(this.ClearTextboxButton);
			this.Controls.Add(this.LabelFormatList);
			this.Controls.Add(this.LabelFormat);
			this.Controls.Add(this.LabelWindowList);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.ApplyButton);
			this.Controls.Add(this.SaveFileButton);
			this.Controls.Add(this.LoadFileButton);
			this.Controls.Add(this.MouseY);
			this.Controls.Add(this.MouseX);
			this.Controls.Add(this.ResY);
			this.Controls.Add(this.ResX);
			this.Controls.Add(this.LabelMousePosY);
			this.Controls.Add(this.LabelMousePosX);
			this.Controls.Add(this.LabelResY);
			this.Controls.Add(this.LabelResX);
			this.MaximumSize = new System.Drawing.Size(3840, 2158);
			this.MinimumSize = new System.Drawing.Size(914, 250);
			this.Name = "WindowPositions";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Window Positions Tool";
			this.ResizeEnd += new System.EventHandler(this.WindowPositions_ResizeEnd);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelResX;
		private System.Windows.Forms.Label LabelResY;
		private System.Windows.Forms.Label LabelMousePosX;
		private System.Windows.Forms.Label LabelMousePosY;
		private System.Windows.Forms.Label ResX;
		private System.Windows.Forms.Label ResY;
		private System.Windows.Forms.Label MouseX;
		private System.Windows.Forms.Label MouseY;
		private System.Windows.Forms.Button LoadFileButton;
		private System.Windows.Forms.Button SaveFileButton;
		private System.Windows.Forms.Button ApplyButton;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label LabelWindowList;
		private System.Windows.Forms.Label LabelFormat;
		private System.Windows.Forms.Label LabelFormatList;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button ClearTextboxButton;
		private System.Windows.Forms.Button loadWindowsButton;
		private System.Windows.Forms.Label StatusLabel;
	}
}

