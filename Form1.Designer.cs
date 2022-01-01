namespace SpaceLander
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Textures = new System.Windows.Forms.ImageList(this.components);
            this.Flags = new System.Windows.Forms.ImageList(this.components);
            this.Fires = new System.Windows.Forms.ImageList(this.components);
            this.TurboFire = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.SystemColors.Info;
            this.imageList1.Images.SetKeyName(0, "2020-10-24_17.47.10.png");
            // 
            // Textures
            // 
            this.Textures.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Textures.ImageStream")));
            this.Textures.TransparentColor = System.Drawing.Color.Transparent;
            this.Textures.Images.SetKeyName(0, "2020-10-24_20.08.48.png");
            // 
            // Flags
            // 
            this.Flags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Flags.ImageStream")));
            this.Flags.TransparentColor = System.Drawing.Color.Transparent;
            this.Flags.Images.SetKeyName(0, "2020-10-24_20.15.39.png");
            // 
            // Fires
            // 
            this.Fires.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Fires.ImageStream")));
            this.Fires.TransparentColor = System.Drawing.Color.WhiteSmoke;
            this.Fires.Images.SetKeyName(0, "fire.png");
            // 
            // TurboFire
            // 
            this.TurboFire.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TurboFire.ImageStream")));
            this.TurboFire.TransparentColor = System.Drawing.Color.Transparent;
            this.TurboFire.Images.SetKeyName(0, "Turbo.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(866, 508);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList Textures;
        private System.Windows.Forms.ImageList Flags;
        private System.Windows.Forms.ImageList Fires;
        private System.Windows.Forms.ImageList TurboFire;
    }
}

