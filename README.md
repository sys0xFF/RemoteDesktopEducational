# Remote Desktop

Este é um projeto simples de Remote Desktop desenvolvido em C#. O objetivo é capturar a tela do servidor e transmiti-la para um cliente remotamente. O código foi feito de forma direta, sem muitas complexidades, basicamente uma demonstração de conceitos básicos de redes e manipulação de imagens em C#.

---

## Sumário

- [Descrição](#descrição)
- [Como Funciona](#como-funciona)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Executar](#como-executar)
- [Contatos](#contatos)

---

## Descrição

O projeto é dividido em duas partes:

- **Servidor**: Captura a tela do computador, converte a imagem em JPEG (com compressão a 50% de qualidade para balancear qualidade e desempenho) e envia os dados via TCP para o cliente.
- **Cliente**: Conecta-se ao servidor via TCP, recebe os dados da imagem, reconstrói a imagem e exibe em um formulário Windows.

---

## Como Funciona

1. **Servidor**:
   - Inicia um `TcpListener` na porta 9999.
   - Aguarda a conexão do cliente.
   - Captura a tela usando `Graphics.CopyFromScreen` e converte a imagem em JPEG.
   - Envia o tamanho da imagem seguido dos dados da imagem para o cliente.
   - Repete o processo com um pequeno delay (20ms) para atualizar a tela.

2. **Cliente**:
   - Conecta-se ao servidor utilizando `TcpClient`.
   - Cria uma thread para receber os dados.
   - Recebe os bytes que representam o tamanho da imagem e, em seguida, a imagem em si.
   - Reconstrói a imagem usando `Image.FromStream` e atualiza um `PictureBox` para exibição.

---

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET (Windows Forms para a interface do cliente)
- **Comunicação**: TCP para envio e recebimento de dados

---

## Como Executar

### Pré-requisitos

- Visual Studio ou outro ambiente de desenvolvimento compatível com C#.
- .NET Framework instalado (ou .NET Core, se adaptado).

### Passos

1. **Servidor**:
   - Compile e execute o projeto do servidor.
   - O servidor ficará aguardando a conexão de um cliente na porta 9999.

2. **Cliente**:
   - Compile e execute o projeto do cliente.
   - O cliente tentará conectar-se ao servidor local (`127.0.0.1`) na porta 9999.
   - Certifique-se de que o servidor está em execução antes de iniciar o cliente.

---

## Contatos

- **Nome:** Anthony G. Sforzin  
- **E-mail:** [anthony.sforzin@gmail.com](mailto:anthony.sforzin@gmail.com)  
- **GitHub:** [sys0xFF](https://github.com/sys0xFF)  
- **LinkedIn:** [Anthony Sforzin](https://www.linkedin.com/in/anthony-sforzin-442150332/)

---

Este README serve como um guia básico para entendimento e execução do projeto de Remote Desktop. Para mais detalhes, sinta-se à vontade para entrar em contato ou conferir meus outros projetos no GitHub.
