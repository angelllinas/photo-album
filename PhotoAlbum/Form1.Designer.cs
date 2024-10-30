namespace PhotoAlbum
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private Button GetButtonShearch()
        {
            return buttonShearch;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            pb_photo = new PictureBox();
            buttonSelect = new Button();
            buttonSave = new Button();
            tb_id = new TextBox();
            dtp_eventDate = new DateTimePicker();
            tb_photoDescription = new TextBox();
            tb_eventDescription = new TextBox();
            tb_eventLocation = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonShearch = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_photo).BeginInit();
            SuspendLayout();
            // 
            // pb_photo
            // 
            pb_photo.BackgroundImage = (Image)resources.GetObject("pb_photo.BackgroundImage");
            pb_photo.BorderStyle = BorderStyle.FixedSingle;
            pb_photo.InitialImage = null;
            pb_photo.Location = new Point(27, 114);
            pb_photo.Name = "pb_photo";
            pb_photo.Size = new Size(129, 134);
            pb_photo.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_photo.TabIndex = 0;
            pb_photo.TabStop = false;
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(43, 254);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(92, 23);
            buttonSelect.TabIndex = 1;
            buttonSelect.Text = "select photo";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(331, 297);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(109, 31);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "SAVE";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // tb_id
            // 
            tb_id.Location = new Point(142, 24);
            tb_id.Multiline = true;
            tb_id.Name = "tb_id";
            tb_id.Size = new Size(120, 26);
            tb_id.TabIndex = 3;
            tb_id.KeyPress += tb_id_KeyPress;
            // 
            // dtp_eventDate
            // 
            dtp_eventDate.Location = new Point(530, 178);
            dtp_eventDate.Name = "dtp_eventDate";
            dtp_eventDate.Size = new Size(181, 23);
            dtp_eventDate.TabIndex = 5;
            // 
            // tb_photoDescription
            // 
            tb_photoDescription.Location = new Point(182, 114);
            tb_photoDescription.Multiline = true;
            tb_photoDescription.Name = "tb_photoDescription";
            tb_photoDescription.Size = new Size(144, 134);
            tb_photoDescription.TabIndex = 6;
            // 
            // tb_eventDescription
            // 
            tb_eventDescription.Location = new Point(349, 114);
            tb_eventDescription.Multiline = true;
            tb_eventDescription.Name = "tb_eventDescription";
            tb_eventDescription.Size = new Size(144, 134);
            tb_eventDescription.TabIndex = 7;
            // 
            // tb_eventLocation
            // 
            tb_eventLocation.Location = new Point(530, 114);
            tb_eventLocation.Name = "tb_eventLocation";
            tb_eventLocation.Size = new Size(181, 23);
            tb_eventLocation.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 96);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 9;
            label2.Text = "Photo description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(349, 96);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 10;
            label3.Text = "Event description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(530, 96);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 11;
            label4.Text = "Event location";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(530, 160);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 12;
            label5.Text = "Event data";
            // 
            // buttonShearch
            // 
            buttonShearch.Location = new Point(284, 24);
            buttonShearch.Name = "buttonShearch";
            buttonShearch.Size = new Size(75, 26);
            buttonShearch.TabIndex = 13;
            buttonShearch.Text = "SEARCH";
            buttonShearch.UseVisualStyleBackColor = true;
            buttonShearch.Click += buttonShearch_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(365, 24);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 26);
            buttonUpdate.TabIndex = 14;
            buttonUpdate.Text = "UP DATE";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(446, 24);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 26);
            buttonDelete.TabIndex = 15;
            buttonDelete.Text = "DELETE";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(115, 30);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 4;
            label1.Text = "ID:";
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 379);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonShearch);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tb_eventLocation);
            Controls.Add(tb_eventDescription);
            Controls.Add(tb_photoDescription);
            Controls.Add(dtp_eventDate);
            Controls.Add(label1);
            Controls.Add(tb_id);
            Controls.Add(buttonSave);
            Controls.Add(buttonSelect);
            Controls.Add(pb_photo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pb_photo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_photo;
        private Button buttonSelect;
        private Button buttonSave;
        private TextBox tb_id;
        private DateTimePicker dtp_eventDate;
        private TextBox tb_photoDescription;
        private TextBox tb_eventDescription;
        private TextBox tb_eventLocation;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonShearch;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Label label1;
    }
}
