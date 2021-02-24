# Consumindo um web service SOAP com .net 5 + WCF 

Neste projeto, faremos a chamada de um web service utilizando o protocolo SOAP/HTTP com .net 5. O serviço que iremos consumir é público, disponível em http://www.soapclient.com/xml/soapresponder.wsdl

## Pré-requisitos

 1. .NET 5: https://dotnet.microsoft.com/download/dotnet/5.0
 
 2. Um editor de texto. Utilizei o Visual Studio Code: https://code.visualstudio.com/

## Criação do projeto passo-a-passo

### Passo 1: Instalar o dotnet-svcutil
Neste projeto utilizamos a ferramenta WCF dotnet-svcutil para .NET Core: https://docs.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-svcutil-guide?tabs=dotnetsvcutil2x

    dotnet tool install --global dotnet-svcutil --version 2.0.2

### Passo 2: Criar um console app que será o nosso cliente para chamada do web service e abrir o projeto no VS Code

    dotnet new console -n Dotnet.Wcf.Svcutil
    
    cd Dotnet.Wcf.Svcutil
    
    code .

### Passo 3:  Executar dotnet-svcutil para gerar as classes proxy do web serivce e adicionar as depedências dos pacotes System.ServiceModel.*

    dotnet-svcutil http://www.soapclient.com/xml/soapresponder.wsdl --sync --outputDir ServiceReference/SoapResponder --namespace *,Dotnet.Wcf.Svcutil.ServiceReference.SoapResponder

Se ocorreu tudo bem até aqui, o projeto tem um novo arquivo (Reference.cs) na pasta ServiceReference\SoapResponder e os pacotes a seguir foram incluidos no arquivo Dotnet.Wcf.Svcutil.csproj

 - System.ServiceModel.Duplex
 - System.ServiceModel.Http
 - System.ServiceModel.NetTcp
 - System.ServiceModel.Security

### Passo 4:  Restaurar as dependências do projeto

    dotnet restore

### Passo 5: Código para efetuar a chamada do web service

> No arquivo *Program.cs*

    using System;
    using SoapResponderService = Dotnet.Wcf.Svcutil.ServiceReference.SoapResponder;
    
    namespace Dotnet.Wcf.Svcutil
    {
        class Program
        {
            static void Main(string[] args)
            {
                var client = new SoapResponderService.SoapResponderPortTypeClient();
                var response = client.Method1("VALOR-1", "VALOR-2");
                Console.WriteLine(response);
            }
        }
    }

### Passo 6: Executar o console

    dotnet run


Se deu certo, será exibido o texto a seguir, retornado pelo web service:
> **Your input parameters are VALOR-1 and VALOR-2**


## Palavras-chave
dotnet | dotnet5 | .net5 | .netcore | dotnetcore | wcf | svc | asmx | soap | wsdl | dotnet-svcutil | webservices | web services