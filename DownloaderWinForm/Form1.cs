namespace DownloaderWinForm
{
    public partial class Form1 : Form
    {
        public string uri;
        public Form1()
        {
            InitializeComponent();
        }
        //Actually download the file, update the progress label and show a message box when done
        //TODO: Handle pause button, so, we need to save the bytes somewhere and the number of
        //bytes downloaded to be able to restart where we left
        private async void btn_download_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                MessageBox.Show("Veuillez entrer une URI valide.", "URI manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var downloader = new Downloader();

            downloader.DownloadCompleted += (s, ev) =>
            {
                if (InvokeRequired)
                {
                    BeginInvoke(() => MessageBox.Show("Téléchargement terminé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information));
                }
                else
                {
                    MessageBox.Show("Téléchargement terminé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            var progress = new Progress<int>(percent =>
            {
                lbl_title.Text = $"Téléchargement... {percent}%";
            });

            string fileName;
            try
            {
                var uriObj = new Uri(uri);
                var name = Path.GetFileName(uriObj.LocalPath);
                if (string.IsNullOrEmpty(name))
                    name = "download.dat";
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name);
            }
            catch
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "download.dat");
            }

            try
            {
                // Attendre la fin du téléchargement pour pouvoir gérer les erreurs et restaurer l'UI
                await downloader.DownloadAsync(uri, 2000, progress, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur durant le téléchargement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lbl_title.Text = "File Downloader";
            }
        }

        private void txtBox_uri_TextChanged(object sender, EventArgs e)
        {
            uri = txtBox_uri.Text;
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {

        }
    }
}
