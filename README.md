Para este desafio foi escolhida a versão .NET 8.0 por se tratar de uma versão estável e recente com a qual tenho alguma experiência, e que contém integração default com o swagger - o que me ajuda bastante nos testes durante o desenvolvimento.


A Entity Framework é a versão 9.0, sendo esta a mais recente. Ótima ferramenta que me ajudou a criar as tabelas da BD sem grande esforço, assegurando uma boa integração da BD com a API, minimizando erros.

Foi utilizada a abordagem de code-first em relação à BD, usando localmente o SQLExpress (EntityFrameworkCore.Tools)

Devem então ser corridos os seguintes comandos na Package Manager Console do Visual Studio:
Add-Migration Initial (Criação da config estrutural da BD)
Update-Database (Criação da BD a partir da config criada previamente)


Caso seja preferível testar a API com o Swagger, é necessário descomentar a linha 26 do launchSettings.json e comentar a 27.

Embora as portas estejam definidas no launchSettings.json, em caso de problemas verificar as mesmas nesse ficheiro e também
na linha 37 do index.html.
