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
			LabelResX = new System.Windows.Forms.Label();
			LabelResY = new System.Windows.Forms.Label();
			LabelMousePosX = new System.Windows.Forms.Label();
			LabelMousePosY = new System.Windows.Forms.Label();
			ResX = new System.Windows.Forms.Label();
			ResY = new System.Windows.Forms.Label();
			MouseX = new System.Windows.Forms.Label();
			MouseY = new System.Windows.Forms.Label();
			LoadFileButton = new System.Windows.Forms.Button();
			SaveFileButton = new System.Windows.Forms.Button();
			ApplyButton = new System.Windows.Forms.Button();
			ParameterList = new System.Windows.Forms.RichTextBox();
			LabelWindowList = new System.Windows.Forms.Label();
			LabelFormat = new System.Windows.Forms.Label();
			LabelFormatList = new System.Windows.Forms.Label();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			ClearTextboxButton = new System.Windows.Forms.Button();
			LoadWindowsButton = new System.Windows.Forms.Button();
			StatusLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			TimeBetweenLaunchesms_Text = new System.Windows.Forms.TextBox();
			SuspendLayout();
			// 
			// LabelResX
			// 
			LabelResX.AutoSize = true;
			LabelResX.ForeColor = System.Drawing.Color.Yellow;
			LabelResX.Location = new System.Drawing.Point(13, 13);
			LabelResX.Name = "LabelResX";
			LabelResX.Size = new System.Drawing.Size(76, 15);
			LabelResX.TabIndex = 0;
			LabelResX.Text = "Resolution X:";
			// 
			// LabelResY
			// 
			LabelResY.AutoSize = true;
			LabelResY.ForeColor = System.Drawing.Color.Yellow;
			LabelResY.Location = new System.Drawing.Point(13, 31);
			LabelResY.Name = "LabelResY";
			LabelResY.Size = new System.Drawing.Size(76, 15);
			LabelResY.TabIndex = 1;
			LabelResY.Text = "Resolution Y:";
			// 
			// LabelMousePosX
			// 
			LabelMousePosX.AutoSize = true;
			LabelMousePosX.ForeColor = System.Drawing.Color.Yellow;
			LabelMousePosX.Location = new System.Drawing.Point(139, 12);
			LabelMousePosX.Name = "LabelMousePosX";
			LabelMousePosX.Size = new System.Drawing.Size(78, 15);
			LabelMousePosX.TabIndex = 2;
			LabelMousePosX.Text = "Mouse Pos X:";
			// 
			// LabelMousePosY
			// 
			LabelMousePosY.AutoSize = true;
			LabelMousePosY.ForeColor = System.Drawing.Color.Yellow;
			LabelMousePosY.Location = new System.Drawing.Point(139, 30);
			LabelMousePosY.Name = "LabelMousePosY";
			LabelMousePosY.Size = new System.Drawing.Size(78, 15);
			LabelMousePosY.TabIndex = 3;
			LabelMousePosY.Text = "Mouse Pos Y:";
			// 
			// ResX
			// 
			ResX.AutoSize = true;
			ResX.Font = new System.Drawing.Font("Segoe UI", 10F);
			ResX.ForeColor = System.Drawing.Color.LightSkyBlue;
			ResX.Location = new System.Drawing.Point(95, 11);
			ResX.Name = "ResX";
			ResX.Size = new System.Drawing.Size(17, 19);
			ResX.TabIndex = 4;
			ResX.Text = "0";
			// 
			// ResY
			// 
			ResY.AutoSize = true;
			ResY.Font = new System.Drawing.Font("Segoe UI", 10F);
			ResY.ForeColor = System.Drawing.Color.LightSkyBlue;
			ResY.Location = new System.Drawing.Point(95, 29);
			ResY.Name = "ResY";
			ResY.Size = new System.Drawing.Size(17, 19);
			ResY.TabIndex = 5;
			ResY.Text = "0";
			// 
			// MouseX
			// 
			MouseX.AutoSize = true;
			MouseX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			MouseX.Font = new System.Drawing.Font("Segoe UI", 10F);
			MouseX.ForeColor = System.Drawing.Color.LightSkyBlue;
			MouseX.Location = new System.Drawing.Point(222, 10);
			MouseX.Name = "MouseX";
			MouseX.Size = new System.Drawing.Size(17, 19);
			MouseX.TabIndex = 6;
			MouseX.Text = "0";
			// 
			// MouseY
			// 
			MouseY.AutoSize = true;
			MouseY.Font = new System.Drawing.Font("Segoe UI", 10F);
			MouseY.ForeColor = System.Drawing.Color.LightSkyBlue;
			MouseY.Location = new System.Drawing.Point(222, 28);
			MouseY.Name = "MouseY";
			MouseY.Size = new System.Drawing.Size(17, 19);
			MouseY.TabIndex = 7;
			MouseY.Text = "0";
			// 
			// LoadFileButton
			// 
			LoadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			LoadFileButton.ForeColor = System.Drawing.Color.Orange;
			LoadFileButton.Location = new System.Drawing.Point(807, 4);
			LoadFileButton.Name = "LoadFileButton";
			LoadFileButton.Size = new System.Drawing.Size(75, 23);
			LoadFileButton.TabIndex = 8;
			LoadFileButton.Text = "Load File";
			LoadFileButton.UseVisualStyleBackColor = true;
			LoadFileButton.Click += LoadFileButton_Click;
			// 
			// SaveFileButton
			// 
			SaveFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			SaveFileButton.ForeColor = System.Drawing.Color.Orange;
			SaveFileButton.Location = new System.Drawing.Point(726, 4);
			SaveFileButton.Name = "SaveFileButton";
			SaveFileButton.Size = new System.Drawing.Size(75, 23);
			SaveFileButton.TabIndex = 9;
			SaveFileButton.Text = "Save File";
			SaveFileButton.UseVisualStyleBackColor = true;
			SaveFileButton.Click += SaveButton_Click;
			// 
			// ApplyButton
			// 
			ApplyButton.BackColor = System.Drawing.SystemColors.Highlight;
			ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			ApplyButton.ForeColor = System.Drawing.SystemColors.Desktop;
			ApplyButton.Location = new System.Drawing.Point(764, 30);
			ApplyButton.Name = "ApplyButton";
			ApplyButton.Size = new System.Drawing.Size(53, 24);
			ApplyButton.TabIndex = 10;
			ApplyButton.Text = "Apply";
			ApplyButton.UseVisualStyleBackColor = false;
			ApplyButton.Click += ApplyButton_Click;
			// 
			// ParameterList
			// 
			ParameterList.BackColor = System.Drawing.Color.DarkBlue;
			ParameterList.DetectUrls = false;
			ParameterList.Font = new System.Drawing.Font("Consolas", 10F);
			ParameterList.ForeColor = System.Drawing.Color.White;
			ParameterList.ImeMode = System.Windows.Forms.ImeMode.Disable;
			ParameterList.Location = new System.Drawing.Point(13, 60);
			ParameterList.Name = "ParameterList";
			ParameterList.Size = new System.Drawing.Size(869, 516);
			ParameterList.TabIndex = 11;
			ParameterList.Text = "";
			ParameterList.WordWrap = false;
			// 
			// LabelWindowList
			// 
			LabelWindowList.AutoSize = true;
			LabelWindowList.Font = new System.Drawing.Font("Work Sans", 17.75F);
			LabelWindowList.ForeColor = System.Drawing.Color.Yellow;
			LabelWindowList.Location = new System.Drawing.Point(376, 5);
			LabelWindowList.Name = "LabelWindowList";
			LabelWindowList.Size = new System.Drawing.Size(157, 28);
			LabelWindowList.TabIndex = 12;
			LabelWindowList.Text = "Window List";
			// 
			// LabelFormat
			// 
			LabelFormat.AutoSize = true;
			LabelFormat.Font = new System.Drawing.Font("Arial", 9F);
			LabelFormat.ForeColor = System.Drawing.Color.LavenderBlush;
			LabelFormat.Location = new System.Drawing.Point(255, 42);
			LabelFormat.Name = "LabelFormat";
			LabelFormat.Size = new System.Drawing.Size(54, 15);
			LabelFormat.TabIndex = 13;
			LabelFormat.Text = "FORMAT";
			// 
			// LabelFormatList
			// 
			LabelFormatList.AutoSize = true;
			LabelFormatList.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			LabelFormatList.ForeColor = System.Drawing.Color.Yellow;
			LabelFormatList.Location = new System.Drawing.Point(315, 37);
			LabelFormatList.Name = "LabelFormatList";
			LabelFormatList.Size = new System.Drawing.Size(389, 17);
			LabelFormatList.TabIndex = 14;
			LabelFormatList.Text = "Window Title....X....Y....Width....Height....Process Name....Arguments";
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			openFileDialog1.Filter = "*.winposlist|";
			openFileDialog1.Title = "Open Window Position List File";
			// 
			// saveFileDialog1
			// 
			saveFileDialog1.CreatePrompt = true;
			saveFileDialog1.DefaultExt = "winposlist";
			saveFileDialog1.FileName = "default";
			saveFileDialog1.Filter = "*.winposlist|";
			saveFileDialog1.InitialDirectory = ".";
			saveFileDialog1.Title = "Save Configuration";
			// 
			// ClearTextboxButton
			// 
			ClearTextboxButton.BackColor = System.Drawing.SystemColors.Highlight;
			ClearTextboxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			ClearTextboxButton.ForeColor = System.Drawing.SystemColors.Desktop;
			ClearTextboxButton.Location = new System.Drawing.Point(823, 30);
			ClearTextboxButton.Name = "ClearTextboxButton";
			ClearTextboxButton.Size = new System.Drawing.Size(57, 24);
			ClearTextboxButton.TabIndex = 15;
			ClearTextboxButton.Text = "Clear";
			ClearTextboxButton.UseVisualStyleBackColor = false;
			ClearTextboxButton.Click += ClearTextboxButton_Click;
			// 
			// LoadWindowsButton
			// 
			LoadWindowsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			LoadWindowsButton.ForeColor = System.Drawing.Color.Orange;
			LoadWindowsButton.Location = new System.Drawing.Point(619, 4);
			LoadWindowsButton.Name = "LoadWindowsButton";
			LoadWindowsButton.Size = new System.Drawing.Size(101, 23);
			LoadWindowsButton.TabIndex = 16;
			LoadWindowsButton.Text = "Load Windows";
			LoadWindowsButton.UseVisualStyleBackColor = true;
			LoadWindowsButton.Click += LoadWindowsButton_Click;
			// 
			// StatusLabel
			// 
			StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			StatusLabel.AutoSize = true;
			StatusLabel.Font = new System.Drawing.Font("Work Sans", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			StatusLabel.ForeColor = System.Drawing.Color.Yellow;
			StatusLabel.Location = new System.Drawing.Point(389, 587);
			StatusLabel.Name = "StatusLabel";
			StatusLabel.Size = new System.Drawing.Size(162, 14);
			StatusLabel.TabIndex = 17;
			StatusLabel.Text = "Updated March 10th, 2024";
			StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Work Sans", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.Yellow;
			label1.Location = new System.Drawing.Point(13, 587);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(181, 14);
			label1.TabIndex = 18;
			label1.Text = "Time between Launches (ms):";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TimeBetweenLaunchesms_Text
			// 
			TimeBetweenLaunchesms_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
			TimeBetweenLaunchesms_Text.Location = new System.Drawing.Point(200, 583);
			TimeBetweenLaunchesms_Text.MaxLength = 255;
			TimeBetweenLaunchesms_Text.Name = "TimeBetweenLaunchesms_Text";
			TimeBetweenLaunchesms_Text.Size = new System.Drawing.Size(60, 16);
			TimeBetweenLaunchesms_Text.TabIndex = 19;
			TimeBetweenLaunchesms_Text.Text = "500";
			TimeBetweenLaunchesms_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			TimeBetweenLaunchesms_Text.WordWrap = false;
			// 
			// WindowPositions
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			BackColor = System.Drawing.Color.Black;
			ClientSize = new System.Drawing.Size(898, 606);
			Controls.Add(TimeBetweenLaunchesms_Text);
			Controls.Add(label1);
			Controls.Add(StatusLabel);
			Controls.Add(LoadWindowsButton);
			Controls.Add(ClearTextboxButton);
			Controls.Add(LabelFormatList);
			Controls.Add(LabelFormat);
			Controls.Add(LabelWindowList);
			Controls.Add(ParameterList);
			Controls.Add(ApplyButton);
			Controls.Add(SaveFileButton);
			Controls.Add(LoadFileButton);
			Controls.Add(MouseY);
			Controls.Add(MouseX);
			Controls.Add(ResY);
			Controls.Add(ResX);
			Controls.Add(LabelMousePosY);
			Controls.Add(LabelMousePosX);
			Controls.Add(LabelResY);
			Controls.Add(LabelResX);
			MaximumSize = new System.Drawing.Size(3840, 2158);
			MinimumSize = new System.Drawing.Size(914, 250);
			Name = "WindowPositions";
			SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			Text = "Window Positions Tool";
			ResizeEnd += WindowPositions_ResizeEnd;
			ResumeLayout(false);
			PerformLayout();
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
		private System.Windows.Forms.RichTextBox ParameterList;
		private System.Windows.Forms.Label LabelWindowList;
		private System.Windows.Forms.Label LabelFormat;
		private System.Windows.Forms.Label LabelFormatList;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button ClearTextboxButton;
		private System.Windows.Forms.Button LoadWindowsButton;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TimeBetweenLaunchesms_Text;
	}
}

