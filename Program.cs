using System.Management;
using System.Net;
using System.Net.Sockets;

string[] Emojis = new string[] { "😃", "🚀", "🔍", "🛡️", "💻", "🌐", "🔒", "📡", "🕵️", "⚙️" };

DisplayBanner();
bool exit = false;
while (!exit)
{
    DisplayMenu();

    // Ask user to select an option
    string? input = Console.ReadLine()?.ToLower();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Invalid input. Please try again.");
        continue;
    }

    switch (input)
    {
        case "1":
            DisplaySystemInfo();
            break;
        case "2":
            DisplayNetworkInfo();
            break;
        case "3":
            await StartNetworkScan();
            break;
        case "4":
            SetPowerMode();
            break;
        case "q":
            Console.WriteLine("Exiting application. Goodbye!");
            exit = true;
            break;
        default:
            SetConsoleColor(ConsoleColor.DarkRed);
            Console.WriteLine("Invalid input. Please try again.");
            ResetConsoleColor();
            break;
    }

    if (!exit && (input != null && input != string.Empty))
    {
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey(true); // Wait for any key press to continue
    }
}

void DisplayBanner()
{
    Random random = new Random();
    string emoji = Emojis[random.Next(Emojis.Length)];
    Console.ForegroundColor = ConsoleColor.Cyan; // Change text color to Cyan
    Console.WriteLine($@"   .    '                   .  ""   '
                .  .  .                 '      '
        ""`       .   . 
                                         '     '
      .    '      _______________
              ==c(___(o(______(_() CyberScope 
                      \=\ 
                       )=\ 
                      //|\\ 
                     //|| \\ 
                    // ||  \\ 
                   //  ||   \\ 
                  //         \\                                                                  
     
      Developed by Zak1337
    ====================================================================================================
    ");
    Console.ResetColor(); // Reset to default color
}

void DisplayMenu()
{
    SetConsoleColor(ConsoleColor.Blue);
    Console.WriteLine("\n===== Menu =====");
    Console.WriteLine("1. Display System Information");
    Console.WriteLine("2. Display Network Information");
    Console.WriteLine("3. Start Network Scan");
    Console.WriteLine("4. Set Power Mode");
    Console.WriteLine("q. Quit");
    Console.WriteLine("================");
    Console.Write("Enter your choice: ");
    ResetConsoleColor();
}

void DisplaySystemInfo()
{
    SetConsoleColor(ConsoleColor.Blue);
    Console.WriteLine("System Information:");
    Console.WriteLine($"Operating System: {Environment.OSVersion}");
    Console.WriteLine($"Machine Name: {Environment.MachineName}");
    Console.WriteLine($"Processor Count: {Environment.ProcessorCount}");
    Console.WriteLine($"System Directory: {Environment.SystemDirectory}");
    Console.WriteLine($"User Domain Name: {Environment.UserDomainName}");
    Console.WriteLine($"User Name: {Environment.UserName}");
    Console.WriteLine($"64-bit OS: {Environment.Is64BitOperatingSystem}");
    Console.WriteLine($"64-bit Process: {Environment.Is64BitProcess}");
    Console.WriteLine($"System Page Size: {Environment.SystemPageSize}");
    Console.WriteLine($"Working Set: {Environment.WorkingSet}");

    // Additional hardware information using WMI
    Console.WriteLine("\nHardware Information:");
    if (OperatingSystem.IsWindows())
    {
        var searcher = new ManagementObjectSearcher("select * from Win32_Processor");
        foreach (var item in searcher.Get())
        {
            Console.WriteLine($"Processor: {item["Name"]}");
        }

        searcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
        foreach (var item in searcher.Get())
        {
            Console.WriteLine($"OS: {item["Caption"]} - {item["Version"]}");
        }

        searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
        foreach (var item in searcher.Get())
        {
            Console.WriteLine($"Manufacturer: {item["Manufacturer"]}");
            Console.WriteLine($"Model: {item["Model"]}");
            Console.WriteLine($"Total Physical Memory: {item["TotalPhysicalMemory"]}");
        }
    }
    else
    {
        Console.WriteLine("Hardware information is only available on Windows.");
    }
    ResetConsoleColor();
}

void DisplayNetworkInfo()
{
    SetConsoleColor(ConsoleColor.Blue);
    Console.WriteLine("Network Information:");
    Console.WriteLine($"Local IP Address: {GetLocalIPAddress()}");
    Console.WriteLine($"Public IP Address: {GetPublicIPAddressAsync().Result}");

    // Additional network information using WMI
    if (OperatingSystem.IsWindows())
    {
        var searcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration where IPEnabled = 'TRUE'");
        foreach (var item in searcher.Get())
        {
            Console.WriteLine($"Description: {item["Description"]}");
            Console.WriteLine($"MAC Address: {item["MACAddress"]}");
            Console.WriteLine($"IP Address: {string.Join(", ", item["IPAddress"] as string[] ?? Array.Empty<string>())}");
            Console.WriteLine($"Default IP Gateway: {string.Join(", ", item["DefaultIPGateway"] as string[] ?? Array.Empty<string>())}");
            Console.WriteLine($"DNS Servers: {string.Join(", ", item["DNSServerSearchOrder"] as string[] ?? Array.Empty<string>())}");
        }
    }
    else
    {
        Console.WriteLine("Network information is only available on Windows.");
    }
    ResetConsoleColor();
}

async Task StartNetworkScan()
{
    SetConsoleColor(ConsoleColor.Blue);
    // Display local IP address
    string localIP = GetLocalIPAddress();
    Console.WriteLine($"Local IP Address: {localIP}");

    // Ask user for scan type
    Console.Write("Do you want a (l)ong or (s)hort scan? ");
    string? scanType = Console.ReadLine()?.ToLowerInvariant();
    if (string.IsNullOrEmpty(scanType))
    {
        Console.WriteLine("Invalid input. Please try again.");
        ResetConsoleColor();
        return;
    }

    int[] ports;
    if (scanType == "l")
    {
        // Long scan: Scan more ports
        ports = new int[] { 21, 22, 23, 25, 53, 80, 110, 135, 139, 143, 443, 445, 993, 995, 1723, 3306, 3389, 5900, 8080 };
    }
    else
    {
        // Short scan: Scan fewer ports
        ports = new int[] { 21, 22, 23, 80, 443, 3389 };
    }

    // Start the scan
    Console.WriteLine("Starting scan...");
    ResetConsoleColor();
    await ScanPortsAsync(localIP, ports);
}

void SetPowerMode()
{
    SetConsoleColor(ConsoleColor.Blue);
    Console.WriteLine("Select Power Mode:");
    Console.WriteLine("1. Power Saver");
    Console.WriteLine("2. Balanced");
    Console.WriteLine("3. High Performance");
    Console.Write("Enter your choice: ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Invalid input. No changes made.");
        ResetConsoleColor();
        return;
    }

    switch (input)
    {
        case "1":
            SetPowerScheme("a1841308-3541-4fab-bc81-f71556f20b4a"); // Power Saver
            break;
        case "2":
            SetPowerScheme("381b4222-f694-41f0-9685-ff5bb260df2e"); // Balanced
            break;
        case "3":
            SetPowerScheme("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c"); // High Performance
            break;
        default:
            Console.WriteLine("Invalid input. No changes made.");
            break;
    }
    ResetConsoleColor();
}

void SetPowerScheme(string schemeGuid)
{
    var process = new System.Diagnostics.Process();
    process.StartInfo.FileName = "powercfg";
    process.StartInfo.Arguments = $"/s {schemeGuid}";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    process.WaitForExit();
    SetConsoleColor(ConsoleColor.DarkYellow);
    Console.WriteLine("Power mode changed successfully.");
    ResetConsoleColor();
}

// Method to get the local IP address
string GetLocalIPAddress()
{
    var host = Dns.GetHostEntry(Dns.GetHostName());
    foreach (var ip in host.AddressList)
    {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
            return ip.ToString();
        }
    }
    return "No local IP address found.";
}

// Asynchronous method to get the public IP address
async Task<string> GetPublicIPAddressAsync()
{
    try
    {
        using (HttpClient client = new HttpClient())
        {
            string ip = await client.GetStringAsync("https://api.ipify.org");
            return ip;
        }
    }
    catch (Exception ex)
    {
        return $"Error retrieving public IP: {ex.Message}";
    }
}

// Example of a simple port scan (asynchronous)
async Task ScanPortsAsync(string ipAddress, int[] ports)
{
    SetConsoleColor(ConsoleColor.DarkYellow);
    bool anyOpen = false;

    foreach (int port in ports)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                var connectTask = client.ConnectAsync(ipAddress, port);
                var delayTask = Task.Delay(10000);

                var completedTask = await Task.WhenAny(connectTask, delayTask);
                if (completedTask == connectTask)
                {
                    await connectTask;
                    if (client.Connected)
                    {
                        Console.WriteLine($"Port {port} is open.");
                        anyOpen = true;
                        client.Close();
                    }
                }
                else
                {
                    Console.WriteLine($"Port {port} scan timed out.");
                }
            }
        }
        catch
        {
            // Ignore closed ports
        }
    }

    if (!anyOpen)
    {
        Console.WriteLine("No open ports found.");
    }

    Console.WriteLine("Scan completed.");
    ResetConsoleColor();
}

void SetConsoleColor(ConsoleColor color)
{
    Console.ForegroundColor = color;
}

void ResetConsoleColor()
{
    Console.ResetColor();
}