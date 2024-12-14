# CyberScope

![image](https://github.com/user-attachments/assets/4dde2ed2-0f6c-4efc-ac18-f2bcd77345dc)


```markdown
# CyberScope

CyberScope is a console application designed to retrieve various system and network information and perform different tasks. Developed to provide a simple yet powerful tool for system analysis and network monitoring.

## Features

### System Information:
- Displays operating system version, machine name, processor count, user information, and more.
- Detailed hardware information (on Windows), including processor details, operating system version, and memory capacity.

### Network Information:
- Displays local and public IP addresses.
- Detailed information about network adapters (on Windows), including MAC address, IP address, default gateway, and DNS servers.

### Network Scan:
- Performs a simple port scan on the local network with options for a short or long scan.

### Power Management:
- Changes the system's power scheme (on Windows) between power saver, balanced, and high-performance modes.

## Installation and Running the Application

### Prerequisites
- .NET SDK installed on your system.

### Steps

#### Clone the Repository:
Open your terminal or command prompt and run the following command:



#### Navigate to the Project Directory:

Change to the directory where the repository was cloned:
```bash
git clone https://github.com/zakmo1337/CyberScope.git
```
```bash
cd CyberScope
```

#### Build the Application:
Use the .NET CLI to build the application:

```bash
dotnet build
```

#### Run the Application:
After building the application, you can run it using:

```bash
dotnet run
```

### Publishing the Application
To create a standalone executable that can be run without the .NET SDK, you can publish the application:

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

This command will create a self-contained application in the `bin/Release/netX.0/win-x64/publish/` directory (replace `netX.0` with the specific .NET version).

## Known Issues/Limitations
- Some features are only available on Windows (e.g., WMI queries, power management).
- The port scan is a basic implementation and may not find all devices in more complex networks.
- The public IP address is retrieved via an external API, which might introduce latency.

## Future Enhancements
- Improve the port scan with different scan types (e.g., TCP, UDP).
- Add user customization options (e.g., configuration file for port lists).
- Support for more operating systems.

## Contact
For any questions or support, please contact the repository owner.
```

You can copy and paste this Markdown into your GitHub repository's README file directly.
