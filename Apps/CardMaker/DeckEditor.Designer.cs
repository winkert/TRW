
namespace TRW.Apps.CardMaker
{
    partial class DeckEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckEditor));
            this.DeckListViewer = new System.Windows.Forms.ListView();
            this.DeckListViewTitleColumn = new System.Windows.Forms.ColumnHeader();
            this.DeckListValueColumn = new System.Windows.Forms.ColumnHeader();
            this.DeckListCountColumn = new System.Windows.Forms.ColumnHeader();
            this.CardDetailsGroup = new System.Windows.Forms.GroupBox();
            this.ChosenImagePictureBox = new System.Windows.Forms.PictureBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CardDetailsTools = new System.Windows.Forms.ToolStrip();
            this.NewCardButton = new System.Windows.Forms.ToolStripButton();
            this.EditSaveButton = new System.Windows.Forms.ToolStripButton();
            this.CancelEditButton = new System.Windows.Forms.ToolStripButton();
            this.CopyButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CardDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.CardValueTextbox = new System.Windows.Forms.TextBox();
            this.CardTitleTextbox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CardDetailsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenImagePictureBox)).BeginInit();
            this.CardDetailsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DeckListViewer
            // 
            this.DeckListViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeckListViewTitleColumn,
            this.DeckListValueColumn,
            this.DeckListCountColumn});
            this.DeckListViewer.FullRowSelect = true;
            this.DeckListViewer.GridLines = true;
            this.DeckListViewer.HideSelection = false;
            this.DeckListViewer.Location = new System.Drawing.Point(390, 0);
            this.DeckListViewer.MultiSelect = false;
            this.DeckListViewer.Name = "DeckListViewer";
            this.DeckListViewer.Size = new System.Drawing.Size(386, 393);
            this.DeckListViewer.TabIndex = 4;
            this.DeckListViewer.UseCompatibleStateImageBehavior = false;
            this.DeckListViewer.View = System.Windows.Forms.View.Details;
            this.DeckListViewer.SelectedIndexChanged += new System.EventHandler(this.DeckListViewer_SelectedIndexChanged);
            this.DeckListViewer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DeckListViewer_KeyUp);
            // 
            // DeckListViewTitleColumn
            // 
            this.DeckListViewTitleColumn.Text = "Title";
            // 
            // DeckListValueColumn
            // 
            this.DeckListValueColumn.Text = "Value";
            this.DeckListValueColumn.Width = 100;
            // 
            // DeckListCountColumn
            // 
            this.DeckListCountColumn.Text = "Count";
            // 
            // CardDetailsGroup
            // 
            this.CardDetailsGroup.Controls.Add(this.ChosenImagePictureBox);
            this.CardDetailsGroup.Controls.Add(this.SelectImageButton);
            this.CardDetailsGroup.Controls.Add(this.label4);
            this.CardDetailsGroup.Controls.Add(this.CardDetailsTools);
            this.CardDetailsGroup.Controls.Add(this.label3);
            this.CardDetailsGroup.Controls.Add(this.label2);
            this.CardDetailsGroup.Controls.Add(this.label1);
            this.CardDetailsGroup.Controls.Add(this.CardDescriptionTextbox);
            this.CardDetailsGroup.Controls.Add(this.CardValueTextbox);
            this.CardDetailsGroup.Controls.Add(this.CardTitleTextbox);
            this.CardDetailsGroup.Location = new System.Drawing.Point(0, 0);
            this.CardDetailsGroup.Name = "CardDetailsGroup";
            this.CardDetailsGroup.Size = new System.Drawing.Size(368, 393);
            this.CardDetailsGroup.TabIndex = 3;
            this.CardDetailsGroup.TabStop = false;
            this.CardDetailsGroup.Text = "Card Details";
            // 
            // ChosenImagePictureBox
            // 
            this.ChosenImagePictureBox.Location = new System.Drawing.Point(81, 179);
            this.ChosenImagePictureBox.Name = "ChosenImagePictureBox";
            this.ChosenImagePictureBox.Size = new System.Drawing.Size(200, 200);
            this.ChosenImagePictureBox.TabIndex = 14;
            this.ChosenImagePictureBox.TabStop = false;
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(54, 183);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(21, 19);
            this.SelectImageButton.TabIndex = 13;
            this.SelectImageButton.Text = "...";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Image";
            // 
            // CardDetailsTools
            // 
            this.CardDetailsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCardButton,
            this.EditSaveButton,
            this.CancelEditButton,
            this.CopyButton,
            this.DeleteButton});
            this.CardDetailsTools.Location = new System.Drawing.Point(3, 19);
            this.CardDetailsTools.Name = "CardDetailsTools";
            this.CardDetailsTools.Size = new System.Drawing.Size(362, 25);
            this.CardDetailsTools.TabIndex = 11;
            this.CardDetailsTools.Text = "Tools";
            // 
            // NewCardButton
            // 
            this.NewCardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewCardButton.Image = ((System.Drawing.Image)(resources.GetObject("NewCardButton.Image")));
            this.NewCardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewCardButton.Name = "NewCardButton";
            this.NewCardButton.Size = new System.Drawing.Size(23, 22);
            this.NewCardButton.Text = "New";
            // 
            // EditSaveButton
            // 
            this.EditSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("EditSaveButton.Image")));
            this.EditSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditSaveButton.Name = "EditSaveButton";
            this.EditSaveButton.Size = new System.Drawing.Size(23, 22);
            this.EditSaveButton.Text = "Edit";
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelEditButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelEditButton.Image")));
            this.CancelEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(23, 22);
            this.CancelEditButton.Text = "Cancel";
            // 
            // CopyButton
            // 
            this.CopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyButton.Image")));
            this.CopyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(23, 22);
            this.CopyButton.Text = "Copy";
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteButton.Text = "Delete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // CardDescriptionTextbox
            // 
            this.CardDescriptionTextbox.Location = new System.Drawing.Point(81, 105);
            this.CardDescriptionTextbox.MaxLength = 300;
            this.CardDescriptionTextbox.Multiline = true;
            this.CardDescriptionTextbox.Name = "CardDescriptionTextbox";
            this.CardDescriptionTextbox.Size = new System.Drawing.Size(281, 68);
            this.CardDescriptionTextbox.TabIndex = 2;
            // 
            // CardValueTextbox
            // 
            this.CardValueTextbox.Location = new System.Drawing.Point(81, 76);
            this.CardValueTextbox.MaxLength = 10;
            this.CardValueTextbox.Name = "CardValueTextbox";
            this.CardValueTextbox.Size = new System.Drawing.Size(281, 23);
            this.CardValueTextbox.TabIndex = 1;
            // 
            // CardTitleTextbox
            // 
            this.CardTitleTextbox.Location = new System.Drawing.Point(81, 47);
            this.CardTitleTextbox.MaxLength = 50;
            this.CardTitleTextbox.Name = "CardTitleTextbox";
            this.CardTitleTextbox.Size = new System.Drawing.Size(281, 23);
            this.CardTitleTextbox.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DeckEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeckListViewer);
            this.Controls.Add(this.CardDetailsGroup);
            this.Name = "DeckEditor";
            this.Size = new System.Drawing.Size(777, 395);
            this.CardDetailsGroup.ResumeLayout(false);
            this.CardDetailsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenImagePictureBox)).EndInit();
            this.CardDetailsTools.ResumeLayout(false);
            this.CardDetailsTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView DeckListViewer;
        private System.Windows.Forms.ColumnHeader DeckListViewTitleColumn;
        private System.Windows.Forms.ColumnHeader DeckListValueColumn;
        private System.Windows.Forms.ColumnHeader DeckListCountColumn;
        private System.Windows.Forms.GroupBox CardDetailsGroup;
        private System.Windows.Forms.PictureBox ChosenImagePictureBox;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip CardDetailsTools;
        private System.Windows.Forms.ToolStripButton NewCardButton;
        private System.Windows.Forms.ToolStripButton EditSaveButton;
        private System.Windows.Forms.ToolStripButton CancelEditButton;
        private System.Windows.Forms.ToolStripButton CopyButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CardDescriptionTextbox;
        private System.Windows.Forms.TextBox CardValueTextbox;
        private System.Windows.Forms.TextBox CardTitleTextbox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
