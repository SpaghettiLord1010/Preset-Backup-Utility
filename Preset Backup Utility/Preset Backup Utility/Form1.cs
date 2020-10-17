using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Preset_Backup_Utility
{
    public partial class form_main : Form
    {
        public form_main()
        {
            MessageBox.Show("Please run as Admin so that the program can correctly backup/load everything!", "Please runa as Admin!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            InitializeComponent();
            path_fl.Text = "C:\\Users\\" + Environment.UserName + "\\Documents\\Image-Line\\FL Studio\\Presets";
            path_xfer.Text = "C:\\Users\\" + Environment.UserName + "\\Documents\\Xfer\\";
            path_ni.Text = "C:\\Users\\" + Environment.UserName + "\\Documents\\Native Instruments\\";
            path_helm.Text = "C:\\Users\\" + Environment.UserName + "\\Documents\\Helm\\";
            path_falcon.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Falcon\\";
            path_uvistation.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\UVIWorkstation\\";
            path_izotope.Text = "C:\\Users\\" + Environment.UserName + "\\Documents\\iZotope\\";
            path_waves.Text = "C:\\Users\\Public\\Waves Audio\\";
        }

        private void cd_fl_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_fl.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_xfer_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_xfer.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_ni_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_ni.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_helm_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_helm.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_falcon_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_falcon.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_uvistation_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_uvistation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_izotope_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_izotope.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_waves_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_waves.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom1.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom2.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom3.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom4_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom4.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom5_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom5.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom6_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom6.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cd_custom7_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_custom7.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void config_save_Click(object sender, EventArgs e)
        {
            var nl = Environment.NewLine;
            string config_text = name_custom1.Text + nl + name_custom2.Text + nl + name_custom3.Text + nl + name_custom4.Text + nl + name_custom5.Text + nl + name_custom6.Text + nl + name_custom7.Text;
            string config_paths = path_fl.Text + nl + path_xfer.Text + nl + path_ni.Text + nl + path_helm.Text + nl + path_falcon.Text + nl + path_uvistation.Text + nl + path_izotope.Text + nl + path_waves.Text + nl + path_custom1.Text + nl + path_custom2.Text + nl + path_custom3.Text + nl + path_custom4.Text + nl + path_custom5.Text + nl + path_custom6.Text + nl + path_custom7.Text;
            string config_full = config_text + nl + config_paths;

            DialogResult result = config_save_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(config_save_dialog.FileName, config_full);
                MessageBox.Show("The configuration was saved successfully to: " + nl + config_save_dialog.FileName, "Save Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void config_load_Click(object sender, EventArgs e)
        {
            DialogResult result = config_load_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                Dictionary<TextBox, TextBox> name_array = new Dictionary<TextBox, TextBox>();
                name_array.Add(name_custom1, name_custom1);


                int counter = 1;
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(config_load_dialog.FileName);
                while ((line = file.ReadLine()) != null)
                {
                    //Messy 'cause I couldn't figure out how to adress the fields using the counter - don't judge me, it works.
                    if (counter <= 7)
                    {

                        if (counter == 1)
                        {
                            name_custom1.Text = line;
                        }
                        else if (counter == 2)
                        {
                            name_custom2.Text = line;
                        }
                        else if (counter == 3)
                        {
                            name_custom3.Text = line;
                        }
                        else if (counter == 4)
                        {
                            name_custom4.Text = line;
                        }
                        else if (counter == 5)
                        {
                            name_custom5.Text = line;
                        }
                        else if (counter == 6)
                        {
                            name_custom6.Text = line;
                        }
                        else if (counter == 7)
                        {
                            name_custom7.Text = line;
                        }


                        counter++;
                    }
                    else
                    {
                        if (counter == 8)
                        {
                            path_fl.Text = line;
                        }
                        else if (counter == 9)
                        {
                            path_xfer.Text = line;
                        }
                        else if (counter == 10)
                        {
                            path_ni.Text = line;
                        }
                        else if (counter == 11)
                        {
                            path_helm.Text = line;
                        }
                        else if (counter == 12)
                        {
                            path_falcon.Text = line;
                        }
                        else if (counter == 13)
                        {
                            path_uvistation.Text = line;
                        }
                        else if (counter == 14)
                        {
                            path_izotope.Text = line;
                        }
                        else if (counter == 15)
                        {
                            path_waves.Text = line;
                        }
                        else if (counter == 16)
                        {
                            path_custom1.Text = line;
                        }
                        else if (counter == 17)
                        {
                            path_custom2.Text = line;
                        }
                        else if (counter == 18)
                        {
                            path_custom3.Text = line;
                        }
                        else if (counter == 19)
                        {
                            path_custom4.Text = line;
                        }
                        else if (counter == 20)
                        {
                            path_custom5.Text = line;
                        }
                        else if (counter == 21)
                        {
                            path_custom6.Text = line;
                        }
                        else if (counter == 22)
                        {
                            path_custom7.Text = line;
                        }
                        counter++;
                    }

                }
                MessageBox.Show("The configuration was loaded successfully from: " + Environment.NewLine + config_load_dialog.FileName, "Load Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                file.Close();
            }

        }

        private void backup_create_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please note that this can vary in time! Expect this to take a while if you have many presets!" + Environment.NewLine + "Please also make sure that no previous backups are saved in the folder you make the backup!", "Upon clicking OK in the dialog, the program will start.");
            DialogResult result = backup_save_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\fl.zip") & Directory.Exists(path_fl.Text)) { ZipFile.CreateFromDirectory(path_fl.Text, backup_save_dialog.SelectedPath + "\\fl.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\xfer.zip") & Directory.Exists(path_xfer.Text)) { ZipFile.CreateFromDirectory(path_xfer.Text, backup_save_dialog.SelectedPath + "\\xfer.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\ni.zip") & Directory.Exists(path_ni.Text)) { ZipFile.CreateFromDirectory(path_ni.Text, backup_save_dialog.SelectedPath + "\\ni.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\helm.zip") & Directory.Exists(path_helm.Text)) { ZipFile.CreateFromDirectory(path_helm.Text, backup_save_dialog.SelectedPath + "\\helm.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\falcon.zip") & Directory.Exists(path_falcon.Text)) { ZipFile.CreateFromDirectory(path_falcon.Text, backup_save_dialog.SelectedPath + "\\falcon.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\uvistation.zip") & Directory.Exists(path_uvistation.Text)) { ZipFile.CreateFromDirectory(path_uvistation.Text, backup_save_dialog.SelectedPath + "\\uvistation.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\izotope.zip") & Directory.Exists(path_izotope.Text)) { ZipFile.CreateFromDirectory(path_izotope.Text, backup_save_dialog.SelectedPath + "\\izotope.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\waves.zip") & Directory.Exists(path_waves.Text)) { ZipFile.CreateFromDirectory(path_waves.Text, backup_save_dialog.SelectedPath + "\\waves.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom1.zip") & Directory.Exists(path_custom1.Text)) { ZipFile.CreateFromDirectory(path_custom1.Text, backup_save_dialog.SelectedPath + "\\custom1.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom2.zip") & Directory.Exists(path_custom2.Text)) { ZipFile.CreateFromDirectory(path_custom2.Text, backup_save_dialog.SelectedPath + "\\custom2.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom3.zip") & Directory.Exists(path_custom3.Text)) { ZipFile.CreateFromDirectory(path_custom3.Text, backup_save_dialog.SelectedPath + "\\custom3.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom4.zip") & Directory.Exists(path_custom4.Text)) { ZipFile.CreateFromDirectory(path_custom4.Text, backup_save_dialog.SelectedPath + "\\custom4.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom5.zip") & Directory.Exists(path_custom5.Text)) { ZipFile.CreateFromDirectory(path_custom5.Text, backup_save_dialog.SelectedPath + "\\custom5.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom6.zip") & Directory.Exists(path_custom6.Text)) { ZipFile.CreateFromDirectory(path_custom6.Text, backup_save_dialog.SelectedPath + "\\custom6.zip"); };
                if (!File.Exists(backup_save_dialog.SelectedPath + "\\custom7.zip") & Directory.Exists(path_custom7.Text)) { ZipFile.CreateFromDirectory(path_custom7.Text, backup_save_dialog.SelectedPath + "\\custom7.zip"); };
                //ZipFile.CreateFbackup_save_dialogp_save_dialog.SelectedPath, backup_save_dialog.SelectedPath + "\\backup_" + DateTime.Now.ToString() + ".pbu");
                MessageBox.Show("The backup was successfully created!", "Backup Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Backup Cancelled.", "Backup Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void backup_load_Click(object sender, EventArgs e)
        {
            DialogResult result = backup_load_dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (File.Exists(backup_load_dialog.SelectedPath + "\\fl.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\fl.zip", path_fl.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\xfer.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\xfer.zip", path_xfer.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\ni.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\ni.zip", path_ni.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\helm.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\helm.zip", path_helm.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\falcon.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\falcon.zip", path_falcon.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\uvistation.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\uvistation.zip", path_uvistation.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\izotope.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\izotope.zip", path_izotope.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\waves.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\waves.zip", path_waves.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom1.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom1.zip", path_custom1.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom2.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom2.zip", path_custom2.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom3.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom3.zip", path_custom3.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom4.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom4.zip", path_custom4.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom5.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom5.zip", path_custom5.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom6.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom6.zip", path_custom6.Text); };
                if (File.Exists(backup_load_dialog.SelectedPath + "\\custom7.zip")) { ZipFile.ExtractToDirectory(backup_load_dialog.SelectedPath + "\\custom7.zip", path_custom7.Text); };
                MessageBox.Show("All Backkups are extracted to the corresponding folders!", "Backups successfully loaded!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
