# Remote Desktop

This is a simple Remote Desktop project developed in C#. The goal is to capture the server's screen and transmit it remotely to a client. The code is straightforward, without many complexities, mainly serving as a demonstration of basic networking and image manipulation concepts in C#.

---

## Table of Contents

- [Description](#description)
- [How It Works](#how-it-works)
- [Technologies Used](#technologies-used)
- [How to Run](#how-to-run)
- [Contact](#contact)

---

## Description

The project is divided into two parts:

- **Server**: Captures the computer screen, converts the image to JPEG (with 50% quality compression to balance quality and performance), and sends the data via TCP to the client.
- **Client**: Connects to the server via TCP, receives the image data, reconstructs the image, and displays it in a Windows form.

---

## How It Works

1. **Server**:
   - Starts a `TcpListener` on port 9999.
   - Waits for a client connection.
   - Captures the screen using `Graphics.CopyFromScreen` and converts the image to JPEG.
   - Sends the image size followed by the image data to the client.
   - Repeats the process with a small delay (20ms) to update the screen.

2. **Client**:
   - Connects to the server using `TcpClient`.
   - Creates a thread to receive data.
   - Receives the bytes representing the image size, followed by the image itself.
   - Reconstructs the image using `Image.FromStream` and updates a `PictureBox` for display.

---

## Technologies Used

- **Language**: C#
- **Framework**: .NET (Windows Forms for the client interface)
- **Communication**: TCP for sending and receiving data

---

## How to Run

### Prerequisites

- Visual Studio or another C#-compatible development environment.
- .NET Framework installed (or .NET Core if adapted).

### Steps

1. **Server**:
   - Compile and run the server project.
   - The server will wait for a client connection on port 9999.

2. **Client**:
   - Compile and run the client project.
   - The client will try to connect to the local server (`127.0.0.1`) on port 9999.
   - Make sure the server is running before starting the client.

---

## Contact

- **Name:** Anthony G. Sforzin  
- **Email:** [anthony.sforzin@gmail.com](mailto:anthony.sforzin@gmail.com)  
- **GitHub:** [sys0xFF](https://github.com/sys0xFF)  
- **LinkedIn:** [Anthony Sforzin](https://www.linkedin.com/in/anthony-sforzin-442150332/)

---

This README serves as a basic guide for understanding and running the Remote Desktop project. For more details, feel free to reach out or check out my other projects on GitHub.
