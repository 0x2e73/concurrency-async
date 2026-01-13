// See https://aka.ms/new-console-template for more information
//Exo
// 2 méthode
// Download asynchrone 
// Méthode timout 
// Lancer les 2 méthodes en même temps 
// Regarder le résultat en fonction du temps de timout 
//lien: http://ipv4.download.thinkbroadband.com/10MB.zip

//TEST 1 Avec 10Ms 
//TEST 2 avec 300ms et ça renvoie le message
var downloadTask = DownloadAsync();
var timeoutTask = TimeoutAsync(1000);

var finishedTask = await Task.WhenAny(downloadTask, timeoutTask);

if (finishedTask == downloadTask)
    Console.WriteLine("Terminé");
else
    Console.WriteLine("Timeout dépassé");

async Task DownloadAsync()
{
    var url = "http://ipv4.download.thinkbroadband.com/10MB.zip";

    using var client = new HttpClient();
    client.DefaultRequestHeaders.Add("User-Agent", "Other");

    using var stream = await client.GetStreamAsync(url);
    using var fileStream = new FileStream("10MB.zip", FileMode.Create);

    await stream.CopyToAsync(fileStream);
}

async Task TimeoutAsync(int delay)
{
    await Task.Delay(delay);
    throw new TimeoutException("Too long !");
}