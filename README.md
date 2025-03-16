# Remote Desktop Educacional

Este projeto é um sistema de **Remote Desktop** (Desktop Remoto) desenvolvido para fins educacionais, demonstrando conceitos de captura de tela, compressão de imagem, transmissão de dados em rede e exibição remota. A implementação é feita em C# e utiliza recursos da biblioteca .NET para criar um servidor que transmite a área de trabalho e um cliente que recebe e exibe as imagens em tempo real.

---

## Sumário

- [Recursos](#recursos)
- [Arquitetura e Funcionamento](#arquitetura-e-funcionamento)
- [Requisitos](#requisitos)
- [Instalação e Execução](#instalação-e-execução)
  - [Servidor](#servidor)
  - [Cliente](#cliente)
- [Detalhes do Código](#detalhes-do-código)
  - [Servidor](#servidor-código)
  - [Cliente](#cliente-código)
- [Licença](#licença)
- [Contato](#contato)

---

## Recursos

- **Captura de Tela em Tempo Real:** O servidor captura a tela principal do computador utilizando `Graphics.CopyFromScreen` e converte a imagem para JPEG.
- **Compressão de Imagem:** Utiliza parâmetros de compressão (qualidade de 50) para reduzir o tamanho da imagem antes de enviá-la.
- **Transmissão via TCP:** As imagens são enviadas através de uma conexão TCP para o cliente.
- **Interface Gráfica Simples:** O cliente possui uma interface com `PictureBox` para exibir as imagens recebidas, demonstrando a integração entre rede e GUI no Windows Forms.
- **Threading:** Uso de threads para recepção contínua de dados sem travar a interface do usuário.

---

## Arquitetura e Funcionamento

O projeto é composto por duas aplicações:

1. **Servidor:**
   - Inicia um `TcpListener` na porta `9999` e aguarda conexões de clientes.
   - Captura a tela do computador e converte a imagem para JPEG utilizando `ImageCodecInfo` e `EncoderParameters`.
   - Envia os dados da imagem, precedidos do tamanho da imagem em bytes, para o cliente através do `NetworkStream`.

2. **Cliente:**
   - Conecta ao servidor através de um `TcpClient` no endereço `127.0.0.1` e porta `9999`.
   - Em uma thread separada, lê o tamanho da imagem e os bytes enviados pelo servidor.
   - Converte os bytes recebidos de volta para um objeto `Image` e atualiza o `PictureBox` na interface.

---

## Requisitos

- **.NET Framework** (ou .NET Core/5+ se adaptado)
- **Visual Studio** ou outra IDE compatível com C#
- **Windows Forms** para a interface gráfica do cliente

---

## Instalação e Execução

### Servidor

1. Clone o repositório:
   ```bash
   git clone https://github.com/sys0xFF/RemoteDesktopEducacional.git
   ```
2. Abra o projeto do servidor no Visual Studio.
3. Compile e execute o projeto.
4. O servidor iniciará e aguardará a conexão de um cliente na porta `9999`.

## Cliente

1. Abra o projeto do cliente (pode estar em uma solução separada ou na mesma solução, conforme a organização do repositório).
2. Compile e execute o projeto.
3. O cliente tentará se conectar ao servidor no endereço `127.0.0.1` e na porta `9999`.
4. Após a conexão, as imagens da área de trabalho serão exibidas na interface.

## Detalhes do Código

### Servidor

- **Captura de Tela:** Utiliza a classe `Graphics` para capturar a tela inteira com `CopyFromScreen`.
- **Compressão:** As imagens são salvas em um MemoryStream com qualidade de compressão JPEG definida para 50, reduzindo o tamanho dos dados transmitidos.
- **Envio de Dados:** Antes de enviar os bytes da imagem, o tamanho da imagem (em bytes) é enviado para que o cliente saiba quantos bytes ler para reconstruí-la.

### Cliente

- **Conexão:** Estabelece uma conexão TCP com o servidor e inicia uma thread para tratar da recepção de imagens.
- **Recepção de Dados:** Lê os 4 bytes iniciais que representam o tamanho da imagem e, em seguida, lê os bytes da imagem conforme o tamanho indicado.
- **Interface:** A imagem é convertida de volta para o formato Image e exibida em um PictureBox, utilizando o método Invoke para atualizar a interface do usuário de forma segura a partir da thread de recepção.


## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

## Contato

Se você tiver dúvidas ou sugestões, entre em contato:

- **Nome:** Seu Nome
- **Email:** seu.email@dominio.com
- **LinkedIn/GitHub:** [Seu Perfil](https://github.com/seu-usuario)

> **Nota:** Este projeto foi desenvolvido com fins educacionais e pode servir como base para estudos sobre redes, transmissão de dados e desenvolvimento de interfaces gráficas no ambiente Windows.
