# CyberScope

CyberScope is a console application designed to retrieve various system and network information and perform different tasks. Developed to provide a simple yet powerful tool for system analysis and network monitoring.
![image](https://github.com/user-attachments/assets/4dde2ed2-0f6c-4efc-ac18-f2bcd77345dc)

## Features

CyberScope offers the following functionalities:

- **System Information:**
  - Displays operating system version, machine name, processor count, user information, and more.
  - Detailed hardware information (on Windows), including processor details, operating system version, and memory capacity.
- **Network Information:**
  - Displays local and public IP addresses.
  - Detailed information about network adapters (on Windows), including MAC address, IP address, default gateway, and DNS servers.
- **Network Scan:**
  - Performs a simple port scan on the local network with options for a short or long scan.
- **Power Management:**
  - Changes the system's power scheme (on Windows) between power saver, balanced, and high performance modes.

## Known Issues/Limitations

*   Some features are only available on Windows (e.g., WMI queries, power management).
*   The port scan is a basic implementation and may not find all devices in more complex networks.
*   The public IP address is retrieved via an external API, which might introduce latency.

## Future Enhancements

*   Improve the port scan with different scan types (e.g., TCP, UDP).
*   Add user customization options (e.g., configuration file for port lists).
*   Support for more operating systems.

## Contact