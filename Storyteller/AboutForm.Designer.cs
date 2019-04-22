namespace Storyteller
{
	partial class AboutForm
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
			this.pMain = new System.Windows.Forms.Panel();
			this.llDonate = new System.Windows.Forms.LinkLabel();
			this.lblMortens = new System.Windows.Forms.Label();
			this.llLink = new System.Windows.Forms.LinkLabel();
			this.gbCreatedBy = new System.Windows.Forms.GroupBox();
			this.pMain.SuspendLayout();
			this.gbCreatedBy.SuspendLayout();
			this.SuspendLayout();
			// 
			// pMain
			// 
			this.pMain.Controls.Add(this.gbCreatedBy);
			this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pMain.Location = new System.Drawing.Point(0, 0);
			this.pMain.Name = "pMain";
			this.pMain.Size = new System.Drawing.Size(303, 317);
			this.pMain.TabIndex = 0;
			// 
			// llDonate
			// 
			this.llDonate.AutoSize = true;
			this.llDonate.Location = new System.Drawing.Point(255, 291);
			this.llDonate.Name = "llDonate";
			this.llDonate.Size = new System.Drawing.Size(42, 13);
			this.llDonate.TabIndex = 3;
			this.llDonate.TabStop = true;
			this.llDonate.Text = "Donate";
			this.llDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlDonate_LinkClicked);
			// 
			// lblMortens
			// 
			this.lblMortens.AutoSize = true;
			this.lblMortens.Location = new System.Drawing.Point(12, 27);
			this.lblMortens.Name = "lblMortens";
			this.lblMortens.Size = new System.Drawing.Size(45, 13);
			this.lblMortens.TabIndex = 2;
			this.lblMortens.Text = "Mortens";
			// 
			// llLink
			// 
			this.llLink.AutoSize = true;
			this.llLink.Location = new System.Drawing.Point(3, 291);
			this.llLink.Name = "llLink";
			this.llLink.Size = new System.Drawing.Size(149, 13);
			this.llLink.TabIndex = 0;
			this.llLink.TabStop = true;
			this.llLink.Text = "http://w3.hdsnet.hu/mortens/";
			this.llLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlLink_LinkClicked);
			// 
			// gbCreatedBy
			// 
			this.gbCreatedBy.BackgroundImage = global::Storyteller.Properties.Resources.Logo;
			this.gbCreatedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.gbCreatedBy.Controls.Add(this.llDonate);
			this.gbCreatedBy.Controls.Add(this.lblMortens);
			this.gbCreatedBy.Controls.Add(this.llLink);
			this.gbCreatedBy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbCreatedBy.Location = new System.Drawing.Point(0, 0);
			this.gbCreatedBy.Name = "gbCreatedBy";
			this.gbCreatedBy.Size = new System.Drawing.Size(303, 317);
			this.gbCreatedBy.TabIndex = 1;
			this.gbCreatedBy.TabStop = false;
			this.gbCreatedBy.Text = "Created by";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(303, 317);
			this.Controls.Add(this.pMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.TopMost = true;
			this.pMain.ResumeLayout(false);
			this.gbCreatedBy.ResumeLayout(false);
			this.gbCreatedBy.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pMain;
		private System.Windows.Forms.LinkLabel llLink;
		private System.Windows.Forms.LinkLabel llDonate;
		private System.Windows.Forms.Label lblMortens;
		private System.Windows.Forms.GroupBox gbCreatedBy;
	}
}