using MySqlConnector;
using System;
using System.Drawing.Imaging;

namespace PhotoAlbum
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent(GetButtonShearch());
        }

        private string connectionString = "Server=localhost; Database=photo_album; Uid=root; Pwd=12345;";

        private void Clean()
        {
            tb_photoDescription.Text = "";
            tb_eventDescription.Text = "";
            tb_eventLocation.Text = "";
            pb_photo.Image = null;
            dtp_eventDate.Value = DateTime.Now;
        }
        /*--------------------------------BUTTTON SAVE -------------------------------------------------*/
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("The ID field is only for search, update and delete operations."
                    , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (pb_photo.Image == null)
            {
                MessageBox.Show("You must select a photo",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_photoDescription.Text.Length < 25 || tb_photoDescription.Text.Length > 100)
            {
                MessageBox.Show("The photo description field must have a minimum" +
                    " of 25 characters and a maximum of 100 characters."
                   , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_eventDescription.Text.Length < 25 || tb_eventDescription.Text.Length > 100)
            {
                MessageBox.Show("The event description field must have a minimum" +
                    " of 25 characters and a maximum of 100 characters."
                   , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(tb_eventLocation.Text))
            {
                MessageBox.Show("The event location field is empty."
                   , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Photo 
                MemoryStream ms = new MemoryStream();
                pb_photo.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo = ms.ToArray();

                //Event date
                DateTime event_date = dtp_eventDate.Value.Date;
                string date = event_date.ToString("yyyy-MM-dd");

                string photo_description = tb_photoDescription.Text;
                string event_description = tb_eventDescription.Text;
                string event_location = tb_eventLocation.Text;

                string query = "INSERT INTO photo_board (photo, photo_description, event_date, location" +
                    ", event_description) VALUES (@photo, @photo_description, @date, @event_location, @event_description)";

                try
                {
                    using (MySqlConnection connect = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand commande = new MySqlCommand(query, connect))
                        {
                            commande.Parameters.AddWithValue("@photo", photo);
                            commande.Parameters.AddWithValue("@photo_description", photo_description);
                            commande.Parameters.AddWithValue("@date", date);
                            commande.Parameters.AddWithValue("@event_location", event_location);
                            commande.Parameters.AddWithValue("@event_description", event_description);

                            connect.Open();
                            commande.ExecuteNonQuery();

                            MessageBox.Show("The event has been saved",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Clean();

                            connect.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*----------------------------------BUTON SELECT-----------------------------------------------------*/
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Phtos |*.jpg; *.png";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofd.Title = "Select photo";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb_photo.Image = Image.FromFile(ofd.FileName);
            }
        }
        /*----------------------------------BUTON SEARCH---------------------------------------------------*/
        private void buttonShearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("The ID field is empty", 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(tb_id.Text);
                MemoryStream ms = new MemoryStream();
                string photo_description = string.Empty;
                string event_description = string.Empty;
                string location = string.Empty;
                DateTime event_date;

                string query = "SELECT photo, photo_description, event_date, location, event_description " 
                    + "FROM photo_board WHERE id = @id";

                try
                {
                    using (MySqlConnection connect = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand commande = new MySqlCommand(query, connect))
                        {
                            commande.Parameters.AddWithValue("@id", id);

                            connect.Open();
                            using (MySqlDataReader reader = commande.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ms = new MemoryStream((byte[])reader["photo"]);
                                    photo_description = reader.GetString("photo_description");
                                    event_date = reader.GetDateTime("event_date");
                                    location = reader.GetString("location");
                                    event_description = reader.GetString("event_description");
                                }
                                else
                                {
                                    MessageBox.Show("No event was found with the ID entered",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Clean();
                                    return;
                                }
                            }
                        }
                    }

                    if(ms.Length > 0)
                    {
                        try
                        {
                            Bitmap bm = new Bitmap(ms);
                            pb_photo.Image = bm;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,
                                "photo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    tb_photoDescription.Text = photo_description;
                    tb_eventDescription.Text = event_description;
                    tb_eventLocation.Text = location;
                    dtp_eventDate.Value = event_date;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*-----------------------------------BUTTON UPDATE----------------------------------------------------*/
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("The ID field is empty",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pb_photo.Image == null)
            {
                MessageBox.Show("You must select a photo",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_photoDescription.Text.Length < 25 || tb_photoDescription.Text.Length > 100)
            {
                MessageBox.Show("The photo description field must have a minimum" +
                    " of 25 characters and a maximum of 100 characters."
                   , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tb_eventDescription.Text.Length < 25 || tb_eventDescription.Text.Length > 100)
            {
                MessageBox.Show("The event description field must have a minimum" +
                    " of 25 characters and a maximum of 100 characters."
                   , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(tb_eventLocation.Text))
            {
                MessageBox.Show("The event location field is empty."
                   , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(tb_id.Text);

                //Photo 
                MemoryStream ms = new MemoryStream();
                pb_photo.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo = ms.ToArray();

                //Event date
                DateTime event_date = dtp_eventDate.Value.Date;
                string date = event_date.ToString("yyyy-MM-dd");

                string photo_description = tb_photoDescription.Text;
                string event_description = tb_eventDescription.Text;
                string event_location = tb_eventLocation.Text;

                string query = "UPDATE photo_board SET photo = @photo, photo_description = @photo_description" +
                    ", event_date = @date, location = @location, event_description = @event_description" +
                    " WHERE id = @id";

                try
                {
                    using (MySqlConnection connet = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand commande = new MySqlCommand(query, connet))
                        {
                            commande.Parameters.AddWithValue("@id", id);
                            commande.Parameters.AddWithValue("@photo", photo);
                            commande.Parameters.AddWithValue("@photo_description", photo_description);
                            commande.Parameters.AddWithValue("@event_description", event_description);
                            commande.Parameters.AddWithValue("@date", date);
                            commande.Parameters.AddWithValue("@location", event_location);

                            connet.Open();

                            int rowsAffected = commande.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record updated successfully.",
                               "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clean();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("No record found with the specified ID.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "DB Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*----------------------------------BUTTON DELETE----------------------------------------------------*/
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_id.Text))
            {
                MessageBox.Show("The ID field is empty",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(tb_id.Text);
                string query = "DELETE FROM photo_board WHERE id = @id";
                
                try
                {
                    using (MySqlConnection connect = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand commande = new MySqlCommand(query, connect))
                        {
                            commande.Parameters.AddWithValue("@id", id);

                            connect.Open();
                            
                            int rowsAffected = commande.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.",
                               "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("No event was found with the ID entered",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*------------------------------------ ID KEYPRESS----------------------------------------------------*/
        private void tb_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                DialogResult dialogResult = MessageBox.Show("The ID field only accepts numbers", 
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
    }
}
