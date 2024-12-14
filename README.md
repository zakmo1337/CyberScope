# CyberScope

![image](https://github.com/user-attachments/assets/4dde2ed2-0f6c-4efc-ac18-f2bcd77345dc)


**CyberScope** is a console application designed to retrieve various system and network information and perform different tasks. It was developed to provide a simple yet powerful tool for system analysis and network monitoring.

## Features

### System Information:
- Displays **operating system version**, **machine name**, **processor count**, **user information**, and more.
- Detailed hardware information (on **Windows**), including **processor details**, **operating system version**, and **memory capacity**.

### Network Information:
- Displays **local and public IP addresses**.
- Detailed information about network adapters (on **Windows**), including **MAC address**, **IP address**, **default gateway**, and **DNS servers**.

### Network Scan:
- Performs a simple **port scan** on the local network with options for a short or long scan.

### Power Management:
- Changes the system's **power scheme** (on **Windows**) between **power saver**, **balanced**, and **high-performance modes**.

## Installation and Running the Application

### Prerequisites
- .NET SDK must be installed on your system.

### Steps

#### Clone the Repository:

1.Open your terminal or command prompt and run the following command:
````bash
git clone https://github.com/zakmo1337/CyberScope.git
````
2.Navigate to the Project Directory:
Change to the directory where the repository was cloned:
```bash
cd CyberScope
```
3.Build the Application:
Use the .NET CLI to build the application:
```bash
dotnet build
```

4.Run the Application:
After building the application, you can run it using:
```bash
dotnet run
```
(5.Publishing the Application):
To create a standalone executable that can be run without the .NET SDK, you can publish the application:
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

This command will create a self-contained application in the bin/Release/netX.0/win-x64/publish/ directory (replace netX.0 with the specific .NET version).
# Install .NET SDK 8.0 on (Kali) Linux

Follow these steps to install the .NET SDK 8.0 on Kali Linux.

## Step 1: Remove old .NET SDK versions (optional)
If you want to remove the existing .NET 6.0 version (optional), run the following command:
```bash
sudo apt remove dotnet-sdk-6.0
````
Step 2: Add Microsoft package repository
First, install the required packages and add the Microsoft repository:
````sudo apt install -y wget apt-transport-https software-properties-common
wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
wget -q https://packages.microsoft.com/keys/microsoft.asc -O- | sudo apt-key add -
````

Step 3: Update package lists
Update the apt package list to include the new repository:

````bash
sudo apt update
````
Step 4: Install .NET SDK 8.0
Now, install the .NET SDK 8.0:
```bash
sudo apt install -y dotnet-sdk-8.0
````
Step 5: Verify installation
To verify that .NET SDK 8.0 was installed successfully, run:

````bash
dotnet --version
````
Step 6: Build your project
After installing the .NET SDK 8.0, you can build your project. Navigate to the project directory and run:

````bash
dotnet build
dotnet run
````


### Known Issues/Limitations
Some features are only available on Windows (e.g., WMI queries, power management).
The port scan is a basic implementation and may not find all devices in more complex networks.
The public IP address is retrieved via an external API, which might introduce latency.
Future Enhancements
Improve the port scan with different scan types (e.g., TCP, UDP).
Add user customization options (e.g., configuration file for port lists).
Support for more operating systems.
Contact
For any questions or support, please contact the repository owner.





