namespace DownloaderWinForm
{
    //"http://ipv4.download.thinkbroadband.com/10MB.zip" <- URL to download
    public class Downloader
    {
        public EventHandler DownloadCompleted;
        public EventHandler Timeout;
        public int PercentageComplete = 0;
        public Downloader() { }

        public async Task DownloadAsync(string uri, int timeout, IProgress<int> progress, string fileName)
        {

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Other");

            using (var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //Pour ne pas charger tout le fichier d'un coup dans la mémoire
                    var buffer = new byte[8192];
                    long totalRead = 0;
                    int bytesRead;

                    //Lecture par morceaux, tant que bytesRead est au dessus de 0 on continue de download
                    //Exemple, fichier 100 octet, on lit 20 octets à chaque itération
                    //1ère itération: bytesRead = 20, totalRead = 20
                    //6ème itération: bytesRead = 20, totalRead = 120 donc il reste 0 octets à lire -> on sort de la boucle

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);

                        var totalToDownlaod = response.Content.Headers.ContentLength.Value;

                        totalRead += bytesRead;

                        if (response.Content.Headers.ContentLength.HasValue)
                        {
                            PercentageComplete = (int)((totalRead * 100) / totalToDownlaod);

                            progress.Report(PercentageComplete);
                        }
                    };

                    DownloadCompleted?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
