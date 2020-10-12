namespace MarsRoverPhonos
{
    partial class MRP
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
            this.btClose = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btGetPhotos = new System.Windows.Forms.Button();
            this.imgLstNasa = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(674, 415);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(301, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btGetPhotos
            // 
            this.btGetPhotos.Enabled = false;
            this.btGetPhotos.Location = new System.Drawing.Point(301, 415);
            this.btGetPhotos.Name = "btGetPhotos";
            this.btGetPhotos.Size = new System.Drawing.Size(200, 23);
            this.btGetPhotos.TabIndex = 2;
            this.btGetPhotos.Text = "&Retriev Photos";
            this.btGetPhotos.UseVisualStyleBackColor = true;
            this.btGetPhotos.Click += new System.EventHandler(this.btGetPhotos_Click);
            // 
            // imgLstNasa
            // 
            this.imgLstNasa.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgLstNasa.ImageSize = new System.Drawing.Size(16, 16);
            this.imgLstNasa.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btGetPhotos);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btClose);
            this.Name = "MRP";
            this.Text = "Mars Rover Photos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btGetPhotos;
        private System.Windows.Forms.ImageList imgLstNasa;
    }
}

