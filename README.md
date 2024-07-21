# HealthMed-Agenda - Hackaton - FIAP

Projeto Hackaton da FIAP Pos Tech

**INTEGRANTES DO GRUPO 74**

* Mois�s Barboza de Figueiredo Junior
moises.figueiredo@gmail.com

* Gabriela da Silva Lopes
gabrieladslopes@gmail.com

* Francisco Tadeu da Silva e Souza
fsouza.thadeu@gmail.com

<br />

## Projeto

Sistema propriet�rio, que permite o gerenciamento eficiente de agendamentos, 
consultas e prontu�rio eletr�nico. 

O sistema de cadastro permitir� o cadastro de m�dicos e pacientes. 
No cadastro de m�dico, haver� uma comunica��o ass�ncrona com o sistema de agenda, 
com as dados que permita o cadastramento da agenda do m�dico.

O sistema de agenda permitir� que o m�dico cadastre sua agenda de consultas
em um calend�rio. E permite que o assistente do m�dico ou o paciente agente uma 
consulta ap�s localizar o m�dico pela sua especialidade, nome ou registro. 
Ap�s o agendamento da consulta, ocorre o envio de notifica��o para o paciente 
atrav�s de envio de email.

O sistema de consulta permitir� que o m�dico interaja com o paciente presencialmente
ou por teleatendimento. Al�m de efetuar a valida��o do conv�nio m�dico do paciente 
ou registro de pagamento.

O sistema de prontu�rio eletr�nico permitir� o armazenamento e
compartilhamento de documentos, exames, cart�o de vacinas, e outros registros
m�dicos entre as partes envolvidas.


<br />

## CI/CD

Projeto conta com automa��o do GitHub Actions para build e deploy na AWS ECR e ECS.
Tamb�m conta com execu��o do SonarCloud para valida��o da c�digo e cobertura de testes.
https://sonarcloud.io/summary/overall?id=TechChallenge-4SOAT-G74_HealthMed-Agenda


<br />


## Conte�dos

- [Pr�-Requisitos](#pr�-requisitos)
- [Instala��o pelo Visual Studio 2022](#instala��o-pelo-visual-studio-2022)
- [Instala��o pelo Visual Studio Code](#instala��o-pelo-visual-studio-code)

<br />

## Pr�-Requisitos

Antes de executar este projeto, os seguintes itens dever�o estar instalados no computador:

* Docker
* Kubernetes
* Visual Studio 2022 ou Visual Studio Code
* Verificar e caso necess�rio, ajustar o arquivo appSettings.json para que os valores das connectionStrings fiquem conforme abaixo:
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/e6cbc4a3-87bf-450a-bc39-4b36182c7223)

## Instala��o pelo Visual Studio 2022

Passo a passo:

* Baixar o projeto atrav�s do reposit�rio do **GitHub**
* Abrir o projeto no **Visual Studio 2022**
* Localizar o arquivo **docker-compose** no Solution Explorer:
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/748435a2-1257-4b95-8cc8-7b63fef4cbc9)


<br />

* Clicar nele com o bot�o direito e selecionar **Set as Startup Projetct**:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/7f4ffe64-ed50-4061-b699-d148e50a2c3c)


<br />

* Clicar na op��o **Docker Compose** da barra de ferramentas padr�o:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/b3e01c69-daa8-4e97-98b0-6a3d608f628d)


<br />

* O Visual Studio criar� os containers e exibir� a tela do Swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/8854c72c-c280-450a-9b65-2b19f57a9ec9)


<br />

* Uma janela conforme abaixo abrir�:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/b489cf48-2bb9-445f-9817-c1caaf35648f)


<br />

* Na barra de endere�os, digitar /swagger ap�s o endere�o para que fique desta forma "https://localhost:53699/swagger/" (**ao executar, a sua porta pode estar diferente**) e teclar enter. O resultado ser� conforme abaixo, exibindo o swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/671a5e6d-816c-4539-be41-bb32e40970ee)


<br />

## Instala��o pelo Visual Studio Code

Passo a passo:

* Baixar o projeto atrav�s do reposit�rio do **GitHub**
* Abrir o projeto no **Visual Studio Code**
* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e navegar at� a pasta **src** do Projeto:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/c0ac9833-55d6-4b44-8d0c-0c48220697b7)


<br />

* Executar o comando `docker-compose up -d`
* Os containeres s�o levantados conforme imagem abaixo e poder�o ser listados atrav�s do comando `docker ps`

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/969a9138-7eb1-4ba6-a275-7c1f31ecd8a0)



<br />

* Abrir algum browser e informar o seguinte endere�o http ou https:
  * HTTP: **http://localhost:8090/swagger/index.html**
  * HTTPS: **https://localhost:5046/swagger/index.html**

* O resultado dever� ser conforme abaixo:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/0ef4ec5a-2b44-484f-bdf4-b7fd3f5cbd44)


<br />
